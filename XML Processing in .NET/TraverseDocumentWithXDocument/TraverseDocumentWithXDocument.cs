//Write a program to traverse given directory and write to a XML file its contents together with all subdirectories and files.
//Use tags<file> and<dir> with appropriate attributes.
//using XDocument, XElement and XAttribute.

namespace TraverseDocumentWithXDocument
{
    using System;
    using System.IO;
    using System.Xml.Linq;

    class TraverseDocumentWithXDocument
    {
        static void Main()
        {
            var desktop = Traverse(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            desktop.Save("../../dir.xml");
            Console.WriteLine("Result saved at the file dir.xml");
        }

        static XElement Traverse(string dir)
        {
            var element = new XElement("dir", new XAttribute("path", dir));

            foreach (var directory in Directory.GetDirectories(dir))
            {
                element.Add(Traverse(directory));
            }

            foreach (var file in Directory.GetFiles(dir))
            {
                element.Add(new XElement("file",
                    new XAttribute("name", Path.GetFileNameWithoutExtension(file)),
                    new XAttribute("ext", Path.GetExtension(file))));
            }

            return element;
        }
    }
}