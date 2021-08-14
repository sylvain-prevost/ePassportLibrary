using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using ePassport;

namespace examples
{
    class EFComExample
    {        
        public static void Parse(string filename)
        {
            Console.WriteLine("Parsing Common Data elements (EF.COM): {0}", filename);

            using (FileStream fs = File.Open(filename, FileMode.Open))
            {
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);

                EFCOM efCom = Utils.DerDecode<EFCOM>(data, true);

                string ldsVersionNumber = efCom.Value.LdsVersionNumber;
                Console.WriteLine("\tldsVersionNumber : {0}", ldsVersionNumber);

                for (int i = 0; i < efCom.Value.DatagroupList.Length; i++)
                {
                    Console.WriteLine("\tElementary File with Tag 0x{0} is present", efCom.Value.DatagroupList[i].ToString("X2"));
                }

            }            
        }
    }
}
