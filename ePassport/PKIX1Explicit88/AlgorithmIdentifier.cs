
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
    [ASN1Sequence(Name = "AlgorithmIdentifier", IsSet = false)]
    public class AlgorithmIdentifier : IASN1PreparedElement 
    {
        
        private ObjectIdentifier algorithm_;
        [ASN1ObjectIdentifier( Name = "" )]
    
		[ASN1Element(Name = "algorithm", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public ObjectIdentifier Algorithm
        {
            get { return algorithm_; }
            set { algorithm_ = value;  }
        }
  
        private byte[] parameters_;
        
        private bool  parameters_present = false;
        [ASN1Any( Name = "" )]
    
		[ASN1Element(Name = "parameters", IsOptional = true, HasTag = false, HasDefaultValue = false)]
        public byte[] Parameters
        {
            get { return parameters_; }
            set { parameters_ = value; parameters_present = true;  }
        }
  
        public bool isParametersPresent()
        {
            return this.parameters_present == true;
        }
        

        public void initWithDefaults() 
        {
            
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(AlgorithmIdentifier));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
