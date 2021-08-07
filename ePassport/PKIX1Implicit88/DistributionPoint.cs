
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
    [ASN1Sequence(Name = "DistributionPoint", IsSet = false)]
    public class DistributionPoint : IASN1PreparedElement 
    {
        
        private DistributionPointName distributionPointName_;
        
        private bool  distributionPointName_present = false;
        
		[ASN1Element(Name = "distributionPointName", IsOptional = true, HasTag = true, Tag = 0, HasDefaultValue = false)]
        public DistributionPointName DistributionPointName
        {
            get { return distributionPointName_; }
            set { distributionPointName_ = value; distributionPointName_present = true;  }
        }
  
        private ReasonFlags reasons_;
        
        private bool  reasons_present = false;
        
		[ASN1Element(Name = "reasons", IsOptional = true, HasTag = true, Tag = 1, HasDefaultValue = false)]
        public ReasonFlags Reasons
        {
            get { return reasons_; }
            set { reasons_ = value; reasons_present = true;  }
        }
  
        private GeneralNames cRLIssuer_;
        
        private bool  cRLIssuer_present = false;
        
		[ASN1Element(Name = "cRLIssuer", IsOptional = true, HasTag = true, Tag = 2, HasDefaultValue = false)]
        public GeneralNames CRLIssuer
        {
            get { return cRLIssuer_; }
            set { cRLIssuer_ = value; cRLIssuer_present = true;  }
        }
  
        public bool isDistributionPointNamePresent()
        {
            return this.distributionPointName_present == true;
        }
        
        public bool isReasonsPresent()
        {
            return this.reasons_present == true;
        }
        
        public bool isCRLIssuerPresent()
        {
            return this.cRLIssuer_present == true;
        }
        

        public void initWithDefaults() 
        {
            
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(DistributionPoint));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
