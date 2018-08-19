using alpha.Models;
using Cassandra.Mapping;

namespace alpha.Repositories
{
    public class ShoppingCartMappings : Mappings
    {
        public ShoppingCartMappings()
        {
            // Define mappings in the constructor of your class
            // that inherits from Mappings
            For<Dish>()
               .TableName("dish")
               .PartitionKey(u => u.Id)
               .Column(u => u.Id, cm => cm.WithName("id"))
                .Column(u => u.Name, cm => cm.WithName("name"))
                .Column(u => u.Items, cm => cm.Ignore());

        }
    }

}
