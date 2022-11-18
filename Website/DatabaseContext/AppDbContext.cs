using Microsoft.EntityFrameworkCore;
using Website.Models;

namespace Website.DatabaseContext
{
    public class AppDbContext : DbContext, IDatabaseContext
    {
        public DbSet<PortfolioBlock> PortfolioBlocks { get; set; }
        public DbSet<Song> Songs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        IQueryable<T> IDatabaseContext.Set<T>()
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PortfolioBlock>().HasKey(pb=>pb.Id);
            modelBuilder.Entity<PortfolioBlock>().HasIndex(pb => pb.Title).IsUnique();

            //Relantionships
            //modelBuilder.Entity<User>().HasMany(u => u.Playlists).WithOne(pl => pl.Owner);
        }
    }
}
