
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

            // Parsing example of an ePassport Datagroup2 (face) 
            FaceDatagroupExample.Parse(@"bsi2008\Datagroup2.bin");

            // Parsing example of an ePassport Datagroup3 (fingerprint)
            FingerPrintDatagroupExample.Parse(@"bsi2008\Datagroup3.bin");            
        }

        
    }
}
