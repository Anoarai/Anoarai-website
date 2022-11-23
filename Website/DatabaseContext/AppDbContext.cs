using Microsoft.EntityFrameworkCore;
using Website.Models;

namespace Website.DatabaseContext
{
    public class AppDbContext : DbContext, IDatabaseContext
    {
        public DbSet<PortfolioBlock> PortfolioBlocks { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<AnoaraiUser> Users { get; set; }

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

            modelBuilder.Entity<AnoaraiUser>().HasKey(u => u.Id);
            modelBuilder.Entity<AnoaraiUser>().HasIndex(u=>u.Username).IsUnique();

            modelBuilder.Entity<Artist>().HasKey(a => a.Id);
            modelBuilder.Entity<Artist>().HasIndex(a=>a.Name).IsUnique();

            //Relantionships
            modelBuilder.Entity<Song>().HasMany(u => u.RelatedArtists).WithMany(a => a.Songs);
        }
    }
}
