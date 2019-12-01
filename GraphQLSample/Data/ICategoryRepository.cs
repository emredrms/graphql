using GraphQLSample.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLSample.Data
{
    public interface ICategoryRepository
    {
        Task<List<Category>> CategoriesAsync();
        Task<List<Category>> CategoriesAsyncByName(string name);
        Task<List<Category>> CategoriesAsyncById(int id);

        Task<List<Category>> CategoriesAsyncByIdAndName(int id,string name);
        Task<Category> GetCategoryAsync(int id);
    }
}
