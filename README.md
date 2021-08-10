# ePassport Library

C# library leveraging [BinaryNotes.NET](https://github.com/sylvain-prevost/BinaryNotes.NET) to enable parsing/manipulation/encoding of MRTD security features (Passport certificates, picture/fingerprints Datagroups, etc).

<u>Example of use:</u>

```code

using (FileStream fs = File.Open(filename, FileMode.Open))
{
    byte[] data = new byte[fs.Length];
    fs.Read(data, 0, data.Length);

    ContentInfo contentInfo = Utils.DerDecode<ContentInfo>(data);

    KnownOids oid = Oids.ParseKnown(contentInfo.ContentType.Value.Value);
    if (oid == KnownOids.signedData)
    {
        SignedData signedData = Utils.DerDecode<SignedData>(contentInfo.Content);

        // check if SignedData contains a cscaMasterList object
        if (Oids.ParseKnown(signedData.EncapContentInfo.EContentType.Value.Value) == KnownOids.cscaMasterList)
        {
            // check the masterlist digest signature here
            // ....

            // now obtain the master list content
            CscaMasterList cscaMasterList = Utils.DerDecode<CscaMasterList>(signedData.EncapContentInfo.EContent);

            Console.WriteLine("number of certs present in cscaMasterList : " + cscaMasterList.CertList.Count);

            foreach (Certificate certificate in cscaMasterList.CertList)
            {
                // .. do stuff ..
            }
        }
    }

}

```

see [examples](examples/) folder for additional examples, including parsing and visualization of face & fingerprints.  


</br>
Output from examples.  
</br>
</br>
</br>

![Alt text](images/examples_output.jpg?raw=true "Title")

</br>
</br>


