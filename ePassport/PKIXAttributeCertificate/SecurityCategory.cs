
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
    [ASN1Sequence(Name = "SecurityCategory", IsSet = false)]
    public class SecurityCategory : IASN1PreparedElement 
    {
        
        private ObjectIdentifier type_;
        [ASN1ObjectIdentifier( Name = "" )]
    
		[ASN1Element(Name = "type", IsOptional = false, HasTag = true, Tag = 0, HasDefaultValue = false)]
        public ObjectIdentifier Type
        {
            get { return type_; }
            set { type_ = value;  }
        }
  
        private byte[] value_;
        [ASN1Any( Name = "" )]
    
		[ASN1Element(Name = "value", IsOptional = false, HasTag = true, Tag = 1, IsImplicitTag = false, HasDefaultValue = false)]
        public byte[] Value
        {
            get { return value_; }
            set { value_ = value;  }
        }
  

        public void initWithDefaults() 
        {
            
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(SecurityCategory));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
