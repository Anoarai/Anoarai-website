using Microsoft.EntityFrameworkCore;

namespace Website.DatabaseContext
{
    public class AppDbContext : DbContext, IDatabaseContext
    {
        //public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        IQueryable<T> IDatabaseContext.Set<T>()
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasKey(h => h.Id);


            //Relantionships
            //modelBuilder.Entity<User>().HasMany(u => u.Playlists).WithOne(pl => pl.Owner);
        }
    }
}
