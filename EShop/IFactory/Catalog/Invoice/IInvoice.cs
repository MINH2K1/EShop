namespace EShop.IFactory.Catalog.Invoice
{
    public interface IInvoice<T>
    {
        Task<T> GetMoneyOnTime(DateTime? StartDate , DateTime? Endate);
        Task<T> GetMoneyOnMonth(int Month, int Year);
        Task<T> GetMoneyOnYear(int Year);
        Task<T> GetProductBeseller();
        Task<T> GetInterestOnDay();
    }
}
