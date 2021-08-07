
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
    [ASN1Enum ( Name = "CRLReason")]
    public class CRLReason : IASN1PreparedElement 
    {
        public enum EnumType 
        {
            
            [ASN1EnumItem ( Name = "unspecified", HasTag = true , Tag = 0 )]
            unspecified , 
            [ASN1EnumItem ( Name = "keyCompromise", HasTag = true , Tag = 1 )]
            keyCompromise , 
            [ASN1EnumItem ( Name = "cACompromise", HasTag = true , Tag = 2 )]
            cACompromise , 
            [ASN1EnumItem ( Name = "affiliationChanged", HasTag = true , Tag = 3 )]
            affiliationChanged , 
            [ASN1EnumItem ( Name = "superseded", HasTag = true , Tag = 4 )]
            superseded , 
            [ASN1EnumItem ( Name = "cessationOfOperation", HasTag = true , Tag = 5 )]
            cessationOfOperation , 
            [ASN1EnumItem ( Name = "certificateHold", HasTag = true , Tag = 6 )]
            certificateHold , 
            [ASN1EnumItem ( Name = "removeFromCRL", HasTag = true , Tag = 8 )]
            removeFromCRL , 
            [ASN1EnumItem ( Name = "privilegeWithdrawn", HasTag = true , Tag = 9 )]
            privilegeWithdrawn , 
            [ASN1EnumItem ( Name = "aACompromise", HasTag = true , Tag = 10 )]
            aACompromise
        }
        
        private EnumType val;
        
        public EnumType Value
        {
            get { return val; }
            set { val = value; }
        }

        public void initWithDefaults()
        {
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(CRLReason));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
