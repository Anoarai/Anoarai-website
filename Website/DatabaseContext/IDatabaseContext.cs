using Microsoft.EntityFrameworkCore;

namespace Website.DatabaseContext
{
    public interface IDatabaseContext
    {
        //public DbSet<User> Users { get; set; }
        IQueryable<T> Set<T>() where T : class;
        int SaveChanges();
    }
}
