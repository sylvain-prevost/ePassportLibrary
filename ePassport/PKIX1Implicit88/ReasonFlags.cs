
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
    [ASN1BoxedType(Name = "ReasonFlags")]
    public class ReasonFlags : IASN1PreparedElement
    {
    
        private BitString val = null;

        [ASN1BitString(Name = "ReasonFlags")]
        
        public BitString Value
        {
            get { return val; }
            set { val = value; }
        }
        
        public ReasonFlags()
        {
        }

        public ReasonFlags(BitString value) 
        {
            this.Value = value;
        }

        public void initWithDefaults()
        {
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(ReasonFlags));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
