using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreOData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<Product>>> GetAllProducts()
        {
            IQueryable<Product> retrievedProducts = await this.productService.RetrieveAllProducts();

            return Ok(retrievedProducts);
        }
    }
}
