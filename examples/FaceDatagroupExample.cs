using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using ePassport;

namespace examples
{
    class FaceDatagroupExample
    {        
        public static void Parse(string filename)
        {
            Console.WriteLine("Parsing Face Datagroup (DG2): {0}", filename);

            using (FileStream fs = File.Open(filename, FileMode.Open))
            {
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);

                DG2 dg2 = Utils.DerDecode<DG2>(data);

                int count = (int)dg2.Value.BiometricInfoGroupTemplate.Value.NumberOfInstances;

                byte[] biometricInfoTemplate = dg2.Value.BiometricInfoGroupTemplate.Value.BiometricInfoTemplate;

                List<BiometricInfoTemplate> biometricInfoTemplates = new List<BiometricInfoTemplate>();

                using (MemoryStream tempStream = new MemoryStream(biometricInfoTemplate))
                {

                    for (int i = 0; i < count; i++)
                    {

                        BiometricInfoTemplate template = Utils.DerDecode <BiometricInfoTemplate>(tempStream);
                        biometricInfoTemplates.Add(template);

                        byte[] face = template.Value.BiometricDataBlock.Value;

                        int offset = 0;

                        CBEFF.FacialRecordHeader facialRecordHeaderStruct = CBEFF.ByteArrayToCBEFFStruct<CBEFF.FacialRecordHeader>(face, ref offset);
                        CBEFF.FacialInformationBlock facialInformationBlock = CBEFF.ByteArrayToCBEFFStruct<CBEFF.FacialInformationBlock>(face, ref offset);
                        CBEFF.FacialImageInformation imageInformation = CBEFF.ByteArrayToCBEFFStruct<CBEFF.FacialImageInformation>(face, ref offset);

                        // At this point we've know where this actual image data are in the face buffer (JP2000 compressed format used by ICAO in ePassport).
                        
                        // we'll rely on 'FreeImage' library to transform it into something which has wider number of available viewers (bmp, jpeg, etc..).

                        string adjustedFilenametoIncludeInstanceNumber = Path.GetFileNameWithoutExtension(filename) + "_" + i + Path.GetExtension(filename);

                        Visualize.LocalImageRendering(adjustedFilenametoIncludeInstanceNumber, face, offset, face.Length - offset);
                    }
                }

            }            
        }
    }
}
