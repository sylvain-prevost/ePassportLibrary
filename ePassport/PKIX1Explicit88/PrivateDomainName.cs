
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
    [ASN1Choice(Name = "PrivateDomainName")]
    public class PrivateDomainName : IASN1PreparedElement 
    {
        
        private string numeric_;
        private bool  numeric_selected = false;

        
		[ASN1String(Name = "", StringType = UniversalTags.NumericString, IsUCS = false)]
		[ASN1ValueRangeConstraint(Min = 1, Max = 16)]
		[ASN1Element(Name = "numeric", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public string Numeric
        {
            get { return numeric_; }
            set { selectNumeric(value); }
        }
  
        private string printable_;
        private bool  printable_selected = false;

        
		[ASN1String(Name = "", StringType = UniversalTags.PrintableString, IsUCS = false)]
		[ASN1ValueRangeConstraint(Min = 1, Max = 16)]
		[ASN1Element(Name = "printable", IsOptional = false, HasTag = false, HasDefaultValue = false)]
        public string Printable
        {
            get { return printable_; }
            set { selectPrintable(value); }
        }
  
        public bool isNumericSelected()
        {
            return this.numeric_selected;
        }

        

        public void selectNumeric (string val) 
        {
            this.numeric_ = val;
            this.numeric_selected = true;
            
            this.printable_selected = false;
            
        }
  
        public bool isPrintableSelected()
        {
            return this.printable_selected;
        }

        

        public void selectPrintable (string val) 
        {
            this.printable_ = val;
            this.printable_selected = true;
            
            this.numeric_selected = false;
            
        }
  

        public void initWithDefaults()
        {
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(typeof(PrivateDomainName));
        public IASN1PreparedElementData PreparedData 
        {
            get { return preparedData; }
        }

    }
            
}
