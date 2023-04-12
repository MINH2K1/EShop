using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ?Description { get; set; }

        [ForeignKey("ProductTypeId")]
        List<Product_ProductType> ?Products { get; set; }
    }
}
