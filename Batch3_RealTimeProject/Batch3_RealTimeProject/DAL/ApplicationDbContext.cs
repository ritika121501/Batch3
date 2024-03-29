using Batch3_RealTimeProject.Models;
using Microsoft.EntityFrameworkCore;

namespace Batch3_RealTimeProject.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action", CategoryDescription = "this is an action related book" },
                new Category { CategoryId = 2, CategoryName = "SciFi", CategoryDescription = "this is an SciFi related book" },
                new Category { CategoryId = 3, CategoryName = "History", CategoryDescription = "this is an History related book" }
                );
        }
    }
}
