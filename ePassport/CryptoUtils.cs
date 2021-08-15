

using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;


namespace ePassport
{
    using Org.BouncyCastle.Crypto.Digests;
    using Org.BouncyCastle.Crypto.Engines;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Crypto.Signers;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Security;

    public static class CryptoUtils
    {
        private static int GetHashAlgoOutputSizeFromOid(string algorithmOid)
        {
            KnownOids algorithmOidEnum = Oids.ParseKnown(algorithmOid);

            switch (algorithmOidEnum)
            {
                case KnownOids.sha1:
                    return (160 / 8);

                case KnownOids.sha256:
                    return (256 / 8);                    

                case KnownOids.sha384:
                    return (384 / 8);                    

                case KnownOids.sha512:
                    return (512 / 8);

                default:
                    throw new NotImplementedException("hash algorithm : " + algorithmOidEnum + "(" + algorithmOid + ") not yet implemented");
            }
        }

        private static IDigest GetBouncyCastleHashAlgoInstanceFromOid(string algorithmOid)
        {
            GeneralDigest digestAlgo = new Sha1Digest();

            KnownOids algorithmOidEnum = Oids.ParseKnown(algorithmOid);            

            switch (algorithmOidEnum)
            {
                case KnownOids.sha1:
                    return new Sha1Digest();

                case KnownOids.sha256:
                    return new Sha256Digest();

                case KnownOids.sha384:
                    return new Sha384Digest();

                case KnownOids.sha512:
                    return new Sha512Digest();

                default:
                    throw new NotImplementedException("hash algorithm : " + algorithmOidEnum + "(" + algorithmOid + ") not yet implemented");
            }
        }

        private static System.Security.Cryptography.HashAlgorithm GetMicrosoftHashAlgoInstanceFromOid(string algorithmOid)
        {
            KnownOids algorithmOidEnum = Oids.ParseKnown(algorithmOid);

            switch (algorithmOidEnum)
            {
                case KnownOids.sha1:
                    return SHA1.Create();                    

                case KnownOids.sha256:
                    return SHA256.Create();

                case KnownOids.sha384:
                    return SHA384.Create();                    

                case KnownOids.sha512:
                    return SHA512.Create();                    

                default:
                    throw new NotImplementedException("hash algorithm : " + algorithmOidEnum + "(" + algorithmOid + ") not yet implemented");
            }
        }

        public static byte[] ComputeHash(string algorithmOid, byte[] data)
        {
            System.Security.Cryptography.HashAlgorithm hashAlgo = null;
            try
            {
                hashAlgo = GetMicrosoftHashAlgoInstanceFromOid(algorithmOid);
                return hashAlgo.ComputeHash(data);
            }
            finally
            {
                if (hashAlgo != null)
                {
                    hashAlgo.Dispose();
                }
            }            
        }

        public static bool VerifyDigestSignature(SubjectPublicKeyInfo subjectPublicKeyInfo, byte[] digestToVerify, string digestAlgorithmOid, byte[] signatureToVerify)
        {
            bool result = false;

            KnownOids algorithmOidEnum = Oids.ParseKnown(subjectPublicKeyInfo.Algorithm.Algorithm.Value);            

            switch (algorithmOidEnum)
            {

                case KnownOids.rsaEncryption:
                    {
                        RSAPublicKey rsaPublicKey = Utils.DerDecode<RSAPublicKey>(subjectPublicKeyInfo.SubjectPublicKey.Value);

                        byte[] modulus = rsaPublicKey.Modulus.ToMicrosoftBigEndianByteArray();
                        byte[] exponent = rsaPublicKey.PublicExponent.ToMicrosoftBigEndianByteArray();

                        //Create a new instance of RSACryptoServiceProvider.
                        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(modulus.Length * 8))
                        {
                            //Create a new instance of RSAParameters.
                            RSAParameters RSAKeyInfo = new RSAParameters();

                            //Set RSAKeyInfo to the public key values.                             
                            RSAKeyInfo.Modulus = modulus;
                            RSAKeyInfo.Exponent = exponent;

                            //Import key parameters into RSA.
                            RSA.ImportParameters(RSAKeyInfo);

                            if (digestToVerify.Length == GetHashAlgoOutputSizeFromOid(digestAlgorithmOid))
                            {
                                result = RSA.VerifyHash(digestToVerify, digestAlgorithmOid, signatureToVerify);
                            }
                        }
                    }
                    return result;


                case KnownOids.rsassa_pss:
                    {
                        RSAPublicKey rsaPublicKey = Utils.DerDecode<RSAPublicKey>(subjectPublicKeyInfo.SubjectPublicKey.Value);

                        int saltLength = 20;
                        IDigest digestAlgo = new Sha1Digest();                        

                        if (subjectPublicKeyInfo.Algorithm.isParametersPresent()) {
                            RSASSA_PSS_params rsassa_pss_params = Utils.DerDecode<RSASSA_PSS_params>(subjectPublicKeyInfo.Algorithm.Parameters);
                            digestAlgo = GetBouncyCastleHashAlgoInstanceFromOid(rsassa_pss_params.HashAlgorithm.Value.Algorithm.Value);
                            saltLength = (int)rsassa_pss_params.SaltLength;
                        }

                        RsaKeyParameters publickey = new RsaKeyParameters(
                            false, 
                            rsaPublicKey.Modulus.ToBouncyCastleBigInteger(),
                            rsaPublicKey.PublicExponent.ToBouncyCastleBigInteger()
                            );

                        PssSigner eng = new PssSigner(new RsaEngine(), digestAlgo, saltLength); //create new pss

                        eng.Init(false, publickey); //initiate this one

                        eng.BlockUpdate(digestToVerify, 0, digestToVerify.Length);

                        result = eng.VerifySignature(signatureToVerify);

                    }
                    return result;


                case KnownOids.ecPublicKey:
                    {
                        // in case of ecdsa, the signature is a sequence of r and s that needs to be concatenated
                        ECDSA_Sig_Value ecdsaSignature = Utils.DerDecode<ECDSA_Sig_Value>(signatureToVerify);

                        byte[] subjectPublicKeyInfoData = Utils.DerEncodeAsByteArray<SubjectPublicKeyInfo>(subjectPublicKeyInfo);
                        Org.BouncyCastle.Asn1.Asn1Sequence asn1Sequence = (Org.BouncyCastle.Asn1.Asn1Sequence)Org.BouncyCastle.Asn1.Asn1Sequence.FromByteArray(subjectPublicKeyInfoData);
                        Org.BouncyCastle.Asn1.X509.SubjectPublicKeyInfo x509SubjectPublicKeyInfo = Org.BouncyCastle.Asn1.X509.SubjectPublicKeyInfo.GetInstance(asn1Sequence);

                        AsymmetricKeyParameter publicKeyParam = PublicKeyFactory.CreateKey(x509SubjectPublicKeyInfo);

                        ECDsaSigner ecdsa = new ECDsaSigner();

                        ecdsa.Init(false, publicKeyParam);

                        result = ecdsa.VerifySignature(
                            digestToVerify,
                            ecdsaSignature.R.ToBouncyCastleBigInteger(),
                            ecdsaSignature.S.ToBouncyCastleBigInteger()
                        );                        

                    }
                    return result;

                default:
                    throw new NotImplementedException("Signature Algorithm : " + algorithmOidEnum + "(" + subjectPublicKeyInfo.Algorithm.Algorithm.Value + ") not yet implemented");
            }
        }

        public static bool VerifySignedData(SignedData signedData)
        {
            Certificate certificate = null;
            return VerifySignedData(signedData, out certificate);
        }

        public static bool VerifySignedData(SignedData signedData, out Certificate certificate)
        {
            certificate = null;

            foreach (SignerInfo signerInfo in signedData.SignerInfos.Value)
            {
                byte[] digestToVerify = null;

                byte[] signature = signerInfo.Signature.Value;
                
                string digestAlgorithmOid = signerInfo.DigestAlgorithm.Value.Algorithm.Value;                

                string signatureAlgorithmOid = signerInfo.SignatureAlgorithm.Value.Algorithm.Value;

                KnownOids signatureOidEnum = Oids.ParseKnown(signatureAlgorithmOid);
                
                switch (signatureOidEnum)
                {
                    case KnownOids.rsassa_pss:
                        // in case of rsa ssa pss, the digest is computed along with the verification
                        digestToVerify = signedData.EncapContentInfo.EContent;
                        break;

                    default:
                        digestToVerify = ComputeHash(digestAlgorithmOid, signedData.EncapContentInfo.EContent);
                        break;
                }

                BigInteger certificateSerialNumber = signerInfo.Sid.IssuerAndSerialNumber.SerialNumber.Value;

                // if SignedAttrs is Present then it should be used (SignedAttrs contains the eContent digest).
                // Note: not sure how it works with rsa pss...
                if (signerInfo.isSignedAttrsPresent())
                {
                    foreach (ePassport.Attribute attribute in signerInfo.SignedAttrs.Value)
                    {
                        if (Oids.ParseKnown(attribute.Type.Value.Value) == KnownOids.messageDigest)
                        {
                            byte[] digest = ((List<byte[]>)attribute.Values)[0];

                            // verify that econtent digest is matching
                            if (Utils.Compare(digestToVerify, 0, digest, digest.Length - digestToVerify.Length, digestToVerify.Length) == true)
                            {
                                // since it is matching, let's use the SignedAttrs as input for the digest
                                byte[] dataToHash = Utils.DerEncodeAsByteArray<SignedAttributes>(signerInfo.SignedAttrs);
                                digestToVerify = ComputeHash(digestAlgorithmOid, dataToHash);
                                break;
                            }
                        }

                    }
                }

                foreach (CertificateChoices certChoice in signedData.Certificates.Value)
                {
                    if (Utils.Compare(certChoice.Certificate.TbsCertificate.SerialNumber.Value.ToByteArray(), certificateSerialNumber.ToByteArray()) == true)
                    {
                        bool isSignatureVerifiedSuccessfully = VerifyDigestSignature(
                            certChoice.Certificate.TbsCertificate.SubjectPublicKeyInfo,
                            digestToVerify,
                            digestAlgorithmOid,
                            signature
                            );

                        certificate = certChoice.Certificate;

                        return isSignatureVerifiedSuccessfully;
                    }
                }

            }

            return false;
        }



#region Extensions

        public static Org.BouncyCastle.Math.BigInteger ToBouncyCastleBigInteger(this BigInteger value)
        {
            List<byte> dataList = new List<byte>(value.ToByteArray());
            dataList.Reverse();
            return new Org.BouncyCastle.Math.BigInteger(dataList.ToArray());
        }

        public static byte[] ToMicrosoftBigEndianByteArray(this BigInteger value)
        {
            List<byte> dataList = new List<byte>(value.ToByteArray());
            dataList.Reverse();
            if (dataList[0] == 0x00)
            {
                dataList.RemoveAt(0);
            }            
            return dataList.ToArray();
        }        

#endregion
    }
}
