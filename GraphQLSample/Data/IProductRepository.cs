using GraphQLSample.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLSample.Data
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<List<Product>> GetProductsWithByCategoryIdAsync(int categoryId);

        Task<List<Product>> GetProductsWithByCategoryNameAsync(string name);

        Task<List<Product>> GetProductsWithByCategoryIdAndNameAsync(int categoryId, string name);
        Task<Product> GetProductAsync(int id);
    }
}
