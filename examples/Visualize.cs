using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using FreeImageAPI;

namespace examples
{
    static class Visualize
    {
        const FREE_IMAGE_FORMAT SelectedTargetImageFormat = FREE_IMAGE_FORMAT.FIF_BMP;

        public static void LocalImageRendering(string filename, byte[] buffer, int offset, int length)
        {
            using (MemoryStream ms = new MemoryStream(buffer, offset, length))
            {
                FreeImageBitmap fbm = new FreeImageBitmap(ms);

                // adjust extension per target format
                string targetFilename = Path.ChangeExtension(filename, FreeImage.GetFIFExtensionList(SelectedTargetImageFormat).Split(',')[0]);

                // save file locally
                fbm.Save(targetFilename, SelectedTargetImageFormat);

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
}
