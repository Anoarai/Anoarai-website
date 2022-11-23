﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Website.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lyrics { get; set; }
        public string DownloadLink { get; set; }
        public string YoutubeLink { get; set; }
        public List<Artist> RelatedArtists { get; set; }

        private Song()
        {

        }
        public Song(string name, string lyrics, string downloadLink, string youtubeLink)
        {
            Name = name;
            Lyrics = lyrics;
            DownloadLink = downloadLink;
            YoutubeLink = youtubeLink;
            RelatedArtists = new List<Artist>();
        }
        public Song(string name, string lyrics, string downloadLink, string youtubeLink, params string[] artists)
        {
            Name = name;
            Lyrics = lyrics;
            DownloadLink = downloadLink;
            YoutubeLink = youtubeLink;
            RelatedArtists = new List<Artist>();
            for (int i = 0; i+1 <= artists.Length; i+=2)
            {
                RelatedArtists.Add(new Artist(artists[i], artists[i+1]));
            }
        }
    }
}
