
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
    [ASN1BoxedType(Name = "DomainComponent")]
    public class DomainComponent: IASN1PreparedElement 
    {

        private String val;

        [ASN1String(Name = "DomainComponent", StringType = UniversalTags.IA5String, IsUCS = false)]
        
        public String Value
        {
            get { return val; }
            set { val = value; }
        }
        
        public DomainComponent() 
        {
        }

        public DomainComponent(String val) 
        {
            this.val = val;
        }

        public void initWithDefaults() 
        {
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(DomainComponent));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
