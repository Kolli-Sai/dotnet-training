using EfCore_Task1.DB;
using EfCore_Task1.Models;
using Microsoft.AspNetCore.Mvc;

namespace EfCore_Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly EFCoreTask1DBContext _dbContext;
        public ProductController(EFCoreTask1DBContext DB)
        {
            this._dbContext = DB;
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<Product> products = _dbContext.Products.ToList();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product newProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Product productFound = _dbContext.Products.Find(id);
            if (productFound == null)
            {
                return NotFound();
            }

            return Ok(productFound);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Product newProduct, int id)
        {
            Product productFound = _dbContext.Products.Find(id);

            if (productFound != null)
            {
                productFound.Id = id;
                productFound.Price = newProduct.Price;
                productFound.Name = newProduct.Name;
                _dbContext.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Product productFound = _dbContext.Products.Find(id);

            if (productFound != null)
            {

                _dbContext.Products.Remove(productFound);
                _dbContext.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
