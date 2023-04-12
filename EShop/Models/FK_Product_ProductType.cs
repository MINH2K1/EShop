namespace EShop.Models
{
    public class FK_Product_ProductType
    {
        public int Id { get; set; }
        public Product product { get; set; }
        public int ProductId { get; set; }

        public ProductType productType { get; set; }
        public int productTypeId { get; set; }
    }
}
