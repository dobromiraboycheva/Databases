//Create a XML file representing catalogue.
//The catalogue should contain albums of different artists.
//For each album you should define: name, artist, year, producer, price and a list of songs.
//Each song should be described by title and duration.

namespace XMLParsers
{
    using System;
    using System.Xml.Xsl;

    class GenerateHTMLfromXML
    {
        static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../catalogue.xslt");
            xslt.Transform("../../catalogue.xml", "../../catalogue.html");
            Console.WriteLine("You generate catalogue.html");
        }
    }
}
