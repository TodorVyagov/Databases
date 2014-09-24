namespace JsonOperationsWithTelerikForumsRss
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Text;

    internal class JsonOperationsWithTelerikForumsRss
    {
        private static void Main()
        {
            //WebClient client = new WebClient();
            //client.DownloadFile(@"http://forums.academy.telerik.com/feed/qa.rss", @"..\..\rss.xml");
            
            // Parse the XML from the feed to JSON
            XDocument doc = XDocument.Load(@"..\..\rss.xml");
            string jsonString = JsonConvert.SerializeXNode(doc, Formatting.Indented);
            var jsonObj = JObject.Parse(jsonString);
            // Console.WriteLine(jsonObj);

            // Using LINQ-to-JSON select all the question titles and print them to the console
            Console.WriteLine("\nQuestins from RSS:");
            foreach (var item in jsonObj["rss"]["channel"]["item"])
            {
                Console.WriteLine(item["title"]);
            }

            // Parse the JSON string to POCO
            var poco = JsonConvert.DeserializeObject<RootObject>(jsonString);
            Console.WriteLine("POCO");
            foreach (var item in poco.Rss.Channel.Item)
            {
                Console.WriteLine(item.Title);
            }

            // Using the parsed objects create a HTML page that lists all questions from the RSS their categories and
            // a link to the question's page
            StringBuilder html = new StringBuilder("<body>\n\t<ul>\n");
            foreach (var item in poco.Rss.Channel.Item)
            {
                html.AppendLine("\t\t<li>Question : " + item.Title + " Category : " + item.Category + "Link : " +
                    item.Link + "</li>");
            }

            html.AppendLine("\t</ul>\n</body>");
            Console.WriteLine(html);
        }
    }
}
