//Write program that extracts all different artists which are found in the catalog.xml.
//For each author you should print the number of albums in the catalogue.
//Use the DOM parser and a hash-table.

namespace DomParserOfArtists
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class DomParserOfArtists
    {
        static void Main()
        {
            var document = new XmlDocument();
            document.Load("../../catalogue.xml");
            var root = document.DocumentElement;

            foreach (var autorInfo in GetArtistsFromXML(root))
            {
                if (autorInfo.Value == 1)
                {
                    Console.WriteLine("{0} -> {1} album in the catalogue", autorInfo.Key, autorInfo.Value);
                }
                else
                {
                    Console.WriteLine("{0} -> {1} albums in the catalogue", autorInfo.Key, autorInfo.Value);
                }
              
            }
        }

        private static Dictionary<string, int> GetArtistsFromXML(XmlElement root)
        {
            var artistsAlbums = new Dictionary<string, int>();
            var artists = root.GetElementsByTagName("artist");

            foreach (XmlElement artist in artists)
            {
                var artistName = artist.InnerText;

                if (artistsAlbums.ContainsKey(artistName))
                {
                    artistsAlbums[artistName] ++;
                }
                else
                {
                    artistsAlbums.Add(artistName, 1);
                }
            }

            return artistsAlbums;
        }
    }
}