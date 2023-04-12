using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Models
{
    public class User : IdentityUser<Guid>
    {
        public string ?FirstName { get; set; }
        public string ?LastName { get; set; }
        [ForeignKey("UserId")]
       public List<Invoice> ?Invoices { get; set; }
    }
}
