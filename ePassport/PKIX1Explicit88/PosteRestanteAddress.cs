
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
    [ASN1BoxedType(Name = "PosteRestanteAddress")]
    public class PosteRestanteAddress: IASN1PreparedElement 
    {

        private PDSParameter val;

        
		[ASN1Element(Name = "PosteRestanteAddress", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public PDSParameter Value
        {
            get { return val; }
            
            set { val = value; }
            
        }

        
        
        public PosteRestanteAddress ()
        {
        }

        public void initWithDefaults()
        {
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(PosteRestanteAddress));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
