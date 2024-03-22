using Lesson_3.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lesson_3.EF
{
    public class ApplicationContext : DbContext, IApllicationContext
    {
        public DbSet<Product> Products { get; set; }
        public ApplicationContext(DbContextOptions builder) : base(builder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().ToTable("PRODUCT");
        }

    }
}
