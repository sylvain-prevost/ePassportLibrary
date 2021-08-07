
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
    [ASN1Choice(Name = "KeyAgreeRecipientIdentifier")]
    public class KeyAgreeRecipientIdentifier : IASN1PreparedElement 
    {
        
        private IssuerAndSerialNumber issuerAndSerialNumber_;
        private bool  issuerAndSerialNumber_selected = false;

        
		[ASN1Element(Name = "issuerAndSerialNumber", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public IssuerAndSerialNumber IssuerAndSerialNumber
        {
            get { return issuerAndSerialNumber_; }
            set { selectIssuerAndSerialNumber(value); }
        }
  
        private RecipientKeyIdentifier rKeyId_;
        private bool  rKeyId_selected = false;

        
		[ASN1Element(Name = "rKeyId", IsOptional = false, HasTag = true, Tag = 0, HasDefaultValue = false)]
        public RecipientKeyIdentifier RKeyId
        {
            get { return rKeyId_; }
            set { selectRKeyId(value); }
        }
  
        public bool isIssuerAndSerialNumberSelected()
        {
            return this.issuerAndSerialNumber_selected;
        }

        

        public void selectIssuerAndSerialNumber (IssuerAndSerialNumber val) 
        {
            this.issuerAndSerialNumber_ = val;
            this.issuerAndSerialNumber_selected = true;
            
            this.rKeyId_selected = false;
            
        }
  
        public bool isRKeyIdSelected()
        {
            return this.rKeyId_selected;
        }

        

        public void selectRKeyId (RecipientKeyIdentifier val) 
        {
            this.rKeyId_ = val;
            this.rKeyId_selected = true;
            
            this.issuerAndSerialNumber_selected = false;
            
        }
  

        public void initWithDefaults()
        {
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(KeyAgreeRecipientIdentifier));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}