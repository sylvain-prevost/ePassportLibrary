
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
    [ASN1Sequence(Name = "ChipAuthenticationInfo", IsSet = false)]
    public class ChipAuthenticationInfo : IASN1PreparedElement 
    {
        
        private ObjectIdentifier protocol_;
        [ASN1ObjectIdentifier( Name = "" )]
    
		[ASN1Element(Name = "protocol", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public ObjectIdentifier Protocol
        {
            get { return protocol_; }
            set { protocol_ = value;  }
        }
  
        private BigInteger version_;
        [ASN1Integer( Name = "" )]
    
		[ASN1Element(Name = "version", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public BigInteger Version
        {
            get { return version_; }
            set { version_ = value;  }
        }
  
        private BigInteger keyId_;
        
        private bool  keyId_present = false;
        [ASN1Integer( Name = "" )]
    
		[ASN1Element(Name = "keyId", IsOptional = true, HasTag = false, HasDefaultValue = false)]
        public BigInteger KeyId
        {
            get { return keyId_; }
            set { keyId_ = value; keyId_present = true;  }
        }
  
        public bool isKeyIdPresent()
        {
            return this.keyId_present == true;
        }
        

        public void initWithDefaults() 
        {
            
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(ChipAuthenticationInfo));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
