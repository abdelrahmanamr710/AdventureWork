using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdventureWorksApi.Models
{
    public class Product
    {
        [Key]

        public int ProductID { get; set; }

        [Required]  // Make sure Name is required
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]  // Ensure ListPrice is required if it should not be nullable
        [Range(0, double.MaxValue)]  // Optional: Ensure valid price range
        public decimal ListPrice { get; set; }
    }
}

/*namespace AdventureWorksApi.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public required string Name { get; set; }
        public decimal ListPrice { get; set; }
    }
}
*/