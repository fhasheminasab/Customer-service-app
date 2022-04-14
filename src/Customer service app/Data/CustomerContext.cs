using Customer_service_app.Data;
using MongoDB.Driver;

namespace Customer_service_app.Entity
{
    public class CustomerContext : ICustomerContext
    {
        public CustomerContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Customers = database.GetCollection<Customer>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Customers);
        }

        public IMongoCollection<Customer> Customers { get; }
    }
}
