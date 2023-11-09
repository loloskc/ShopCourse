using ShopCourse.Data.Enum;
using ShopCourse.Models;

namespace ShopCourse.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product?> GetByIdAsync(int id);
        Task<Product?> GetByIdAsyncNoTracking(int id);
        Task<int> GetCountAsync();
        Task<int> GetCountByCategoryAsync(ProductCategory category);
        bool Add(Product product);
        bool Update(Product product);
        bool Delete(Product product);
        bool Save();

    }
}
