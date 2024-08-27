using Microsoft.EntityFrameworkCore;

namespace BookWyrmCMV.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }
    }
}
