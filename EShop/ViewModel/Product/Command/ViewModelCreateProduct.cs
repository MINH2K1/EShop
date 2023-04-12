namespace EShop.ViewModel.Product.Command
{
    public class ViewModelCreateProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; } = 0;
        public string UrlImage { get; set; }
        public string UrlName { get; set; }
        public IFormFile UrlFile { get; set; }
        public int Stock { get; set; }
    }
}
