
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
    [ASN1Choice(Name = "DistributionPointName")]
    public class DistributionPointName : IASN1PreparedElement 
    {
        
        private GeneralNames fullName_;
        private bool  fullName_selected = false;

        
		[ASN1Element(Name = "fullName", IsOptional = false, HasTag = true, Tag = 0, HasDefaultValue = false)]
        public GeneralNames FullName
        {
            get { return fullName_; }
            set { selectFullName(value); }
        }
  
        private RelativeDistinguishedName nameRelativeToCRLIssuer_;
        private bool  nameRelativeToCRLIssuer_selected = false;

        
		[ASN1Element(Name = "nameRelativeToCRLIssuer", IsOptional = false, HasTag = true, Tag = 1, HasDefaultValue = false)]
        public RelativeDistinguishedName NameRelativeToCRLIssuer
        {
            get { return nameRelativeToCRLIssuer_; }
            set { selectNameRelativeToCRLIssuer(value); }
        }
  
        public bool isFullNameSelected()
        {
            return this.fullName_selected;
        }

        

        public void selectFullName (GeneralNames val) 
        {
            this.fullName_ = val;
            this.fullName_selected = true;
            
            this.nameRelativeToCRLIssuer_selected = false;
            
        }
  
        public bool isNameRelativeToCRLIssuerSelected()
        {
            return this.nameRelativeToCRLIssuer_selected;
        }

        

        public void selectNameRelativeToCRLIssuer (RelativeDistinguishedName val) 
        {
            this.nameRelativeToCRLIssuer_ = val;
            this.nameRelativeToCRLIssuer_selected = true;
            
            this.fullName_selected = false;
            
        }
  

        public void initWithDefaults()
        {
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(DistributionPointName));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}