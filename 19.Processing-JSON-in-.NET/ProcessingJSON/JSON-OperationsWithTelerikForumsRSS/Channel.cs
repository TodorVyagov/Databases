namespace JsonOperationsWithTelerikForumsRss
{
    using System.Collections.Generic;

    public class Channel
    {
        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public List<Item> Item { get; set; }
    }
}
