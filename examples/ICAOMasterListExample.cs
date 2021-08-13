using System;
using System.Collections.Generic;
using System.IO;

using ePassport;

namespace examples
{
    class ICAOMasterListExample
    {
        static void displayCertInfo(Certificate cert)
        {
            Dictionary<string, string> certDict = CertificateExample.GetSomeHumanReadableInfo(cert);
            foreach (string key in certDict.Keys)
            {
                Console.WriteLine("\t\t" + key + " = " + certDict[key]);
            }
        }

        
        public static void Parse(string filename)
        {
            Console.WriteLine("Parsing ICAO Masterlist: {0}", filename);

            if (filename == null)
            {
                Console.WriteLine("\tdownload the CSCA masterlist file from : {0}", @"https://www.icao.int/Security/FAL/PKD/Pages/icao-master-list.aspx");
                Console.WriteLine("\tand add reference to file");
                return;
            }

            using (FileStream fs = File.Open(filename, FileMode.Open))
            {
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);

                ContentInfo contentInfo = Utils.DerDecode<ContentInfo>(data);

                KnownOids oid = Oids.ParseKnown(contentInfo.ContentType.Value.Value);
                if (oid == KnownOids.signedData)
                {
                    SignedData signedData = Utils.DerDecode<SignedData>(contentInfo.Content);

                    // check if SignedData contains a cscaMasterList object
                    if (Oids.ParseKnown(signedData.EncapContentInfo.EContentType.Value.Value) == KnownOids.cscaMasterList)
                    {
                        // check the masterlist digest signature here
                        // check the digest signature
                        Certificate cscaMasterListcertificate;

                        if (CryptoUtils.VerifySignedData(signedData, out cscaMasterListcertificate) == true)
                        {
                            Console.WriteLine("\tCSCA masterlist digest signature verified successfully using cert :");
                            displayCertInfo(cscaMasterListcertificate);
                            
                            // now obtain the master list content
                            CscaMasterList cscaMasterList = Utils.DerDecode<CscaMasterList>(signedData.EncapContentInfo.EContent);

                            Console.WriteLine("\tnumber of certs present in cscaMasterList : " + cscaMasterList.CertList.Count);

                            int idx = 0;
                            foreach (Certificate certificate in cscaMasterList.CertList) {
                                Console.WriteLine("\tCertificate[{0}]:", idx);
                                displayCertInfo(certificate);
                                idx++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\tERROR : CSCA masterlist digest signature verification failed");
                        }                        
                    }
                }

            }
        }
    }
}
