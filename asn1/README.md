
## set of asn.1 modules modified to be compatible with asn1c & BinaryNotes compilers

</br>
</br>
<u>Step 1 : Check the validity of the asn.1 modules (optional, but strongly recommended)</u>  
</br>
</br>

> asn1c compiler => used to validate the asn.1 files  
> https://github.com/vlm/asn1c  
  
`````code
asn1c -EF PKIX1Explicit88.asn PKIX1Implicit88.asn PKIXAttributeCertificate.asn AttributeCertificateVersion1.asn CryptographicMessageSyntaxAlgorithms.asn CryptographicMessageSyntax.asn CscaMasterList.asn LDSSecurityObjectV1.asn MRTDBioDatagroups.asn  
`````

Note: The parsed asn.1 should be output to the console without any error.  

</br>
</br>
<u>Step 2 : generate the C# classes</u>  
</br>
</br>


> BinaryNotes => used to generate the C# classes  
> https://github.com/sylvain-prevost/BinaryNotes  

`````code
call [path_to(bncompiler)]\bnc.cmd -mp [path_to(cs_xsl_modules)] -o .\PKIX1Explicit88 -ns ePassport -f PKIX1Explicit88.asn
call [path_to(bncompiler)]\bnc.cmd -mp [path_to(cs_xsl_modules)] -o .\PKIX1Implicit88 -ns ePassport -f PKIX1Implicit88.asn
call [path_to(bncompiler)]\bnc.cmd -mp [path_to(cs_xsl_modules)] -o .\PKIXAttributeCertificate -ns ePassport -f PKIXAttributeCertificate.asn
call [path_to(bncompiler)]\bnc.cmd -mp [path_to(cs_xsl_modules)] -o .\AttributeCertificateVersion1 -ns ePassport -f AttributeCertificateVersion1.asn
call [path_to(bncompiler)]\bnc.cmd -mp [path_to(cs_xsl_modules)] -o .\CryptographicMessageSyntaxAlgorithms -ns ePassport -f CryptographicMessageSyntaxAlgorithms.asn
call [path_to(bncompiler)]\bnc.cmd -mp [path_to(cs_xsl_modules)] -o .\CryptographicMessageSyntax -ns ePassport -f CryptographicMessageSyntax.asn
call [path_to(bncompiler)]\bnc.cmd -mp [path_to(cs_xsl_modules)] -o .\CscaMasterList -ns ePassport -f CscaMasterList.asn
call [path_to(bncompiler)]\bnc.cmd -mp [path_to(cs_xsl_modules)] -o .\LDSSecurityObjectV1 -ns ePassport -f LDSSecurityObjectV1.asn
call [path_to(bncompiler)]\bnc.cmd -mp [path_to(cs_xsl_modules)] -o .\MRTDBioDatagroups -ns ePassport -f MRTDBioDatagroups.asn
`````

Note: when running binarynotes compiler, there are multiple ('Value not defined  org.bn.compiler.parser.model.AsnObjectIdentifier') messages that will appear.  
It is not nice, but expected.  




