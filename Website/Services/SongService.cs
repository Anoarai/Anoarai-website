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
    }

    public interface ISongService
    {
        public bool AddNewSong(string name, string lyrics, string downloadLink, string youtubeLink);
    }
}
