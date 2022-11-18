using Website.DatabaseContext;

namespace Website.Services
{
    public class SongService : ISongService
    {
        private IDatabaseContext database;
        public SongService(IDatabaseContext database)
        {
            this.database = database;
        }
    }

    public interface ISongService
    {

    }
}
