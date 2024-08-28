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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { Id = 1, Name = "Combat", DisplayOrder = 1 },
                new CategoryModel { Id = 2, Name = "Spellcasting", DisplayOrder = 2 },
                new CategoryModel { Id = 3, Name = "Bestiary", DisplayOrder = 3 }
                );
        }
    }
}
