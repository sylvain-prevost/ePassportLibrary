
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
    [ASN1Sequence(Name = "IssuerAndSerialNumber", IsSet = false)]
    public class IssuerAndSerialNumber : IASN1PreparedElement 
    {
        
        private Name issuer_;
        
		[ASN1Element(Name = "issuer", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public Name Issuer
        {
            get { return issuer_; }
            set { issuer_ = value;  }
        }
  
        private CertificateSerialNumber serialNumber_;
        
		[ASN1Element(Name = "serialNumber", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public CertificateSerialNumber SerialNumber
        {
            get { return serialNumber_; }
            set { serialNumber_ = value;  }
        }
  

        public void initWithDefaults() 
        {
            
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(IssuerAndSerialNumber));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
