namespace EShop.Models
{
    public class Product_ProductType
    {
        public int Id { get; set; }
        public Product Products { get; set; }
        public int ProductId { get; set; }

        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
    }
}
