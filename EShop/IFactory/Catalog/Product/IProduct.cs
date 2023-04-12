namespace EShop.IFactory.Catalog.Product
{
    public interface IProduct
    {
        Task <int> GetProductAll { get; set; }
    }
}
