using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Unit_7Microservices.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new List<Product>();

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => Products;

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id) =>
            Products.Find(p => p.ProductId == id) ?? (ActionResult<Product>)NotFound();

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            product.ProductId = Products.Count + 1;
            Products.Add(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }
    }
}
