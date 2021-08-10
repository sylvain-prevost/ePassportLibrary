using System;
using System.Collections.Generic;
using System.IO;

using ePassport;

namespace examples
{
    class FingerPrintDatagroupExample
    {
        public static void Parse(string filename)
        {
            Console.WriteLine("Parsing FingerPrint Datagroup (DG3): {0}", filename);

            using (FileStream fs = File.Open(filename, FileMode.Open))
            {
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);

                DG3 dg3 = Utils.DerDecode<DG3>(data);

                int count = (int)dg3.Value.BiometricInfoGroupTemplate.Value.NumberOfInstances;

                byte[] biometricInfoTemplate = dg3.Value.BiometricInfoGroupTemplate.Value.BiometricInfoTemplate;

                List<BiometricInfoTemplate> biometricInfoTemplates = new List<BiometricInfoTemplate>();

                using (MemoryStream tempStream = new MemoryStream(biometricInfoTemplate))
                {
                    for (int i = 0; i < count; i++)
                    {

                        BiometricInfoTemplate template = Utils.DerDecode<BiometricInfoTemplate>(tempStream);
                        biometricInfoTemplates.Add(template);

                        byte[] fingerPrint = template.Value.BiometricDataBlock.Value;

                        int offset = 0;
                        CBEFF.FingerPrintRecordHeader fingerRecordHeader = CBEFF.ByteArrayToCBEFFStruct<CBEFF.FingerPrintRecordHeader>(fingerPrint, ref offset);
                        CBEFF.FingerPrintImageInformation imageInformation = CBEFF.ByteArrayToCBEFFStruct<CBEFF.FingerPrintImageInformation>(fingerPrint, ref offset);

                        bool isWsqCompressed = (fingerRecordHeader.compressionAlgorithm == CBEFF.CompressionAlgorithm.WSQ);

                        string adjustedFilenametoIncludeInstanceNumber = Path.GetFileNameWithoutExtension(filename) + "_" + i + Path.GetExtension(filename);
                        Visualize.LocalImageRendering(adjustedFilenametoIncludeInstanceNumber, fingerPrint, offset, fingerPrint.Length - offset, isWsqCompressed);
                    }

                }
                
            }
        }
    }
}
