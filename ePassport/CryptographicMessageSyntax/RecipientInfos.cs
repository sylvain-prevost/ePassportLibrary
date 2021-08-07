
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
    [ASN1BoxedType(Name = "RecipientInfos")]
    public class RecipientInfos : IASN1PreparedElement 
    {

        private System.Collections.Generic.ICollection<RecipientInfo> val = null; 
        
        
		[ASN1ValueRangeConstraint(Min = 1, Max = long.MaxValue)]
        [ASN1SequenceOf(Name = "RecipientInfos", IsSetOf = true)]

        public System.Collections.Generic.ICollection<RecipientInfo> Value
        {
            get { return val; }
            set { val = value; }
        }
        
        public void initValue() 
        {
            this.Value = new System.Collections.Generic.List<RecipientInfo>();
        }
        
        public void Add(RecipientInfo item) 
        {
            this.Value.Add(item);
        }

        public void initWithDefaults()
        {
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(RecipientInfos));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
