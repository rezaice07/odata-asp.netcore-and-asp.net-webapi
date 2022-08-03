using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreOData.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IQueryable<Product>>> GetExpands()
        {
            IQueryable<Product> retrievedProducts = new List<Product>() {
                new Product
                {
                     Id= 1,
                    Title= "Rice",
                    Qty= 1,
                    Price= 50,
                    Sales= new List<Sale>(){
                        new Sale
                        {
                            Id= 1,
                            ProductId= 1,
                            TotalSale= "100",
                            SaleData= 1,
                            SoldBy= "1"
                        }
                    }
                },
            }.AsQueryable();

            return Ok(retrievedProducts);
        }
    }
}
