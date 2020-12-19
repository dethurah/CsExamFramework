using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace CsExam.Examples
{
    public class XMLToLINQExample
    {
        public static void LoadXml()
        {
            XElement purchaseOrder = XElement.Load("Examples\\6 - LINQ To XML\\PurchaseOrder.xml");
            Console.WriteLine("Printer hele xml-filen");
            Console.WriteLine(purchaseOrder);

            IEnumerable<string> partNos = purchaseOrder.Descendants("Item").Select(x => (string)x.Attribute("PartNumber"));
            Console.WriteLine("Printer alle \"items\" med PartNumber i PO");
            foreach (var item in partNos)
            {
                Console.WriteLine("The items are: {0}", item);
            }

            IEnumerable<string> partsName = purchaseOrder.Descendants("Item").Select(x => (string)x.Element("ProductName"));



            IEnumerable<XElement> dataFromSource2 = purchaseOrder.Descendants("Item")
                                                   .Where(item => ((string)item.Element("ProductName")).Contains("Baby"))
                                         .OrderBy(order => order.Element("PartNumber"));
            

            Console.WriteLine("Printer alle baby-items i PO");
            foreach (var item in dataFromSource2)
            {
                Console.WriteLine("The items are: {0}", item);
            }

            IEnumerable<XElement> pricesByPartNos = purchaseOrder.Descendants("Item")
                                        .Where(item => (int)item.Element("Quantity") * (decimal)item.Element("USPrice") > 78)
                                        .OrderBy(order => order.Element("PartNumber"));

            Console.WriteLine("Printer alle \"items\" i PO med en samlet pris højere end 78 $");
            foreach (var item in pricesByPartNos)
            {
                Console.WriteLine("The items are: {0}", item);
            }

            Console.WriteLine("Quantity større end 1");
            var dataFromSource3 = from name in pricesByPartNos
                                 where ((int)name.Element("Quantity") > 1)
                                 select name;
            foreach (var item in dataFromSource3)
            {
                Console.WriteLine("The items are: {0}", item);
            }

        }

        //Hvis man vil skrive direkte i et xml-objekt
        public static void XMLTree()
        {
            XElement contacts =
            new XElement("Contacts",
            new XElement("Contact",
                new XElement("Name", "Patrick Hines"),
                new XElement("Phone", "206-555-0144",
                    new XAttribute("Type", "Home")),
                new XElement("phone", "425-555-0145",
                    new XAttribute("Type", "Work")),
                new XElement("Address",
                    new XElement("Street1", "123 Main St"),
                    new XElement("City", "Mercer Island"),
                    new XElement("State", "WA"),
                    new XElement("Postal", "68042"))));

            Console.WriteLine(contacts);
        }
    }
}
