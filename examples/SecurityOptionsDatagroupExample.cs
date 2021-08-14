using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using ePassport;

namespace examples
{
    class SecurityOptionsDatagroupExample
    {        
        public static void Parse(string filename)
        {
            Console.WriteLine("Parsing SecurityOptions Datagroup (DG14): {0}", filename);

            using (FileStream fs = File.Open(filename, FileMode.Open))
            {
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);

                DG14 dg14 = Utils.DerDecode<DG14>(data);

                foreach (SecurityInfo securityInfo in dg14.Value.SecurityInfos.Value)
                {
                    byte[] encoded = Utils.DerEncodeAsByteArray<SecurityInfo>(securityInfo);

                    switch (Oids.ParseKnown(securityInfo.Protocol.Value))
                    {
                        case KnownOids.smartcards_id_PACE_DH_GM_3DES_CBC_CBC:
                        case KnownOids.smartcards_id_PACE_DH_GM_AES_CBC_CMAC_128:
                        case KnownOids.smartcards_id_PACE_DH_GM_AES_CBC_CMAC_192:
                        case KnownOids.smartcards_id_PACE_DH_GM_AES_CBC_CMAC_256:
                        case KnownOids.smartcards_id_PACE_ECDH_GM_3DES_CBC_CBC:
                        case KnownOids.smartcards_id_PACE_ECDH_GM_AES_CBC_CMAC_128:
                        case KnownOids.smartcards_id_PACE_ECDH_GM_AES_CBC_CMAC_192:
                        case KnownOids.smartcards_id_PACE_ECDH_GM_AES_CBC_CMAC_256:
                        case KnownOids.smartcards_id_PACE_DH_IM_3DES_CBC_CBC:
                        case KnownOids.smartcards_id_PACE_DH_IM_AES_CBC_CMAC_128:
                        case KnownOids.smartcards_id_PACE_DH_IM_AES_CBC_CMAC_192:
                        case KnownOids.smartcards_id_PACE_DH_IM_AES_CBC_CMAC_256:
                        case KnownOids.smartcards_id_PACE_ECDH_IM_3DES_CBC_CBC:
                        case KnownOids.smartcards_id_PACE_ECDH_IM_AES_CBC_CMAC_128:
                        case KnownOids.smartcards_id_PACE_ECDH_IM_AES_CBC_CMAC_192:
                        case KnownOids.smartcards_id_PACE_ECDH_IM_AES_CBC_CMAC_256:
                        case KnownOids.smartcards_id_PACE_ECDH_CAM_AES_CBC_CMAC_128:
                        case KnownOids.smartcards_id_PACE_ECDH_CAM_AES_CBC_CMAC_192:
                        case KnownOids.smartcards_id_PACE_ECDH_CAM_AES_CBC_CMAC_256:
                            Console.WriteLine("\tPACEInfo present");
                            PACEInfo pacEInfo = Utils.DerDecode<PACEInfo>(encoded);                            
                            break;

                        case KnownOids.smartcards_id_PACE_DH_GM:
                        case KnownOids.smartcards_id_PACE_ECDH_GM:
                        case KnownOids.smartcards_id_PACE_DH_IM:
                        case KnownOids.smartcards_id_PACE_ECDH_IM:
                        case KnownOids.smartcards_id_PACE_ECDH_CAM:
                            Console.WriteLine("\tPACEDomainParameterInfo present");
                            PACEDomainParameterInfo paceDomainParameterInfo = Utils.DerDecode<PACEDomainParameterInfo>(encoded);                            
                            break;

                        case KnownOids.id_icao_mrtd_security_aaProtocolObject:
                            Console.WriteLine("\tActiveAuthenticationInfo present");
                            ActiveAuthenticationInfo activeAuthenticationInfo = Utils.DerDecode<ActiveAuthenticationInfo>(encoded);                            
                            break;

                        case KnownOids.id_CA_DH_3DES_CBC_CBC:
                        case KnownOids.id_CA_DH_AES_CBC_CMAC_128:
                        case KnownOids.id_CA_DH_AES_CBC_CMAC_192:
                        case KnownOids.id_CA_DH_AES_CBC_CMAC_256:
                        case KnownOids.id_CA_ECDH_3DES_CBC_CBC:
                        case KnownOids.id_CA_ECDH_AES_CBC_CMAC_128:
                        case KnownOids.id_CA_ECDH_AES_CBC_CMAC_192:
                        case KnownOids.id_CA_ECDH_AES_CBC_CMAC_256:
                            Console.WriteLine("\tChipAuthenticationInfo present");
                            ChipAuthenticationInfo chipAuthenticationInfo = Utils.DerDecode<ChipAuthenticationInfo>(encoded);                            
                            break;

                        case KnownOids.smartcards_id_PK_DH:
                        case KnownOids.smartcards_id_PK_ECDH:
                            Console.WriteLine("\tChipAuthenticationPublicKeyInfo present");
                            ChipAuthenticationPublicKeyInfo chipAuthenticationPublicKeyInfo = Utils.DerDecode<ChipAuthenticationPublicKeyInfo>(encoded);
                            switch (Oids.ParseKnown(chipAuthenticationPublicKeyInfo.ChipAuthenticationPublicKey.Algorithm.Algorithm.Value))
                            {
                                case KnownOids.ecPublicKey:
                                    ECParameters ecParameters = Utils.DerDecode<ECParameters>(chipAuthenticationPublicKeyInfo.ChipAuthenticationPublicKey.Algorithm.Parameters);
                                    byte[] ecPublicKey = chipAuthenticationPublicKeyInfo.ChipAuthenticationPublicKey.SubjectPublicKey.Value;
                                    Console.WriteLine("\t\tec PublicKey : {0}", Utils.ByteArrayToHexString(ecPublicKey));
                                    break;
                            }
                            break;

                        case KnownOids.id_TA:
                        case KnownOids.id_TA_RSA:
                        case KnownOids.id_TA_RSA_PSS_SHA_256:
                        case KnownOids.id_TA_RSA_PSS_SHA_512:
                        case KnownOids.id_TA_ECDSA:
                        case KnownOids.id_TA_ECDSA_SHA_224:
                        case KnownOids.id_TA_ECDSA_SHA_256:
                        case KnownOids.id_TA_ECDSA_SHA_384:
                        case KnownOids.id_TA_ECDSA_SHA_512:
                            Console.WriteLine("\tTerminalAuthenticationInfo present");
                            TerminalAuthenticationInfo terminalAuthenticationInfo = Utils.DerDecode<TerminalAuthenticationInfo>(encoded);
                            break;

                        case KnownOids.id_icao_mrtd_security_EFDIR:
                            Console.WriteLine("\tEFDIRInfo present");
                            EFDIRInfo efDirInfo = Utils.DerDecode<EFDIRInfo>(encoded);
                            break;
                    }
                }
            }            
        }
    }
}
