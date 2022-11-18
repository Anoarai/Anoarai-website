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

        public bool AddNewSong()
        {
            if (database.Songs.Any(s=>s.)
            {
                return false;
            }
            database.Songs.Add(new Song(name, lyrics, downloadLink));
            database.SaveChanges();

            
            return true;
        }
    }

    public interface ISongService
    {

    }
}
