using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; } = 0;
        public string UrlImage{get; set;}
        public string Stock { get; set; }

        [ForeignKey("ProductId")]
       public List<Product_InvoiceDetail> Product_InvoiceDetails { get; set; }

        [ForeignKey("ProductId")]
       public   List<Product_ProductType> Product_ProductTypes { get; set; }
    }
}
