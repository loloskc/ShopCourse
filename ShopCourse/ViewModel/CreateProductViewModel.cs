using ShopCourse.Data.Enum;
using System.Net;

namespace ShopCourse.ViewModel
{
    public class CreateProductViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Discription { get; set; }
        public IFormFile? Image { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
