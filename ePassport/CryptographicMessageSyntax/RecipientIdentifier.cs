
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
    [ASN1Choice(Name = "RecipientIdentifier")]
    public class RecipientIdentifier : IASN1PreparedElement 
    {
        
        private IssuerAndSerialNumber issuerAndSerialNumber_;
        private bool  issuerAndSerialNumber_selected = false;

        
		[ASN1Element(Name = "issuerAndSerialNumber", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public IssuerAndSerialNumber IssuerAndSerialNumber
        {
            get { return issuerAndSerialNumber_; }
            set { selectIssuerAndSerialNumber(value); }
        }
  
        private SubjectKeyIdentifier subjectKeyIdentifier_;
        private bool  subjectKeyIdentifier_selected = false;

        
		[ASN1Element(Name = "subjectKeyIdentifier", IsOptional = false, HasTag = true, Tag = 0, HasDefaultValue = false)]
        public SubjectKeyIdentifier SubjectKeyIdentifier
        {
            get { return subjectKeyIdentifier_; }
            set { selectSubjectKeyIdentifier(value); }
        }
  
        public bool isIssuerAndSerialNumberSelected()
        {
            return this.issuerAndSerialNumber_selected;
        }

        

        public void selectIssuerAndSerialNumber (IssuerAndSerialNumber val) 
        {
            this.issuerAndSerialNumber_ = val;
            this.issuerAndSerialNumber_selected = true;
            
            this.subjectKeyIdentifier_selected = false;
            
        }
  
        public bool isSubjectKeyIdentifierSelected()
        {
            return this.subjectKeyIdentifier_selected;
        }

        

        public void selectSubjectKeyIdentifier (SubjectKeyIdentifier val) 
        {
            this.subjectKeyIdentifier_ = val;
            this.subjectKeyIdentifier_selected = true;
            
            this.issuerAndSerialNumber_selected = false;
            
        }
  

        public void initWithDefaults()
        {
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(RecipientIdentifier));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
