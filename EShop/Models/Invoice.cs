using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;
       
        //Khóa Ngoại tới Bảng User Nhân viên Bán
        public Guid UserId { get; set; }
        public User User { get; set; }


        // khóa ngoại tới bảng chi tiết hóa đơn
        [ForeignKey("InvoiceId")]
        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
