using Website.DatabaseContext;

namespace Website.Services
{
    public class PortfolioBlockService
    {
        private AppDbContext database;

        public PortfolioBlockService(AppDbContext database)
        {
            this.database = database;
        }
    }
}
