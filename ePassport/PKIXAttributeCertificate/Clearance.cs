
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
    [ASN1Sequence(Name = "Clearance", IsSet = false)]
    public class Clearance : IASN1PreparedElement 
    {
        
        private ObjectIdentifier policyId_;
        [ASN1ObjectIdentifier( Name = "" )]
    
		[ASN1Element(Name = "policyId", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public ObjectIdentifier PolicyId
        {
            get { return policyId_; }
            set { policyId_ = value;  }
        }
  
        private ClassList classList_;
        
        private bool  classList_present = false;
        
		[ASN1Element(Name = "classList", IsOptional = true, HasTag = false, HasDefaultValue = false)]
        public ClassList ClassList
        {
            get { return classList_; }
            set { classList_ = value; classList_present = true;  }
        }
  
        private System.Collections.Generic.ICollection<SecurityCategory> securityCategories_;
        
        private bool  securityCategories_present = false;
        
		[ASN1SequenceOf(Name = "securityCategories", IsSetOf = true)]
    
		[ASN1Element(Name = "securityCategories", IsOptional = true, HasTag = false, HasDefaultValue = false)]
        public System.Collections.Generic.ICollection<SecurityCategory> SecurityCategories
        {
            get { return securityCategories_; }
            set { securityCategories_ = value; securityCategories_present = true;  }
        }
  
        public bool isClassListPresent()
        {
            return this.classList_present == true;
        }
        
        public bool isSecurityCategoriesPresent()
        {
            return this.securityCategories_present == true;
        }
        

        public void initWithDefaults() 
        {
            
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(Clearance));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
