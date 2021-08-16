using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using ePassport;

namespace examples
{
    class ActiveAuthenticationDatagroupExample
    {        
        public static void Parse(string filename)
        {
            Console.WriteLine("Parsing ActiveAuthentication Public Key Info Datagroup (DG15): {0}", filename);

            using (FileStream fs = File.Open(filename, FileMode.Open))
            {
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);

                DG15 dg15 = Utils.DerDecode<DG15>(data);

                SubjectPublicKeyInfo subjectPublicKeyInfo = dg15.Value.ActiveAuthenticationPublicKeyInfo.Value;

                Console.WriteLine("\tPublic key algorithm : {0}", Oids.ParseKnown(subjectPublicKeyInfo.Algorithm.Algorithm.Value));
                Console.WriteLine("\tPublic key value : {0}", Utils.ByteArrayToHexString(subjectPublicKeyInfo.SubjectPublicKey.Value));
            }            
        }
    }
}
