namespace EShop.Models
{
    public class Product_InvoiceDetail
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }


        public int InvoiceDetailId { get; set; }
        public InvoiceDetail Invoice {get;set;} 

    }
}
