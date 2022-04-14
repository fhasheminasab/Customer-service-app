using Customer_service_app.Data;
using MongoDB.Driver;

namespace Customer_service_app.Entity
{
    public interface ICustomerContext
    {
        IMongoCollection<Customer> Customers { get; }
    }
}
