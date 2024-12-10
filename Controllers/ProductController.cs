using AdventureWorksApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksApi.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AdventureWorksDbContext _context;

        public ProductController(AdventureWorksDbContext context)
        {
            _context = context;
        }       

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            // Add the product to the database
            _context.Products.Add(product);

            // Save changes asynchronously
            await _context.SaveChangesAsync();

            // Return the created product along with its ID (which is auto-incremented by the database)
            return CreatedAtAction("GetProduct", new { id = product.ProductID }, product);
        }


    }
}
