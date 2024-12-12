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

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductID)
            {
                return BadRequest("Product ID mismatch.");
            }

            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound("Product not found.");
            }

            // Update fields of the existing product
            existingProduct.Name = product.Name;
            existingProduct.ListPrice = product.ListPrice;
            // Add any other fields you want to update

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound("Product no longer exists.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }


        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
