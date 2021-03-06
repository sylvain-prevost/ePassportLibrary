
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
    [ASN1Sequence(Name = "RecipientEncryptedKey", IsSet = false)]
    public class RecipientEncryptedKey : IASN1PreparedElement 
    {
        
        private KeyAgreeRecipientIdentifier rid_;
        
		[ASN1Element(Name = "rid", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public KeyAgreeRecipientIdentifier Rid
        {
            get { return rid_; }
            set { rid_ = value;  }
        }
  
        private EncryptedKey encryptedKey_;
        
		[ASN1Element(Name = "encryptedKey", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public EncryptedKey EncryptedKey
        {
            get { return encryptedKey_; }
            set { encryptedKey_ = value;  }
        }
  

        public void initWithDefaults() 
        {
            
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(RecipientEncryptedKey));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
