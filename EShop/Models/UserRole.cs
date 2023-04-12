using Microsoft.AspNetCore.Identity;

namespace EShop.Models
{
    public class UserRole:IdentityRole<Guid>
    {
        public string ? Decription { get; set; }
    }
}
