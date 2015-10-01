//Using Visual Studio generate an XSD schema for the file catalog.xml.
//Write a C# program that takes an XML file and an XSD file (schema) and validates the XML file against the schema.
//Test it with valid XML catalogs and invalid XML catalogs.

namespace XsdSchamaCatalogue
{
    using System;
    using System.Xml.Linq;
    using System.Xml.Schema;

    class XsdSchamaCatalogue
    {
        static void Main()
        {
            var schema = new XmlSchemaSet();
            schema.Add(string.Empty, "../../catalog.xsd");
            XDocument correctDoc = XDocument.Load("../../catalog.xml");
            XDocument invalidDoc = XDocument.Load("../../invalidCaltalog.xml");

            ValidateXML(schema, correctDoc);
            ValidateXML(schema, invalidDoc);
        }

        private static void ValidateXML(XmlSchemaSet schema, XDocument correctDoc)
        {
            Console.WriteLine("Validating...");
            bool hasError = false;

            correctDoc.Validate(schema, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                hasError = true;
            });

            Console.WriteLine("XML document {0}", hasError ? "did not validate" : "validated");
            Console.WriteLine();
        }
    }
}
