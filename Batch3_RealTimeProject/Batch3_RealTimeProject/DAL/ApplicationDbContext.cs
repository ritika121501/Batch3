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
        public DbSet<Company> Company { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action", CategoryDescription = "this is an action related book" },
                new Category { CategoryId = 2, CategoryName = "SciFi", CategoryDescription = "this is an SciFi related book" },
                new Category { CategoryId = 3, CategoryName = "History", CategoryDescription = "this is an History related book" }
                );
            modelBuilder.Entity<Address>().HasData(
              new Address { AddressId = 1, AddressLine1 = "123 Louisa Lane", AddressLine2 = "Camp Hill Road", City = "Perrysburg", State = "Ohio", PhoneNumber = "(123)456-7890" },
              new Address { AddressId = 2, AddressLine1 = "345 Chenal Pkwy", AddressLine2 = "Gate Way", City = "Little Rock", State = "Arkansas", PhoneNumber = "(123)456-7890" },
              new Address { AddressId = 3, AddressLine1 = "64 Secane way", AddressLine2 = "Clifton Hills", City = "Dallas", State = "Texas", PhoneNumber = "(123)456-7890" }
              );
        }
    }
}
