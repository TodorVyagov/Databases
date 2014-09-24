namespace Catalogue
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    internal class Catalog
    {
        private static void Main()
        {
            // Task 2. Write program that extracts all different artists which are found in the catalog.xml. 
            // For each author you should print the number of albums in the catalogue. Use the DOM parser and a hash-table.
            Console.WriteLine("Task 2");
            ArtistsExtractor();

            // Task 3. Implement the previous using XPath.
            Console.WriteLine("\nTask 3.");
            ArtistsExtractorWithXPath();

            // Task 4. Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.
            Console.WriteLine("\nTask 4.\nAll albums with price > 20 were deleted.");
            ExpensiveAlbumsDelter();

            // Task 5. Write a program, which using XmlReader extracts all song titles from catalog.xml.
            Console.WriteLine("\nTask 5.");
            SongExtractor();

            // Task 6. Rewrite the same using XDocument and LINQ query.
            Console.WriteLine("\nTask 6.");
            SongExtractorWithLinq();

            // Task 7. In a text file we are given the name, address and phone number of given person (each at a single
            // line). Write a program, which creates new XML document, which contains these data in structured XML format.
            Console.WriteLine("\nTask 7.");
            CreateXmlDocument();
        }

        private static void ArtistsExtractor()
        {
            // Task 2. Write program that extracts all different artists which are found in the catalog.xml. 
            // For each author you should print the number of albums in the catalogue. Use the DOM parser and a hash-table.
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Catalogue.xml");

            XmlNode rootNode = doc.DocumentElement;
            Dictionary<string, int> artists = new Dictionary<string, int>();

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                string artist = node["artist"].InnerText;

                if (artists.ContainsKey(artist))
                {
                    artists[artist]++;
                }
                else
                {
                    artists.Add(artist, 1);
                }
            }

            foreach (var pair in artists)
            {
                Console.WriteLine("{0} has {1} album(s).", pair.Key, pair.Value);
            }
        }

        private static void ArtistsExtractorWithXPath()
        {
            // Task 3. Implement the previous using XPath.
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../Catalogue.xml");
            string xPathQuery = "catalogue/album";

            Dictionary<string, int> artists = new Dictionary<string, int>();
            XmlNodeList artistsList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode artistNode in artistsList)
            {
                string artistName = artistNode.SelectSingleNode("artist").InnerText;

                if (artists.ContainsKey(artistName))
                {
                    artists[artistName]++;
                }
                else
                {
                    artists.Add(artistName, 1);
                }
            }

            foreach (var pair in artists)
            {
                Console.WriteLine("{0} has {1} album(s).", pair.Key, pair.Value);
            }
        }

        private static void ExpensiveAlbumsDelter()
        {
            // Task 4. Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Catalogue.xml");
            XmlNode rootNode = doc.DocumentElement;

            foreach (XmlNode albumNode in rootNode.ChildNodes)
            {
                decimal price = decimal.Parse(albumNode["price"].InnerText);
                if (price > 20)
                {
                    rootNode.RemoveChild(albumNode);
                }
            }

            doc.Save(@"..\..\CheapCatalogue.xml");
        }

        private static void SongExtractor()
        {
            // Task 5. Write a program, which using XmlReader extracts all song titles from catalog.xml.
            Console.WriteLine("All song titles:");
            using (XmlReader reader = XmlReader.Create(@"..\..\Catalogue.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                    {
                        Console.WriteLine(reader.ReadInnerXml());
                    }
                }
            }
        }

        private static void SongExtractorWithLinq()
        {
            // Task 6. Rewrite the same using XDocument and LINQ query.
            XDocument doc = XDocument.Load(@"..\..\Catalogue.xml");
            var songTitles =
                from title in doc.Descendants("title")
                select title.Value;

            foreach (var title in songTitles)
            {
                Console.WriteLine(title);
            }
        }

        private static void CreateXmlDocument()
        {
            // Task 7. In a text file we are given the name, address and phone number of given person (each at a single
            // line). Write a program, which creates new XML document, which contains these data in structured XML format.
            XElement phoneBook = new XElement("people");

            using (var reader = new StreamReader(@"..\..\people.txt"))
            {
                string name = string.Empty;

                while (true)
                {
                    name = reader.ReadLine();
                    string address = reader.ReadLine();
                    string phone = reader.ReadLine();
                    if (name == null || address == null || phone == null)
                    {
                        break;
                    }

                    XElement phonebookEntry = new XElement("person",
                        new XElement("name", name),
                        new XElement("address", address),
                        new XElement("phone", phone)
                    );

                    phoneBook.Add(phonebookEntry);
                }
            }

            phoneBook.Save(@"..\..\addressbook.xml");
        }
    }
}
