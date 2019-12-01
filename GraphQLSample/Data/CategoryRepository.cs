using GraphQLSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLSample.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories;

        public CategoryRepository()
        {
            _categories = new List<Category>{
                new Category()
                {
                    Id = 1,
                    Name = "Computers"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Mobile Phones"
                }
            };
        }

        public Task<List<Category>> CategoriesAsync()
        {
            return Task.FromResult(_categories);
        }

        public Task<List<Category>> CategoriesAsyncById(int id)
        {
            return Task.FromResult(_categories.Where(c=>c.Id == id).ToList());
        }

        public Task<List<Category>> CategoriesAsyncByIdAndName(int id, string name)
        {
            return Task.FromResult(_categories.Where(c => c.Id == id && c.Name == name).ToList());
        }

        public Task<List<Category>> CategoriesAsyncByName(string name)
        {
            return Task.FromResult(_categories.Where(c => c.Name == name).ToList());
        }

        public Task<Category> GetCategoryAsync(int id)
        {
            return Task.FromResult(_categories.FirstOrDefault(x => x.Id == id));
        }
    }
}
