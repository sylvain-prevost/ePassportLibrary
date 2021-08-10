
namespace examples
{
    
    class Program
    {

        public static void Main(string[] args)
        {
            // example using LetsEncrypt Self-Signed certificate - see https://letsencrypt.org/certificates/
            CertificateExample.Decode(@"isrgrootx1.der");

            // example using LetsEncrypt Cross-signed certificate - see https://letsencrypt.org/certificates/
            CertificateExample.Decode(@"isrg-root-x1-cross-signed.der");

            // example of parsing of the ICAO masterlist
            // see https://www.icao.int/Security/FAL/PKD/Pages/icao-master-list.aspx to obtain the file
            ICAOMasterListExample.Parse(null);

            // example of parsing of an ePassport Datagroup2 (face) parsing
            FaceDatagroupExample.Parse(@"Datagroup2.bin");

            // example of parsing of an ePassport Datagroup3 (fingerprint) parsing
            FingerPrintDatagroupExample.Parse(@"Datagroup3.bin");
        }

        
    }
}
