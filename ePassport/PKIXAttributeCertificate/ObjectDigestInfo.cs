
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
    [ASN1Sequence(Name = "ObjectDigestInfo", IsSet = false)]
    public class ObjectDigestInfo : IASN1PreparedElement 
    {
        
        private DigestedObjectTypeEnumType digestedObjectType_;
        


    [ASN1PreparedElement]
    [ASN1Enum(Name = "DigestedObjectTypeEnumType")]
    public class DigestedObjectTypeEnumType : IASN1PreparedElement 
    {
        public enum EnumType 
        {
            
            [ASN1EnumItem ( Name = "publicKey", HasTag = true , Tag = 0 )]
            publicKey , 
            [ASN1EnumItem ( Name = "publicKeyCert", HasTag = true , Tag = 1 )]
            publicKeyCert , 
            [ASN1EnumItem ( Name = "otherObjectTypes", HasTag = true , Tag = 2 )]
            otherObjectTypes
        }
        
        private EnumType val;
        
        public EnumType Value
        {
            get { return val; }
            set { val = value; }
        }

        public void initWithDefaults()
        {
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(DigestedObjectTypeEnumType));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }

                
		[ASN1Element(Name = "digestedObjectType", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public DigestedObjectTypeEnumType DigestedObjectType
        {
            get { return digestedObjectType_; }
            set { digestedObjectType_ = value;  }
        }
  
        private ObjectIdentifier otherObjectTypeID_;
        
        private bool  otherObjectTypeID_present = false;
        [ASN1ObjectIdentifier( Name = "" )]
    
		[ASN1Element(Name = "otherObjectTypeID", IsOptional = true, HasTag = false, HasDefaultValue = false)]
        public ObjectIdentifier OtherObjectTypeID
        {
            get { return otherObjectTypeID_; }
            set { otherObjectTypeID_ = value; otherObjectTypeID_present = true;  }
        }
  
        private AlgorithmIdentifier digestAlgorithm_;
        
		[ASN1Element(Name = "digestAlgorithm", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public AlgorithmIdentifier DigestAlgorithm
        {
            get { return digestAlgorithm_; }
            set { digestAlgorithm_ = value;  }
        }
  
        private BitString objectDigest_;
        [ASN1BitString( Name = "" )]
    
		[ASN1Element(Name = "objectDigest", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public BitString ObjectDigest
        {
            get { return objectDigest_; }
            set { objectDigest_ = value;  }
        }
  
        public bool isOtherObjectTypeIDPresent()
        {
            return this.otherObjectTypeID_present == true;
        }
        

        public void initWithDefaults() 
        {
            
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(ObjectDigestInfo));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
