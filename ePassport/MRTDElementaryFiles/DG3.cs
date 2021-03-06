
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
    [ASN1BoxedType(Name = "DG3")]
    public class DG3: IASN1PreparedElement 
    {

        private DG3SequenceType val;

        
    [ASN1PreparedElement]
    [ASN1Sequence(Name = "DG3", IsSet = false)]
    public class DG3SequenceType : IASN1PreparedElement
    {
        
        private BiometricInfoGroupTemplate biometricInfoGroupTemplate_;
        
		[ASN1Element(Name = "biometricInfoGroupTemplate", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public BiometricInfoGroupTemplate BiometricInfoGroupTemplate
        {
            get { return biometricInfoGroupTemplate_; }
            set { biometricInfoGroupTemplate_ = value;  }
        }
  
        
        public void initWithDefaults() 
        {
            
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(DG3SequenceType));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }
    }
                
		[ASN1Element(Name = "DG3", IsOptional = false, HasTag = true, Tag = 3, TagClass = TagClasses.Application, HasDefaultValue = false)]
        public DG3SequenceType Value
        {
            get { return val; }
            
            set { val = value; }
            
        }

        
        
        public DG3 ()
        {
        }

        public void initWithDefaults()
        {
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(DG3));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
