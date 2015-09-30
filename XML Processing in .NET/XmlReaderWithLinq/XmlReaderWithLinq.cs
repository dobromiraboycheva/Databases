//Write a program, which using  LINQ query extracts all song titles from catalog.xml.

namespace XmlReaderWithLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    class XmlReaderWithLinq
    {
        static void Main()
        {
            var document = XDocument.Load("../../catalogue.xml");
            var albums = document.Element("catalogue").Elements("album");
            var titles = from title in albums.Descendants("title") select title.Value;

            foreach (var title in titles)
            {
                Console.WriteLine("* " + title + " *");
            }
        }
    }
}
