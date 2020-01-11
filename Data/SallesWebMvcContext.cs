
using Microsoft.EntityFrameworkCore;


namespace SallesWebMvc.Data
{
    public class SallesWebMvcContext : DbContext
    {
        public SallesWebMvcContext (DbContextOptions<SallesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Department> Department { get; set; }
        public DbSet<Models.Seller> Seller { get; set; }
        public DbSet<Models.SalesRecord> SalesRecord { get; set; }
      


    }
}
