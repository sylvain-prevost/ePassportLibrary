
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
    [ASN1BoxedType(Name = "TerminalType")]
    public class TerminalType: IASN1PreparedElement 
    {
    
        private BigInteger val;
        
        [ASN1Integer(Name = "TerminalType")]
        
        public BigInteger Value
        {
            get { return val; }
            set { val = value; }
        }
        
        public TerminalType()
        {
        }

        public TerminalType(BigInteger value)
        {
            this.Value = value;
        }

        public void initWithDefaults()
        {
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(TerminalType));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
