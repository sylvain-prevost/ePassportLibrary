
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
    [ASN1BoxedType(Name = "ExtensionAttributes")]
    public class ExtensionAttributes : IASN1PreparedElement 
    {

        private System.Collections.Generic.ICollection<ExtensionAttribute> val = null; 
        
        
		[ASN1ValueRangeConstraint(Min = 1, Max = 256)]
        [ASN1SequenceOf(Name = "ExtensionAttributes", IsSetOf = true)]

        public System.Collections.Generic.ICollection<ExtensionAttribute> Value
        {
            get { return val; }
            set { val = value; }
        }
        
        public void initValue() 
        {
            this.Value = new System.Collections.Generic.List<ExtensionAttribute>();
        }
        
        public void Add(ExtensionAttribute item) 
        {
            this.Value.Add(item);
        }

        public void initWithDefaults()
        {
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(ExtensionAttributes));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}