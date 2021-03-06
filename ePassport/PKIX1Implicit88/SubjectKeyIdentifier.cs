
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
    [ASN1BoxedType(Name = "SubjectKeyIdentifier")]
    public class SubjectKeyIdentifier: IASN1PreparedElement 
    {

        private KeyIdentifier val;

        
		[ASN1Element(Name = "SubjectKeyIdentifier", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public KeyIdentifier Value
        {
            get { return val; }
            
            set { val = value; }
            
        }

        
        
        public SubjectKeyIdentifier ()
        {
        }

        public void initWithDefaults()
        {
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(SubjectKeyIdentifier));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
