namespace Website.Models
{
    public class PortfolioBlock
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ShowcaseIcon { get; set; }
        public string LongDescription { get; set; }
        public string WebAddress { get; set; }

        private PortfolioBlock()
        {}

        public PortfolioBlock(string title, string showcaseIcon, string longDescription, string webAddress)
        {
            Title = title;
            ShowcaseIcon = showcaseIcon;
            LongDescription = longDescription;
            WebAddress = webAddress;
        }
    }
}
