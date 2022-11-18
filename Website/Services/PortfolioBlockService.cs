using Website.DatabaseContext;
using Website.Models;

namespace Website.Services
{
    public class PortfolioBlockService : IPortfolioBlockService
    {
        private IDatabaseContext database;

        public PortfolioBlockService(IDatabaseContext database)
        {
            this.database = database;
        }

        public bool CreateNewPortfolioBlockTemplate(string title, string showcaseIcon, string longDescription, string webAddress)
        {
            if(database.PortfolioBlocks.Any(pb=>pb.Title == title))
            {
                return false;
            }
            database.PortfolioBlocks.Add(new PortfolioBlock(title, showcaseIcon, longDescription, webAddress));
            database.SaveChanges();
            return true;
        }

        public List<PortfolioBlock> GetPortfolio()
        {
            return database.PortfolioBlocks.Select(pb => pb).ToList();
        }
    }


    public interface IPortfolioBlockService
    {
        bool CreateNewPortfolioBlockTemplate(string title, string showcaseIcon, string longDescription, string webAddress);
        List<PortfolioBlock> GetPortfolio();
    }
}
