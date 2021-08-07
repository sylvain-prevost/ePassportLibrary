
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
    [ASN1Sequence(Name = "KEKRecipientInfo", IsSet = false)]
    public class KEKRecipientInfo : IASN1PreparedElement 
    {
        
        private CMSVersion version_;
        
		[ASN1Element(Name = "version", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public CMSVersion Version
        {
            get { return version_; }
            set { version_ = value;  }
        }
  
        private KEKIdentifier kekid_;
        
		[ASN1Element(Name = "kekid", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public KEKIdentifier Kekid
        {
            get { return kekid_; }
            set { kekid_ = value;  }
        }
  
        private KeyEncryptionAlgorithmIdentifier keyEncryptionAlgorithm_;
        
		[ASN1Element(Name = "keyEncryptionAlgorithm", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public KeyEncryptionAlgorithmIdentifier KeyEncryptionAlgorithm
        {
            get { return keyEncryptionAlgorithm_; }
            set { keyEncryptionAlgorithm_ = value;  }
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

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(KEKRecipientInfo));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
