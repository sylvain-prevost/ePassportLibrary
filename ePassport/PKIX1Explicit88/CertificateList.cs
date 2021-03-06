
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
    [ASN1Sequence(Name = "CertificateList", IsSet = false)]
    public class CertificateList : IASN1PreparedElement 
    {
        
        private TBSCertList tbsCertList_;
        
		[ASN1Element(Name = "tbsCertList", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public TBSCertList TbsCertList
        {
            get { return tbsCertList_; }
            set { tbsCertList_ = value;  }
        }
  
        private AlgorithmIdentifier signatureAlgorithm_;
        
		[ASN1Element(Name = "signatureAlgorithm", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public AlgorithmIdentifier SignatureAlgorithm
        {
            get { return signatureAlgorithm_; }
            set { signatureAlgorithm_ = value;  }
        }
  
        private BitString signature_;
        [ASN1BitString( Name = "" )]
    
		[ASN1Element(Name = "signature", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public BitString Signature
        {
            get { return signature_; }
            set { signature_ = value;  }
        }
  

        public void initWithDefaults() 
        {
            
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(CertificateList));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
