using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Örnek bir yapılandırma, zorunlu değil:
            modelBuilder.Entity<Post>().HasKey(b => b.Id);
            modelBuilder.Entity<Comment>().HasKey(c => c.Id);
        }

    }
}
