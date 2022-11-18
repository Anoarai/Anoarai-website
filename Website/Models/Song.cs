namespace Website.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lyrics { get; set; }
        public string DownloadLink { get; set; }
        public string YoutubeLink { get; set; }

        private Song()
        {

        }
        public Song(string name, string lyrics, string downloadLink, string youtubeLink)
        {
            Name = name;
            Lyrics = lyrics;
            DownloadLink = downloadLink;
            YoutubeLink = youtubeLink;
        }
    }
}
