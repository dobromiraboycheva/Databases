//Write a program, which extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier.
//Rewrite the previous using LINQ query.

namespace AlbumSelectedByYearLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    class AlbumSelectedByYearLinq
    {
        static void Main()
        {
            var doc = XDocument.Load("../../catalog.xml");

            var albums = from album in doc.Descendants("album")
                             where int.Parse(album.Element("year").Value) > 1996
                             select album.Element("name").Value;

            foreach (var album in albums)
            {
                Console.WriteLine("* "+album+" *")  ;
            }
        
        }
    }
}
