using Microsoft.EntityFrameworkCore;
using Website.Models;

namespace Website.DatabaseContext
{
    public interface IDatabaseContext
    {
        public DbSet<PortfolioBlock> portfolioBlocks { get; set; }
        IQueryable<T> Set<T>() where T : class;
        int SaveChanges();
    }
}
