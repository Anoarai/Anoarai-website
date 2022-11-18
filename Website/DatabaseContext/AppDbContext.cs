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

            modelBuilder.Entity<Song>().HasKey(s=>s.Id);
            modelBuilder.Entity<Song>().HasIndex(s=>s.Name).IsUnique();
            modelBuilder.Entity<Song>().HasIndex(s=>s.DownloadLink).IsUnique();
            modelBuilder.Entity<Song>().HasIndex(s=>s.YoutubeLink).IsUnique();  

            //Relantionships
            //modelBuilder.Entity<User>().HasMany(u => u.Playlists).WithOne(pl => pl.Owner);
        }
    }
}
