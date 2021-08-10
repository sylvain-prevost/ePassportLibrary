
using System;
using System.Diagnostics;
using System.IO;

using ePassport;

using FreeImageAPI;

namespace examples
{
    static class Visualize
    {
        const FREE_IMAGE_FORMAT SelectedTargetImageFormat = FREE_IMAGE_FORMAT.FIF_BMP;

        public static void LocalImageRendering(string filename, byte[] buffer, int offset, int length, bool isWsqCompressed = false)
        {
            FreeImageBitmap fbm;            

            if (isWsqCompressed == true)
            {
                // obtain decode info
                WSQDecodedInfo decodedInfo = WaveletScalarQuantization.Decode(buffer, offset, length);

                fbm = new FreeImageBitmap(decodedInfo.Width, decodedInfo.Height);

                var pix = 0;
                for (int i = 0; i < decodedInfo.Height; i++)
                {
                    for (int j = 0; j < decodedInfo.Width; j++)
                    {
                        fbm.SetPixel(j, i, System.Drawing.Color.FromArgb(decodedInfo.Data[pix], decodedInfo.Data[pix], decodedInfo.Data[pix]));
                        pix++;
                    }
                }

                fbm.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipX);                                              
            }
            else
            {
                using (MemoryStream ms = new MemoryStream(buffer, offset, length))
                {
                    fbm = new FreeImageBitmap(ms);
                }
            }

            // adjust extension per target format
            string targetFilename = Path.ChangeExtension(filename, FreeImage.GetFIFExtensionList(SelectedTargetImageFormat).Split(',')[0]);

            // save file locally
            fbm.Save(targetFilename, SelectedTargetImageFormat);

            Console.WriteLine("\tImage saved : {0}", Path.GetFullPath(targetFilename));

            // attempt to trigger local viewer
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo(targetFilename);
                psi.UseShellExecute = true;
                Process.Start(psi);
            }
            catch
            {
                Console.WriteLine("Could not launch local viewer, image available at : " + Path.GetFullPath(targetFilename));
            }            
        }
    }
}
