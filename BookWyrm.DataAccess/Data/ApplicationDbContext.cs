using BookWyrm.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWyrm.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { Id = 1, Name = "Combat", DisplayOrder = 1 },
                new CategoryModel { Id = 2, Name = "Spellcasting", DisplayOrder = 2 },
                new CategoryModel { Id = 3, Name = "Bestiary", DisplayOrder = 3 }
                );

            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel 
                {
                    Id = 1,
                    Title = "Cantrips for Beginners",
                    Author = "Gandalor Toadbottom",
                    Description = "Learn the fundamentals of cantrips with this beginner-friendly guide. Perfect for aspiring wizards looking to master simple spells and impress friends at parties. No prior experience needed!",
                    ISBN = "987-0-420-70457-0",
                    Price = 24.99
                },
                new ProductModel 
                {
                    Id = 2,
                    Title = "Goblin Slaying for Dummies",
                    Author = "Gawb Lynnhunter",
                    Description = "A straightforward manual on goblin slaying for those new to adventuring. Packed with practical tips, tricks, and safety advice to keep you alive and victorious in the heat of battle.",
                    ISBN = "987-0-911-80085-0",
                    Price = 29.99
                },
                new ProductModel
                {
                    Id = 3,
                    Title = "A Dragon Tamer's Safety Guide",
                    Author = "Rudolf the Armless",
                    Description = "An essential safety manual for aspiring dragon tamers, written by a seasoned expert. Discover the dos and don'ts of dealing with dragons while avoiding the common pitfalls that might cost you an arm and a leg.",
                    ISBN = "987-0-777-11701-0",
                    Price = 69.99
                }
                );
        }
    }
}
