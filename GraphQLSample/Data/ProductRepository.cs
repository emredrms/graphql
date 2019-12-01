using GraphQLSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLSample.Data
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>{
                new Product()
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Apple Macbook Pro 2016",
                    Description = "Touchbar, 3.2GHZ",
                    Price = 5000
                },
                new Product()
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Apple Macbook Air",
                    Description = "2.3GHZ 8GB RAM",
                    Price = 2000
                },
                new Product()
                {
                    Id = 3,
                    CategoryId = 1,
                    Name = "Dell XPS 13",
                    Description = "3.3GHZ 12GB RAM",
                    Price = 4000
                }
            };
        }

        public Task GetProductAsync(int id)
        {
            return Task.FromResult(_products.FirstOrDefault(x => x.Id == id));
        }

        public Task GetProductsAsync()
        {
            return Task.FromResult(_products);
        }

        public Task<List<Product>> GetProductsWithByCategoryIdAndNameAsync(int categoryId, string name)
        {
            throw new NotImplementedException();
        }

        public Task GetProductsWithByCategoryIdAsync(int categoryId)
        {
            return Task.FromResult(_products.Where(x => x.CategoryId == categoryId).ToList());
        }

        public Task<List<Product>> GetProductsWithByCategoryNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        Task<Product> IProductRepository.GetProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Product>> IProductRepository.GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        Task<List<Product>> IProductRepository.GetProductsWithByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
