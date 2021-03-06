
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
    [ASN1Sequence(Name = "V2Form", IsSet = false)]
    public class V2Form : IASN1PreparedElement 
    {
        
        private GeneralNames issuerName_;
        
        private bool  issuerName_present = false;
        
		[ASN1Element(Name = "issuerName", IsOptional = true, HasTag = false, HasDefaultValue = false)]
        public GeneralNames IssuerName
        {
            get { return issuerName_; }
            set { issuerName_ = value; issuerName_present = true;  }
        }
  
        private IssuerSerial baseCertificateID_;
        
        private bool  baseCertificateID_present = false;
        
		[ASN1Element(Name = "baseCertificateID", IsOptional = true, HasTag = true, Tag = 0, HasDefaultValue = false)]
        public IssuerSerial BaseCertificateID
        {
            get { return baseCertificateID_; }
            set { baseCertificateID_ = value; baseCertificateID_present = true;  }
        }
  
        private ObjectDigestInfo objectDigestInfo_;
        
        private bool  objectDigestInfo_present = false;
        
		[ASN1Element(Name = "objectDigestInfo", IsOptional = true, HasTag = true, Tag = 1, HasDefaultValue = false)]
        public ObjectDigestInfo ObjectDigestInfo
        {
            get { return objectDigestInfo_; }
            set { objectDigestInfo_ = value; objectDigestInfo_present = true;  }
        }
  
        public bool isIssuerNamePresent()
        {
            return this.issuerName_present == true;
        }
        
        public bool isBaseCertificateIDPresent()
        {
            return this.baseCertificateID_present == true;
        }
        
        public bool isObjectDigestInfoPresent()
        {
            return this.objectDigestInfo_present == true;
        }
        

        public void initWithDefaults() 
        {
            
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(V2Form));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
