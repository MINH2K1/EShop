namespace EShop.IFactory.ProductType
{
    public interface IProductType<T>
    {
        Task<T> create { get; set; }
        Task<T> update { get; set; }
        Task<T> delete { get; set; }
        Task<T> get { get; set; }
        Task<T> getById { get; }
    }
}
