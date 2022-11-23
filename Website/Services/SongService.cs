using Website.DatabaseContext;
using Website.Models;

namespace Website.Services
{
    public class SongService : ISongService
    {
        private IDatabaseContext database;
        public SongService(IDatabaseContext database)
        {
            this.database = database;
        }

        public bool AddNewSong(string name, string lyrics, string downloadLink, string youtubeLink)
        {
            if (database.Songs.Any(s => s.Name == name) || database.Songs.Any(s=>s.DownloadLink == downloadLink) || database.Songs.Any(s=>s.YoutubeLink == youtubeLink))
            {
                return false;
            }
            database.Songs.Add(new Song(name, lyrics, downloadLink, youtubeLink));
            database.SaveChanges();
            return true;
        }

        public bool AddNewSongWithArtists(string name, string lyrics, string downloadLink, string youtubeLink, params string[] artists)
        {
            if (database.Songs.Any(s => s.Name == name) || database.Songs.Any(s => s.DownloadLink == downloadLink) || database.Songs.Any(s => s.YoutubeLink == youtubeLink))
            {
                return false;
            }
            database.Songs.Add(new Song(name, lyrics, downloadLink, youtubeLink, artists));
            database.SaveChanges();
            return true;
        }

        public List<Song> GetSongs()
        {
            return database.Songs.ToList();
        }
    }

    public interface ISongService
    {
        public bool AddNewSong(string name, string lyrics, string downloadLink, string youtubeLink);
        public bool AddNewSongWithArtists(string name, string lyrics, string downloadLink, string youtubeLink, params string[] artists);
        public List<Song> GetSongs();
    }
}
