
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
    [ASN1Sequence(Name = "RSAES_OAEP_params", IsSet = false)]
    public class RSAES_OAEP_params : IASN1PreparedElement 
    {
        
        private AlgorithmIdentifier hashFunc_;
        
        private bool  hashFunc_present = false;
        
		[ASN1Element(Name = "hashFunc", IsOptional = true, HasTag = true, Tag = 0, IsImplicitTag = false, HasDefaultValue = false)]
        public AlgorithmIdentifier HashFunc
        {
            get { return hashFunc_; }
            set { hashFunc_ = value; hashFunc_present = true;  }
        }
  
        private AlgorithmIdentifier maskGenFunc_;
        
        private bool  maskGenFunc_present = false;
        
		[ASN1Element(Name = "maskGenFunc", IsOptional = true, HasTag = true, Tag = 1, IsImplicitTag = false, HasDefaultValue = false)]
        public AlgorithmIdentifier MaskGenFunc
        {
            get { return maskGenFunc_; }
            set { maskGenFunc_ = value; maskGenFunc_present = true;  }
        }
  
        private AlgorithmIdentifier pSourceFunc_;
        
        private bool  pSourceFunc_present = false;
        
		[ASN1Element(Name = "pSourceFunc", IsOptional = true, HasTag = true, Tag = 2, IsImplicitTag = false, HasDefaultValue = false)]
        public AlgorithmIdentifier PSourceFunc
        {
            get { return pSourceFunc_; }
            set { pSourceFunc_ = value; pSourceFunc_present = true;  }
        }
  
        public bool isHashFuncPresent()
        {
            return this.hashFunc_present == true;
        }
        
        public bool isMaskGenFuncPresent()
        {
            return this.maskGenFunc_present == true;
        }
        
        public bool isPSourceFuncPresent()
        {
            return this.pSourceFunc_present == true;
        }
        

        public void initWithDefaults() 
        {
            
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(RSAES_OAEP_params));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
