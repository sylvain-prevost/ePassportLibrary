
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
    [ASN1Choice(Name = "RevocationInfoChoice")]
    public class RevocationInfoChoice : IASN1PreparedElement 
    {
        
        private CertificateList crl_;
        private bool  crl_selected = false;

        
		[ASN1Element(Name = "crl", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public CertificateList Crl
        {
            get { return crl_; }
            set { selectCrl(value); }
        }
  
        private OtherRevocationInfoFormat other_;
        private bool  other_selected = false;

        
		[ASN1Element(Name = "other", IsOptional = false, HasTag = true, Tag = 1, HasDefaultValue = false)]
        public OtherRevocationInfoFormat Other
        {
            get { return other_; }
            set { selectOther(value); }
        }
  
        public bool isCrlSelected()
        {
            return this.crl_selected;
        }

        

        public void selectCrl (CertificateList val) 
        {
            this.crl_ = val;
            this.crl_selected = true;
            
            this.other_selected = false;
            
        }
  
        public bool isOtherSelected()
        {
            return this.other_selected;
        }

        

        public void selectOther (OtherRevocationInfoFormat val) 
        {
            this.other_ = val;
            this.other_selected = true;
            
            this.crl_selected = false;
            
        }
  

        public void initWithDefaults()
        {
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(RevocationInfoChoice));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}