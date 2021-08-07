
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
    [ASN1Sequence(Name = "LDSSecurityObject", IsSet = false)]
    public class LDSSecurityObject : IASN1PreparedElement 
    {
        
        private LDSSecurityObjectVersion version_;
        
		[ASN1Element(Name = "version", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public LDSSecurityObjectVersion Version
        {
            get { return version_; }
            set { version_ = value;  }
        }
  
        private DigestAlgorithmIdentifier hashAlgorithm_;
        
		[ASN1Element(Name = "hashAlgorithm", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public DigestAlgorithmIdentifier HashAlgorithm
        {
            get { return hashAlgorithm_; }
            set { hashAlgorithm_ = value;  }
        }
  
        private System.Collections.Generic.ICollection<DataGroupHash> dataGroupHashValues_;
        
		[ASN1SequenceOf(Name = "dataGroupHashValues", IsSetOf = false)]
    
		[ASN1ValueRangeConstraint(Min = 2, Max = 16)]
		[ASN1Element(Name = "dataGroupHashValues", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public System.Collections.Generic.ICollection<DataGroupHash> DataGroupHashValues
        {
            get { return dataGroupHashValues_; }
            set { dataGroupHashValues_ = value;  }
        }
  
        private LDSVersionInfo ldsVersionInfo_;
        
        private bool  ldsVersionInfo_present = false;
        
		[ASN1Element(Name = "ldsVersionInfo", IsOptional = true, HasTag = false, HasDefaultValue = false)]
        public LDSVersionInfo LdsVersionInfo
        {
            get { return ldsVersionInfo_; }
            set { ldsVersionInfo_ = value; ldsVersionInfo_present = true;  }
        }
  
        public bool isLdsVersionInfoPresent()
        {
            return this.ldsVersionInfo_present == true;
        }
        

        public void initWithDefaults() 
        {
            
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(LDSSecurityObject));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}