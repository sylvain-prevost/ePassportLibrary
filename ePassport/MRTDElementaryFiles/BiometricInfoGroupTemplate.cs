
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
    [ASN1BoxedType(Name = "BiometricInfoGroupTemplate")]
    public class BiometricInfoGroupTemplate: IASN1PreparedElement 
    {

        private BiometricInfoGroupTemplateSequenceType val;

        
    [ASN1PreparedElement]
    [ASN1Sequence(Name = "BiometricInfoGroupTemplate", IsSet = false)]
    public class BiometricInfoGroupTemplateSequenceType : IASN1PreparedElement
    {
        
        private BigInteger numberOfInstances_;
        [ASN1Integer( Name = "" )]
    
		[ASN1Element(Name = "numberOfInstances", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public BigInteger NumberOfInstances
        {
            get { return numberOfInstances_; }
            set { numberOfInstances_ = value;  }
        }
  
        private byte[] biometricInfoTemplate_;
        [ASN1Any( Name = "" )]
    
		[ASN1Element(Name = "biometricInfoTemplate", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public byte[] BiometricInfoTemplate
        {
            get { return biometricInfoTemplate_; }
            set { biometricInfoTemplate_ = value;  }
        }
  
        
        public void initWithDefaults() 
        {
            
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(BiometricInfoGroupTemplateSequenceType));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }
    }
                
		[ASN1Element(Name = "BiometricInfoGroupTemplate", IsOptional = false, HasTag = true, Tag = 97, TagClass = TagClasses.Application, HasDefaultValue = false)]
        public BiometricInfoGroupTemplateSequenceType Value
        {
            get { return val; }
            
            set { val = value; }
            
        }

        
        
        public BiometricInfoGroupTemplate ()
        {
        }

        public void initWithDefaults()
        {
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(BiometricInfoGroupTemplate));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
