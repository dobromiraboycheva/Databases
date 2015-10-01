//Write a program, which extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier.
//Use XPath query.

using System;
using System.Xml;

namespace AlbumsSelectedByYear
{
    class AlbumsSelectedByYear
    {
        static void Main()
        {
            XmlDocument document = new XmlDocument();
            document.Load("../../catalog.xml");
            var query = "/catalog/album[year>2000]/name";

            var albums = document.SelectNodes(query);

            foreach (XmlNode album in albums)
            {
                Console.WriteLine("* "+album.InnerText+" *");
            }
        }
    }
}
