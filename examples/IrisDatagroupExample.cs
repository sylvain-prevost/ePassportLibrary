using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using ePassport;

namespace examples
{
    class IrisDatagroupExample
    {        
        public static void Parse(string filename)
        {
            Console.WriteLine("Parsing Iris Datagroup (DG4): {0}", filename);

            using (FileStream fs = File.Open(filename, FileMode.Open))
            {
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);

                DG4 dg4 = Utils.DerDecode<DG4>(data);

                int count = (int)dg4.Value.BiometricInfoGroupTemplate.Value.NumberOfInstances;

                byte[] biometricInfoTemplate = dg4.Value.BiometricInfoGroupTemplate.Value.BiometricInfoTemplate;

                List<BiometricInfoTemplate> biometricInfoTemplates = new List<BiometricInfoTemplate>();

                using (MemoryStream tempStream = new MemoryStream(biometricInfoTemplate))
                {

                    for (int i = 0; i < count; i++)
                    {

                        BiometricInfoTemplate template = Utils.DerDecode <BiometricInfoTemplate>(tempStream);
                        biometricInfoTemplates.Add(template);

                        byte[] iris = template.Value.BiometricDataBlock.Value;

                        int offset = 0;

                        CBEFF.IrisRecordHeader irisRecordHeaderStruct = CBEFF.ByteArrayToCBEFFStruct<CBEFF.IrisRecordHeader>(iris, ref offset);

                        for (int j = 0; j < irisRecordHeaderStruct.count; j++)
                        {
                            CBEFF.IrisBiometricSubtypeInformation irisBiometricSubtypeInformation = CBEFF.ByteArrayToCBEFFStruct<CBEFF.IrisBiometricSubtypeInformation>(iris, ref offset);

                            for (int k = 0; k < irisBiometricSubtypeInformation.count; k++)
                            {
                                CBEFF.IrisImageInformation irisImageInformation = CBEFF.ByteArrayToCBEFFStruct<CBEFF.IrisImageInformation>(iris, ref offset);

                                bool isWsqCompressed = ((irisRecordHeaderStruct.imageFormat == CBEFF.IrisImageFormat.MONO_RAW) || (irisRecordHeaderStruct.imageFormat == CBEFF.IrisImageFormat.RGB_RAW));

                                // At this point we've know where this actual image data are in the face buffer (JP2000 compressed format used by ICAO in ePassport).                        
                                // we'll rely on 'FreeImage' library to transform it into something which has wider number of available viewers (bmp, jpeg, etc..).
                                string adjustedFilenametoIncludeInstanceNumber = Path.GetFileNameWithoutExtension(filename) + "_Iris_" + irisBiometricSubtypeInformation.biometricSubtype.ToString() + "_" + i + Path.GetExtension(filename);
                                Visualize.LocalImageRendering(adjustedFilenametoIncludeInstanceNumber, iris, offset, iris.Length - offset, isWsqCompressed);
                            }
                        }                                                
                    }
                }

            }            
        }
    }
}
