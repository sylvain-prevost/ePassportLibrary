using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using ePassport;

namespace examples
{
    class MrzDatagroupExample
    {        
        public static void Parse(string filename)
        {
            Console.WriteLine("Parsing MRZ Datagroup (DG1): {0}", filename);

            using (FileStream fs = File.Open(filename, FileMode.Open))
            {
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);

                DG1 dg1 = Utils.DerDecode<DG1>(data);
                List<string> mrzLines = new List<string>();
                for (int i = 0; i < dg1.Value.Mrz.Length / 44; i++)
                {
                    mrzLines.Add(dg1.Value.Mrz.Substring((i * 44), 44));
                }

                Console.WriteLine("\tMRZ:");
                foreach (string mrzLine in mrzLines)
                {
                    Console.WriteLine("\t\t{0}", mrzLine);
                }

            }            
        }
    }
}
