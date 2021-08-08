using System;
using System.Collections.Generic;
using System.IO;

using ePassport;

namespace examples
{
    class ICAOMasterListExample
    {
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
                        // ....

                        // now obtain the master list content
                        CscaMasterList cscaMasterList = Utils.DerDecode<CscaMasterList>(signedData.EncapContentInfo.EContent);

                        Console.WriteLine("number of certs present in cscaMasterList : " + cscaMasterList.CertList.Count);

                        int idx = 0;

                        foreach (Certificate certificate in cscaMasterList.CertList)
                        {
                            Console.WriteLine("Certificate[{0}]:", idx);

                            Dictionary<string, string> dic_KnownCert = CertificateExample.GetSomeHumanReadableInfo(certificate);

                            foreach (string key in dic_KnownCert.Keys)
                            {
                                Console.WriteLine("\t" + key + " = " + dic_KnownCert[key]);
                            }

                            idx++;
                        }
                    }
                }

            }
        }
    }
}
