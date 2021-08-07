
//
// This file was generated by the BinaryNotes compiler (created by Abdulla Abdurakhmanov, modified by Sylvain Prevost).
// See http://bnotes.sourceforge.net 
// Any modifications to this file will be lost upon recompilation of the source ASN.1. 
//

using System;
using System.Numerics;

using org.bn.attributes;
using org.bn.attributes.constraints;
using org.bn.coders;
using org.bn.types;
using org.bn;

namespace ePassport {


    [ASN1PreparedElement]
    [ASN1Sequence(Name = "ExtendedCertificate", IsSet = false)]
    public class ExtendedCertificate : IASN1PreparedElement 
    {
        
        private ExtendedCertificateInfo extendedCertificateInfo_;
        
		[ASN1Element(Name = "extendedCertificateInfo", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public ExtendedCertificateInfo ExtendedCertificateInfo
        {
            get { return extendedCertificateInfo_; }
            set { extendedCertificateInfo_ = value;  }
        }
  
        private SignatureAlgorithmIdentifier signatureAlgorithm_;
        
		[ASN1Element(Name = "signatureAlgorithm", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public SignatureAlgorithmIdentifier SignatureAlgorithm
        {
            get { return signatureAlgorithm_; }
            set { signatureAlgorithm_ = value;  }
        }
  
        private Signature signature_;
        
		[ASN1Element(Name = "signature", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public Signature Signature
        {
            get { return signature_; }
            set { signature_ = value;  }
        }
  

        public void initWithDefaults() 
        {
            
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(ExtendedCertificate));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
