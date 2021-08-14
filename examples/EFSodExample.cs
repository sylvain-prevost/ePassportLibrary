using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using ePassport;

namespace examples
{
    class EFSodExample
    {        
        public static void Parse(string filename)
        {
            Console.WriteLine("Parsing Document Security Object (EF.SOD): {0}", filename);

            using (FileStream fs = File.Open(filename, FileMode.Open))
            {
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);

                EFSOD efSod = Utils.DerDecode<EFSOD>(data);

                // check if SignedData contains an LdsSecurityObject
                KnownOids eContentTypeOidEnum = Oids.ParseKnown(efSod.Value.Sod.SignedData.EncapContentInfo.EContentType.Value.Value);
                if ((eContentTypeOidEnum == KnownOids.ldsSecurityObject) || (eContentTypeOidEnum == KnownOids.ldsSecurityObject_alt))
                {
                    try
                    {
                        if (CryptoUtils.VerifySignedData(efSod.Value.Sod.SignedData) == true)
                        {
                            Console.WriteLine("\tpassport content-digest signature is consistent");
                            return;
                        }

                        Console.WriteLine("\tERROR : passport content-digest signature verification failed");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\tERROR : {0}", e.Message);
                    }                    
                }
                else
                {
                    Console.WriteLine("\tERROR : LDS Security object not found !");
                }

            }            
        }
    }
}
