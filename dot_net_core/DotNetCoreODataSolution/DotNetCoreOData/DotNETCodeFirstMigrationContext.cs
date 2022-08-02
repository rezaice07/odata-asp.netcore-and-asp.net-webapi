using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreOData
{
    public class DotNETCodeFirstMigrationContext:DbContext
    {
        public DotNETCodeFirstMigrationContext(DbContextOptions<DotNETCodeFirstMigrationContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
