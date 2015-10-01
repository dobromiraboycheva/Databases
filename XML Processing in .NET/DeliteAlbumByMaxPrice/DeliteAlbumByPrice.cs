//Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.

namespace DeliteAlbumByMaxPrice
{
    using System;
    using System.Xml;
    using System.Globalization;

    class DeliteAlbumByPrice
    {
        static void Main()
        {
            const double maxPrice = 20.0;

            var document = new XmlDocument();
            document.Load("../../catalog.xml");
            var root = document.DocumentElement;

            DeliteAlbumByMaxPrice(root, maxPrice);
            document.Save("../../newCatalog.xml");

            Console.WriteLine("The new catalogue with prices less then {0} was save in newCatalog.xml",maxPrice);
        }

        private static void DeliteAlbumByMaxPrice(XmlElement root, double maxPrice)
        {
            foreach (XmlElement album in root.ChildNodes)
            {
                string xmlPrice = album["price"].InnerText;
                double price = double.Parse(xmlPrice, CultureInfo.InvariantCulture);

                if (price > maxPrice)
                {
                    root.RemoveChild(album); 
                }
            }
        }
    }
}
