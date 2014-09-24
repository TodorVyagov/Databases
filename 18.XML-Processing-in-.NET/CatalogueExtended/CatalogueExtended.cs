namespace CatalogueExtended
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Xsl;

    internal class CatalogueExtended
    {
        private static void Main()
        {
            // Task 8. Write a program, which reads the file catalog.xml and creates the file album.xml, in which stores in appropriate way the names of all albums and their authors.
            Console.WriteLine("Task 8-10.");
            CreateAlbum();

            // Task 9-10. 
            Console.WriteLine("\nTask 9-10.");
            string startDirectory = @"C:\Program Files\Internet Explorer";
            XElement booksXml = new XElement("directories", CreateXmlForDirectory(startDirectory));
            booksXml.Save(@"..\..\directories.xml");
            Console.WriteLine("All directories were traversed and saved in directories.xml.");

            // Task 11. Write a program, which extract from the file catalog.xml the prices for all albums, 
            // published 5 years ago or earlier. Use XPath query.
            Console.WriteLine("\nTask 11.");
            OldAlbumsExtractor();

            // Task 12. Rewrite the previous using LINQ query.
            Console.WriteLine("\nTask 12.");
            OldAlbumsExtractorWithLinq();

            // Task 13-14.
            Console.WriteLine("\nTask 13-14.");
            TransformCatalogueIntoHtml();
            Console.WriteLine("HTML file generated.");
        }

        private static void TransformCatalogueIntoHtml()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../catalogue.xslt");
            xslt.Transform("../../catalogue.xml", "../../catalogue.html");
        }

        private static void CreateAlbum()
        {
            // Task 8. Write a program, which reads the file catalog.xml and creates the file album.xml, in which stores in appropriate way the names of all albums and their authors.
            XDocument catalogDoc = XDocument.Load(@"..\..\Catalogue.xml");
            XElement albums = new XElement("albums");
            var albumsWithAuthors =
                                   from album in catalogDoc.Descendants("album")
                                   select new
                                   {
                                       Album = album.Element("name").Value,
                                       Author = album.Element("artist").Value
                                   };

            foreach (var albumWithAuthor in albumsWithAuthors)
            {
                XElement newEntry = new XElement("album",
                    new XElement("name", albumWithAuthor.Album),
                    new XElement("author", albumWithAuthor.Author));

                albums.Add(newEntry);
            }

            albums.Save(@"..\..\album.xml");
            Console.WriteLine("Album created!");
        }

        public static XElement CreateXmlForDirectory(string sourceDirectory)
        {
            try
            {
                FileInfo fileInfoSource = new FileInfo(sourceDirectory);

                XElement roothDirectory = new XElement("directory",
                new XAttribute("name", fileInfoSource.Name));

                var files = Directory.EnumerateFiles(sourceDirectory);
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    roothDirectory.Add(new XElement("file",
                        new XElement("name", fileInfo.Name),
                        new XElement("type", fileInfo.Extension)
                    ));

                }

                var directories = Directory.EnumerateDirectories(sourceDirectory);
                foreach (var directory in directories)
                {
                    roothDirectory.Add(CreateXmlForDirectory(directory));
                }

                return roothDirectory;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Error" + e.Message);
            }
        }

        private static void OldAlbumsExtractor()
        {
            // Task 11. Write a program, which extract from the file catalog.xml the prices for all albums, 
            // published 5 years ago or earlier. Use XPath query.
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Catalogue.xml");

            string xPathQuery = "catalogue/album[year<" + (DateTime.Now.Year - 5) + "]";
            XmlNodeList oldAlbums = doc.SelectNodes(xPathQuery);

            foreach (XmlNode album in oldAlbums)
            {
                Console.WriteLine(album.SelectSingleNode("name").InnerText + " " + album.SelectSingleNode("price").InnerText);
            }
        }

        private static void OldAlbumsExtractorWithLinq()
        {
            XDocument doc = XDocument.Load(@"..\..\Catalogue.xml");

            var oldAlbums =
                from album in doc.Descendants("album")
                where (int)album.Element("year") < (DateTime.Now.Year - 5)
                select album;

            foreach (var album in oldAlbums)
            {
                Console.WriteLine(album.Element("name").Value + " -> " + album.Element("price").Value);
            }
        }
    }
}
