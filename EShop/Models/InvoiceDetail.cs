using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Models
{
    public class InvoiceDetail
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }

        //Khóa Ngoại tới bảng  hóa đơn và sản phẩm n-n
        [ForeignKey("InvoiceDetailId")]
        public List<Product_InvoiceDetail> Product_InvoiceDetail { get; set; }

    }
}
