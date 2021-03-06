
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
    [ASN1Sequence(Name = "IssuerSerial", IsSet = false)]
    public class IssuerSerial : IASN1PreparedElement 
    {
        
        private GeneralNames issuer_;
        
		[ASN1Element(Name = "issuer", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public GeneralNames Issuer
        {
            get { return issuer_; }
            set { issuer_ = value;  }
        }
  
        private CertificateSerialNumber serial_;
        
		[ASN1Element(Name = "serial", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public CertificateSerialNumber Serial
        {
            get { return serial_; }
            set { serial_ = value;  }
        }
  
        private UniqueIdentifier issuerUID_;
        
        private bool  issuerUID_present = false;
        
		[ASN1Element(Name = "issuerUID", IsOptional = true, HasTag = false, HasDefaultValue = false)]
        public UniqueIdentifier IssuerUID
        {
            get { return issuerUID_; }
            set { issuerUID_ = value; issuerUID_present = true;  }
        }
  
        public bool isIssuerUIDPresent()
        {
            return this.issuerUID_present == true;
        }
        

        public void initWithDefaults() 
        {
            
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(IssuerSerial));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
