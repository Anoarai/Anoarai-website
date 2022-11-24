using Microsoft.AspNetCore.Components.Forms;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
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

        public bool CreateNewPortfolioBlockTemplate(string title, string showcaseIcon, IBrowserFile icon, string longDescription, string webAddress)
        {
            if(database.PortfolioBlocks.Any(pb=>pb.Title == title))
            {
                return false;
            }

            using var image = Image.Load(icon.OpenReadStream());
            image.Mutate(x => x.Resize(256, 256));
            image.Save(showcaseIcon);

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
        bool CreateNewPortfolioBlockTemplate(string title, string showcaseIcon, IBrowserFile icon, string longDescription, string webAddress);
        List<PortfolioBlock> GetPortfolio();
    }
}
