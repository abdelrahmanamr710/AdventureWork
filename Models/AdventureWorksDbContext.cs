using Microsoft.EntityFrameworkCore;

namespace AdventureWorksApi.Models
{
    public class AdventureWorksDbContext : DbContext
    {
        public AdventureWorksDbContext(DbContextOptions<AdventureWorksDbContext> options)
            : base(options)
        {
        }

        // Define DbSet for Product (make sure it's correct)
        public DbSet<Product> Products { get; set; }
    }
}




/*using Microsoft.EntityFrameworkCore;

namespace AdventureWorksApi.Models
{
    public class AdventureWorksDbContext : DbContext
    {
        public AdventureWorksDbContext(DbContextOptions<AdventureWorksDbContext> options)
            : base(options)
        {
        }

        // Define DbSet properties for your tables
        public DbSet<Product> Products { get; set; }  // Example, add more tables as needed
    }
}
*/
