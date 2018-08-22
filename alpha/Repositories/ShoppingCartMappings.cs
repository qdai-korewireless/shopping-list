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
            For<Item>()
                .TableName("item")
                .PartitionKey(u => u.Id)
                .Column(u => u.Id, cm => cm.WithName("id"))
                .Column(u => u.DishId, cm => cm.WithName("dishid"))
                .Column(u => u.Name, cm => cm.WithName("name"))
                .Column(u => u.Quantity, cm => cm.WithName("quantity"))
                .Column(u => u.Type, cm => cm.Ignore())
                ;

        }
    }

}
