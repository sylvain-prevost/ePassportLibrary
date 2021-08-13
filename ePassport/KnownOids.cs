using System;
using System.ComponentModel;
using System.IO;
using System.Numerics;
using System.Reflection;

namespace ePassport
{
    public enum KnownOids
    {
        [Description("unknown")]
        unknown,

        [Description("2.5.4.3")]
        commonName,

        [Description("2.5.4.4")]
        surname,

        [Description("2.5.4.5")]
        serialNumber,

        [Description("2.5.4.6")]
        countryName,

        [Description("2.5.4.7")]
        localityName,

        [Description("2.5.4.8")]
        stateOrProvinceName,

        [Description("2.5.4.9")]
        streetAddress,

        [Description("2.5.4.10")]
        organizationName,

        [Description("2.5.4.11")]
        organizationalUnitName,

        [Description("2.5.4.17")]
        postalCode,

        [Description("2.5.4.20")]
        telephoneNumber,

        [Description("2.5.29.14")]
        subjectKeyIdentifier,

        [Description("2.5.29.15")]
        keyUsage,

        [Description("2.5.29.16")]
        privateKeyUsagePeriod,

        [Description("2.5.29.17")]
        subjectAltName,

        [Description("2.5.29.18")]
        issuerAltName,

        [Description("2.5.29.19")]
        basicConstraints,

        [Description("2.5.29.31")]
        crlDistributionPoints,

        [Description("2.5.29.32")]
        certificatePolicies,

        [Description("2.5.29.35")]
        authorityKeyIdentifier,

        [Description("2.5.29.37")]
        extKeyUsage,

        [Description("1.3.27.1.1.1")]
        ldsSecurityObject_alt,

        [Description("2.23.136.1.1.1")]
        ldsSecurityObject,

        [Description("1.2.840.10045.1.1")]
        prime_field,

        [Description("1.2.840.10045.1.2")]
        characteristic_two_field,

        [Description("1.2.840.10045.2.1")]
        ecPublicKey,

        [Description("1.2.840.10045.4.1")]
        ecdsa_with_sha1,

        [Description("1.2.840.10045.4.3.2")]
        ecdsa_with_sha256,

        [Description("1.2.840.10045.4.3.3")]
        ecdsa_with_sha384,

        [Description("1.2.840.10045.4.3.4")]
        ecdsa_with_sha512,

        [Description("1.2.840.113549.1.1.1")]
        rsaEncryption,

        [Description("1.2.840.113549.1.1.8")]
        rsa_with_mask_generator_function_1,

        [Description("1.2.840.113549.1.1.5")]
        sha1_with_rsa_signature,

        [Description("1.2.840.113549.1.1.10")]
        rsassa_pss,

        [Description("1.2.840.113549.1.1.11")]
        sha256_with_rsa_encryption,

        [Description("1.2.840.113549.1.1.12")]
        sha384_with_rsa_encryption,

        [Description("1.2.840.113549.1.1.13")]
        sha512_with_rsa_encryption,

        [Description("1.2.840.113549.1.7.2")]
        signedData,

        [Description("1.2.840.113549.1.9.1")]
        emailAddress,

        [Description("1.2.840.113549.1.9.3")]
        contentType,

        [Description("1.2.840.113549.1.9.4")]
        messageDigest,

        [Description("1.2.840.113549.1.9.5")]
        signing_time,

        [Description("1.2.840.113549.1.9.21")]
        localKeyID,

        [Description("1.2.840.113533.7.65.0")]
        nsn_ce,

        [Description("1.3.6.1.4.1.311.20.2")]
        enroll_certtype_extension,

        [Description("1.3.6.1.4.1.311.21.1")]
        certsrv_ca_version,

        [Description("1.3.6.1.4.1.311.21.2")]
        certsrv_previous_cert_hash,

        [Description("1.3.6.1.5.5.7.1.1")]
        authorityInfoAccess,

        [Description("1.3.6.1.5.5.7.48.1")]
        online_certicate_status_protocol,

        [Description("1.3.6.1.5.5.7.48.2")]
        certificate_authority_issuers,        

        [Description("1.3.14.3.2.26")]
        sha1,

        [Description("2.16.840.1.101.3.4.2.1")]
        sha256,

        [Description("2.16.840.1.101.3.4.2.2")]
        sha384,

        [Description("2.16.840.1.101.3.4.2.3")]
        sha512,

        [Description("2.16.840.1.113730.1.1")]
        cert_type,

        [Description("2.23.136.1.1.2")]
        cscaMasterList,

        [Description("2.23.136.1.1.6.1")]
        nameChange,

        [Description("2.23.136.1.1.6.2")]
        documentTypeList,

        [Description("0.4.0.127.0.7.2.2.1.2")]
        smartcards_id_PK_ECDH,

        [Description("0.4.0.127.0.7.2.2.4.2.4")]
        smartcards_id_PACE_ECDH_GM_AES_CBC_CMAC_256
    }

    public class Oids
    {
        public static KnownOids ParseKnown(string oidString)
        {
            Array names = Enum.GetNames(typeof(KnownOids));
            foreach (string name in names)
            {
                KnownOids KnownOid = (KnownOids)Enum.Parse(typeof(KnownOids), name);
                if (KnownOid.GetDescription() == oidString)
                {
                    return KnownOid;
                }
            }

            throw new NotImplementedException("Unknown oid : " + oidString);
        }

        /// <summary>
        /// Decode single OID value.
        /// </summary>
        /// <param name="bt">source stream.</param>
        /// <param name="v">output value</param>
        /// <returns>OID value bytes.</returns>
        private static int DecodeValue(Stream bt, ref BigInteger v)
        {
            byte b;
            int i = 0;
            v = 0;
            while (true)
            {
                b = (byte)bt.ReadByte();
                i++;
                v <<= 7;
                v += (ulong)(b & 0x7f);
                if ((b & 0x80) == 0)
                    return i;
            }
        }

        /// <summary>
        /// Decode OID <see cref="Stream"/> and return OID string.
        /// </summary>
        /// <param name="bt">source stream.</param>
        /// <returns>result OID string.</returns>
        private static string Decode(Stream bt)
        {
            string retval = "";
            byte b;
            BigInteger v = 0;
            b = (byte)bt.ReadByte();
            retval += Convert.ToString(b / 40);
            retval += "." + Convert.ToString(b % 40);
            while (bt.Position < bt.Length)
            {
                try
                {
                    DecodeValue(bt, ref v);
                    retval += "." + v.ToString();
                }
                catch (Exception e)
                {
                    throw new Exception("Failed to decode OID value: " + e.Message);
                }
            }
            return retval;
        }

        /// <summary>
        /// Decode OID byte array to OID string.
        /// </summary>
        /// <param name="data">source byte array.</param>
        /// <returns>result OID string.</returns>
        public static string OIDDecode(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            ms.Position = 0;
            string retval = Decode(ms);
            ms.Close();
            return retval;
        }

    }
}
