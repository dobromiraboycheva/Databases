//In a text file we are given the name, address and phone number of given person(each at a single line).
//Write a program, which creates new XML document, which contains these data in structured XML format.

namespace TxtToXml
{
    using  System;
    using  System.IO;
    using  System.Xml.Linq;

    class TxtToXml
    {
        static void Main()
        {
            Person person = new Person();

            using (StreamReader reader=new StreamReader("../../person.txt"))
            {
                person.Name = reader.ReadLine();
                person.PhoneNumber = reader.ReadLine();
                person.Address = reader.ReadLine();
            }

            XElement persopnXmlElement = new XElement("person",
                new XElement("name", person.Name),
                new XElement("phoneNumber", person.PhoneNumber),
                new XElement("address", person.Address));

            persopnXmlElement.Save("../../person.xml");

            Console.WriteLine("Persone saved at file person.xml");
        }
    }
}
