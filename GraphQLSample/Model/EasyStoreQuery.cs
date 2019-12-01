using GraphQL.Types;
using GraphQLSample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLSample.Model
{
    public class EasyStoreQuery : ObjectGraphType
    {
        public EasyStoreQuery(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            Field<ListGraphType<CategoryType>>(
                "category",
                arguments: new QueryArguments(new List<QueryArgument>
                    {
                    new QueryArgument<IntGraphType> { Name = "id", Description = "Category id" },
                    new QueryArgument<StringGraphType>{ Name="name", Description="Category name."}
                    }
                ),
                resolve: context =>
                   {
                       var id = context.GetArgument<int?>("id");
                       var name = context.GetArgument<string>("name");

                       if (id.HasValue && !string.IsNullOrEmpty(name))
                       {
                           return categoryRepository.CategoriesAsyncByIdAndName(id.Value, name).Result.ToList();
                       }
                       else if (id.HasValue)
                       {
                           return categoryRepository.CategoriesAsyncById(id.Value).Result.ToList();
                       }
                       else if (!string.IsNullOrEmpty(name))
                       {
                           return categoryRepository.CategoriesAsyncByName(name).Result.ToList();
                       }
                       return categoryRepository.GetCategoryAsync(context.GetArgument<int>("id")).Result;
                   }
            );

            Field<ProductType>(
                "product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Product id" }
                ),
                resolve: context => productRepository.GetProductAsync(context.GetArgument<int>("id")).Result
            );
        }
    }
}
