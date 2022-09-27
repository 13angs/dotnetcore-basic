using Microsoft.AspNetCore.Mvc;
using product_sv.Models;

namespace product_sv.Controllers
{
    [ApiController]
    [Route("api/product/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext context;

        public ProductController(ProductContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return context.Products;   
        }
    }
}