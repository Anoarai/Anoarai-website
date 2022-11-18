using Microsoft.EntityFrameworkCore;
using Website.Models;

namespace Website.DatabaseContext
{
    public interface IDatabaseContext
    {
        public DbSet<PortfolioBlock> PortfolioBlocks { get; set; }
        public DbSet<Song> Songs { get; set; }

        IQueryable<T> Set<T>() where T : class;

        int SaveChanges();
    }
}
