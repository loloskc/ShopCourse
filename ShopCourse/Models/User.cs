using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ShopCourse.Models
{
    public class User  : IdentityUser
    {
        public int BalanceMoney { get; set;}
        public string? ProfileImageUrl { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
