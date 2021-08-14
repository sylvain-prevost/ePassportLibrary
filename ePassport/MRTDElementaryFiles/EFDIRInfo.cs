
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
    [ASN1Sequence(Name = "EFDIRInfo", IsSet = false)]
    public class EFDIRInfo : IASN1PreparedElement 
    {
        
        private ObjectIdentifier protocol_;
        [ASN1ObjectIdentifier( Name = "" )]
    
		[ASN1Element(Name = "protocol", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public ObjectIdentifier Protocol
        {
            get { return protocol_; }
            set { protocol_ = value;  }
        }
  
        private byte[] eFDIR_;
        [ASN1OctetString( Name = "" )]
    
		[ASN1Element(Name = "eFDIR", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public byte[] EFDIR
        {
            get { return eFDIR_; }
            set { eFDIR_ = value;  }
        }
  

        public void initWithDefaults() 
        {
            
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(EFDIRInfo));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}