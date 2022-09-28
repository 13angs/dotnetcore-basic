using Microsoft.AspNetCore.Mvc;
using product_sv.Interfaces;
using product_sv.Models;

namespace product_sv.Controllers
{
    [ApiController]
    [Route("api/product/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext context;
        private readonly IGrpcGroupService groupService;

        public ProductController(ProductContext context, IGrpcGroupService groupService)
        {
            this.context = context;
            this.groupService = groupService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return context.Products;   
        }

        [HttpGet]
        [Route("group/groups")]
        public ActionResult<IEnumerable<ProductGroup>>? GetGroups()
        {
            return groupService.GetGroups();
        }
    }
}