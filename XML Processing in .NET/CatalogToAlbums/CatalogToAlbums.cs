//Write a program, which(using XmlReader and XmlWriter) reads the file catalog.xml and creates
//the file album.xml, in which stores in appropriate way the names of all albums and their authors.

namespace CatalogToAlbums
{
    using System;
    using  System.Text;
    using System.Xml;

    class CatalogToAlbums
    {
        static void Main()
        {
            using (XmlTextWriter writer=new XmlTextWriter("../../albums.xml",Encoding.UTF8))
            {
                writer.Formatting=Formatting.Indented;
                writer.IndentChar = ' ';
                writer.Indentation = 2;
                writer.WriteStartDocument();
                writer.WriteStartElement("albums");

                using (XmlReader reader=XmlReader.Create("../../catalog.xml"))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name == "name")
                            {
                                writer.WriteStartElement("album");
                                writer.WriteStartElement("name",reader.ReadElementContentAsString());
                            }
                            else if (reader.Name == "artist")
                            {
                                writer.WriteElementString("artist", reader.ReadElementContentAsString());
                                writer.WriteEndElement();
                            }
                        }
                    }
                    writer.WriteEndDocument();
                }
                Console.WriteLine("Albums saved atb the file albums.xml");
            }
        }
    }
}
