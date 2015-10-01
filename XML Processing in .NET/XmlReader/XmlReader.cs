//Write a program, which using XmlReader extracts all song titles from catalog.xml.

namespace XmlReader
{
    using System;
    using System.Xml;

    internal class XmlReaderProgram
    {
        private static void Main()
        {
            using (XmlReader reader = new XmlTextReader("../../catalog.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                    {
                        Console.WriteLine("* " +reader.ReadElementString() + " *");
                    }
                }
            }
        }
    }
}
