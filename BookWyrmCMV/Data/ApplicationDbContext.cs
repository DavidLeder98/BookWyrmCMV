using BookWyrmCMV.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWyrmCMV.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }

        public DbSet<CategoryModel> Categories { get; set; }
    }
}
