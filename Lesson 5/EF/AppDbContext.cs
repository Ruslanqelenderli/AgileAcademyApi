using Lesson_5.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lesson_5.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
            
        }
    }
}
