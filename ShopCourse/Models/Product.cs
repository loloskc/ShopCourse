using ShopCourse.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace ShopCourse.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Discription{ get; set; }
        public string? Image { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public string? UserId { get; set; }
        public User User { get; set; }


    }
}
