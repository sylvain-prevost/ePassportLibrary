
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
    [ASN1Sequence(Name = "AttributeCertificateInfo", IsSet = false)]
    public class AttributeCertificateInfo : IASN1PreparedElement 
    {
        
        private AttCertVersion version_;
        
		[ASN1Element(Name = "version", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public AttCertVersion Version
        {
            get { return version_; }
            set { version_ = value;  }
        }
  
        private Holder holder_;
        
		[ASN1Element(Name = "holder", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public Holder Holder
        {
            get { return holder_; }
            set { holder_ = value;  }
        }
  
        private AttCertIssuer issuer_;
        
		[ASN1Element(Name = "issuer", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public AttCertIssuer Issuer
        {
            get { return issuer_; }
            set { issuer_ = value;  }
        }
  
        private AlgorithmIdentifier signature_;
        
		[ASN1Element(Name = "signature", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public AlgorithmIdentifier Signature
        {
            get { return signature_; }
            set { signature_ = value;  }
        }
  
        private CertificateSerialNumber serialNumber_;
        
		[ASN1Element(Name = "serialNumber", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public CertificateSerialNumber SerialNumber
        {
            get { return serialNumber_; }
            set { serialNumber_ = value;  }
        }
  
        private AttCertValidityPeriod attrCertValidityPeriod_;
        
		[ASN1Element(Name = "attrCertValidityPeriod", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public AttCertValidityPeriod AttrCertValidityPeriod
        {
            get { return attrCertValidityPeriod_; }
            set { attrCertValidityPeriod_ = value;  }
        }
  
        private System.Collections.Generic.ICollection<Attribute> attributes_;
        
		[ASN1SequenceOf(Name = "attributes", IsSetOf = false)]
    
		[ASN1Element(Name = "attributes", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public System.Collections.Generic.ICollection<Attribute> Attributes
        {
            get { return attributes_; }
            set { attributes_ = value;  }
        }
  
        private UniqueIdentifier issuerUniqueID_;
        
        private bool  issuerUniqueID_present = false;
        
		[ASN1Element(Name = "issuerUniqueID", IsOptional = true, HasTag = false, HasDefaultValue = false)]
        public UniqueIdentifier IssuerUniqueID
        {
            get { return issuerUniqueID_; }
            set { issuerUniqueID_ = value; issuerUniqueID_present = true;  }
        }
  
        private Extensions extensions_;
        
        private bool  extensions_present = false;
        
		[ASN1Element(Name = "extensions", IsOptional = true, HasTag = false, HasDefaultValue = false)]
        public Extensions Extensions
        {
            get { return extensions_; }
            set { extensions_ = value; extensions_present = true;  }
        }
  
        public bool isIssuerUniqueIDPresent()
        {
            return this.issuerUniqueID_present == true;
        }
        
        public bool isExtensionsPresent()
        {
            return this.extensions_present == true;
        }
        

        public void initWithDefaults() 
        {
            
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(AttributeCertificateInfo));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
