
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
    [ASN1Choice(Name = "AttCertIssuer")]
    public class AttCertIssuer : IASN1PreparedElement 
    {
        
        private GeneralNames v1Form_;
        private bool  v1Form_selected = false;

        
		[ASN1Element(Name = "v1Form", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public GeneralNames V1Form
        {
            get { return v1Form_; }
            set { selectV1Form(value); }
        }
  
        private V2Form v2Form_;
        private bool  v2Form_selected = false;

        
		[ASN1Element(Name = "v2Form", IsOptional = false, HasTag = true, Tag = 0, HasDefaultValue = false)]
        public V2Form V2Form
        {
            get { return v2Form_; }
            set { selectV2Form(value); }
        }
  
        public bool isV1FormSelected()
        {
            return this.v1Form_selected;
        }

        

        public void selectV1Form (GeneralNames val) 
        {
            this.v1Form_ = val;
            this.v1Form_selected = true;
            
            this.v2Form_selected = false;
            
        }
  
        public bool isV2FormSelected()
        {
            return this.v2Form_selected;
        }

        

        public void selectV2Form (V2Form val) 
        {
            this.v2Form_ = val;
            this.v2Form_selected = true;
            
            this.v1Form_selected = false;
            
        }
  

        public void initWithDefaults()
        {
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(AttCertIssuer));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
