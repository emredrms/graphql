using GraphQL.Types;
using System;

namespace GraphQLSample.Model
{
    public class EasyStoreSchema : Schema
    {
        public EasyStoreSchema(Func<Type, GraphType> resolveType)
            : base(resolveType)
        {
            Query = (EasyStoreQuery)resolveType(typeof(EasyStoreQuery));
        }
    }
}
