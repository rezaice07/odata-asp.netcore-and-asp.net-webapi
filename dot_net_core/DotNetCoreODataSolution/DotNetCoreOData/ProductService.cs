using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreOData
{
    public interface IProductService
    {
        Task<IQueryable<Product>> RetrieveAllProducts();
    }

    public class ProductService: IProductService
    {
        private readonly DotNETCodeFirstMigrationContext db;
        public ProductService(DotNETCodeFirstMigrationContext db)
        {
            this.db = db;
        }
        public async Task<IQueryable<Product>> RetrieveAllProducts()
        {
            return db.Products.AsQueryable();
        }
    }
}
