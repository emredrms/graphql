using GraphQL.Types;
using GraphQLSample.Model;
using System.Linq;

namespace GraphQLSample.Data
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(IProductRepository productRepository)
        {
            Field(x => x.Id).Description("Category id.");
            Field(x => x.Name).Description("Category name.");

            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => productRepository.GetProductsWithByCategoryIdAsync(context.Source.Id).Result
            );
        }
    }
}
