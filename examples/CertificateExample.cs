
using System;
using System.Collections.Generic;
using System.IO;

using ePassport;

namespace examples

{
    class CertificateExample
    {
        private const byte UNIVERSAL_TAG_PRINTABLESTRING = (byte)19;
        private const byte UNIVERSAL_TAG_UTF8STRING = (byte)12;

        public static Dictionary<string, string> GetSomeHumanReadableInfo(ePassport.Certificate certificate)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            // process Issuer infos
            foreach (RelativeDistinguishedName rdn in certificate.TbsCertificate.Issuer.RdnSequence.Value)
            {
                foreach (AttributeTypeAndValue attributeTypeAndValue in rdn.Value)
                {
                    KnownOids knownOid = Oids.ParseKnown(attributeTypeAndValue.Type.Value.Value);

                    switch (knownOid)
                    {
                        case KnownOids.commonName:
                        case KnownOids.organizationName:
                        case KnownOids.countryName:
                            {
                                byte tag = attributeTypeAndValue.Value[0];
                                int len = attributeTypeAndValue.Value[1];

                                switch (tag)
                                {
                                    case UNIVERSAL_TAG_PRINTABLESTRING:
                                    case UNIVERSAL_TAG_UTF8STRING:
                                        string content = System.Text.ASCIIEncoding.UTF8.GetString(attributeTypeAndValue.Value, 2, len);
                                        if (dic.ContainsKey(knownOid.ToString()) == false)
                                        {
                                            dic.Add(knownOid.ToString(), content);
                                        }
                                        break;
                                }
                            }
                            break;
                    }
                    

                }
            }

            // process Extensions
            foreach (Extension ext in certificate.TbsCertificate.Extensions.Value)
            {
                KnownOids knownOid = Oids.ParseKnown(ext.ExtnID.Value);

                switch (knownOid)
                {
                    case KnownOids.authorityInfoAccess:
                        AuthorityInfoAccessSyntax authorityInfoAccessSyntax = Utils.DerDecode<AuthorityInfoAccessSyntax>(ext.ExtnValue);
                        foreach (AccessDescription accessDescription in authorityInfoAccessSyntax.Value)
                        {
                            KnownOids accessMethod = Oids.ParseKnown(accessDescription.AccessMethod.Value);
                            if (accessDescription.AccessLocation.isUniformResourceIdentifierSelected())
                            {
                                string content = new Uri(accessDescription.AccessLocation.UniformResourceIdentifier).ToString();
                                string key = knownOid.ToString() + " - URI";
                                if (dic.ContainsKey(key) == false)
                                {
                                    dic.Add(key, content);
                                }
                            }
                        }
                        break;

                    case KnownOids.crlDistributionPoints:
                        CRLDistributionPoints cRLDistributionPoints = Utils.DerDecode<CRLDistributionPoints>(ext.ExtnValue);
                        foreach (DistributionPoint distributionPoint in cRLDistributionPoints.Value)
                        {
                            if (distributionPoint.isDistributionPointNamePresent())
                            {
                                if (distributionPoint.DistributionPointName.isFullNameSelected())
                                {
                                    foreach (GeneralName generalName in distributionPoint.DistributionPointName.FullName.Value)
                                    {
                                        if (generalName.isUniformResourceIdentifierSelected())
                                        {
                                            string content = new Uri(generalName.UniformResourceIdentifier).ToString();
                                            string key = knownOid.ToString() + " - Fullname - URI";
                                            if (dic.ContainsKey(key) == false)
                                            {
                                                dic.Add(key, content);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;

                    default:
                        byte tag = ext.ExtnValue[0];
                        int len = ext.ExtnValue[1];

                        switch (tag)
                        {
                            case UNIVERSAL_TAG_PRINTABLESTRING:
                            case UNIVERSAL_TAG_UTF8STRING:
                                string content = System.Text.ASCIIEncoding.UTF8.GetString(ext.ExtnValue, 2, len);
                                if (dic.ContainsKey(knownOid.ToString()) == false)
                                {
                                    dic.Add(knownOid.ToString(), content);
                                }
                                break;
                        }
                        break;
                }
            }

            return dic;
        }

        public static void Decode(string certificateFilename)
        {
            Console.WriteLine("Parsing Certificate: {0}", certificateFilename);

            using (FileStream fs = File.Open(certificateFilename, FileMode.Open))
            {
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);

                ePassport.Certificate certificate = Utils.DerDecode<ePassport.Certificate>(data);

                Dictionary<string, string> dic_KnownCert = GetSomeHumanReadableInfo(certificate);

                foreach (string key in dic_KnownCert.Keys)
                {
                    Console.WriteLine("\t" + key + " = " + dic_KnownCert[key]);
                }
            }
            
        }        
    }
}
