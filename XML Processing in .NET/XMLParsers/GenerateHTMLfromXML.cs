//Create a XML file representing catalogue.
//The catalogue should contain albums of different artists.
//For each album you should define: name, artist, year, producer, price and a list of songs.
//Each song should be described by title and duration.

//Create an XSL stylesheet, which transforms the file catalog.xml into HTML document, formatted for viewing in a standard Web-browser.

//Write a C# program to apply the XSLT stylesheet transformation on the file catalog.xml using the class XslTransform.

namespace XMLParsers
{
    using System;
    using System.Xml.Xsl;

    class GenerateHTMLfromXML
    {
        static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../catalog.xslt");
            xslt.Transform("../../catalog.xml", "../../catalog.html");
            Console.WriteLine("You generate catalog.html");
        }
    }
}
