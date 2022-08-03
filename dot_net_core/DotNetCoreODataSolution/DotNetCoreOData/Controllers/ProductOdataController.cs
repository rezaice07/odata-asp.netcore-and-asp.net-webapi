using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreOData.Controllers
{   
    //for edm
    public class ProductOdataController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductOdataController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]        
        [EnableQuery]
        public async Task<ActionResult<IQueryable<Product>>> Get()
        {
            IQueryable<Product> retrievedProducts = await this.productService.RetrieveAllProducts();

            return Ok(retrievedProducts);
        }        
    }
}
