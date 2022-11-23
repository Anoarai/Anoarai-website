namespace Website.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public List<Song> Songs { get; set; }

        private Artist()
        {}

        public Artist(string name, string link)
        {
            Name = name;
            Link = link;
            Songs = new List<Song>();
        }
    }
}
