
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
    [ASN1BoxedType(Name = "CRLNumber")]
    public class CRLNumber: IASN1PreparedElement 
    {
    
        private long val;
        
        [ASN1Integer(Name = "CRLNumber")]
        
		[ASN1ValueRangeConstraint(Min = 0, Max = long.MaxValue)]
        public long Value
        {
            get { return val; }
            set { val = value; }
        }
        
        public CRLNumber()
        {
        }

        public CRLNumber(long value)
        {
            this.Value = value;
        }

        public void initWithDefaults()
        {
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(CRLNumber));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
