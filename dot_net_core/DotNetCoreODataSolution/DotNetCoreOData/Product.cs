using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreOData
{
    [Table("Product", Schema = "dbo")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }

        public virtual List<Sale> Sales { get; set; }
    }


    [Table("Sale", Schema = "dbo")]
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string TotalSale { get; set; }
        public int SaleData { get; set; }
        public string SoldBy { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
