namespace EShop.IFactory.Common
{
    public interface IFactory<T>
    {
        Task<T> CreateAsync<T>();
        Task<T> UpdateAsync();
        Task<T> DeleteAsync<T>();   
        
    }
}
