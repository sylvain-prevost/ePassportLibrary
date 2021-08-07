
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
    [ASN1Sequence(Name = "AAControls", IsSet = false)]
    public class AAControls : IASN1PreparedElement 
    {
        
        private long pathLenConstraint_;
        
        private bool  pathLenConstraint_present = false;
        [ASN1Integer( Name = "" )]
    
		[ASN1ValueRangeConstraint(Min = 0, Max = long.MaxValue)]
		[ASN1Element(Name = "pathLenConstraint", IsOptional = true, HasTag = false, HasDefaultValue = false)]
        public long PathLenConstraint
        {
            get { return pathLenConstraint_; }
            set { pathLenConstraint_ = value; pathLenConstraint_present = true;  }
        }
  
        private AttrSpec permittedAttrs_;
        
        private bool  permittedAttrs_present = false;
        
		[ASN1Element(Name = "permittedAttrs", IsOptional = true, HasTag = true, Tag = 0, HasDefaultValue = false)]
        public AttrSpec PermittedAttrs
        {
            get { return permittedAttrs_; }
            set { permittedAttrs_ = value; permittedAttrs_present = true;  }
        }
  
        private AttrSpec excludedAttrs_;
        
        private bool  excludedAttrs_present = false;
        
		[ASN1Element(Name = "excludedAttrs", IsOptional = true, HasTag = true, Tag = 1, HasDefaultValue = false)]
        public AttrSpec ExcludedAttrs
        {
            get { return excludedAttrs_; }
            set { excludedAttrs_ = value; excludedAttrs_present = true;  }
        }
  
        private bool permitUnSpecified_;
        [ASN1Boolean( Name = "" )]
    
		[ASN1Element(Name = "permitUnSpecified", IsOptional = false, HasTag = false, HasDefaultValue = true)]
        public bool PermitUnSpecified
        {
            get { return permitUnSpecified_; }
            set { permitUnSpecified_ = value;  }
        }
  
        public bool isPathLenConstraintPresent()
        {
            return this.pathLenConstraint_present == true;
        }
        
        public bool isPermittedAttrsPresent()
        {
            return this.permittedAttrs_present == true;
        }
        
        public bool isExcludedAttrsPresent()
        {
            return this.excludedAttrs_present == true;
        }
        

        public void initWithDefaults() 
        {
            bool param_PermitUnSpecified =         
            true;
        PermitUnSpecified = param_PermitUnSpecified;
    
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(AAControls));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
