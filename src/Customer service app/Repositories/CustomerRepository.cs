using Customer_service_app.Data;
using Customer_service_app.Entity;
using MongoDB.Driver;

namespace Customer_service_app.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ICustomerContext _customerContext;

        public CustomerRepository(ICustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customerContext.Customers.Find(c => true).ToListAsync();
        }

        public async Task<Customer> GetCustomerById(string id)
        {
            return await _customerContext.Customers.Find(c => c.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomerByLastName(string lastName)
        {
            FilterDefinition<Customer> filter = Builders<Customer>.Filter.ElemMatch(c => c.LastName, lastName);
            return await _customerContext.Customers.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomerByPhoneNumber(string phoneNumber)
        {
            FilterDefinition<Customer> filter = Builders<Customer>.Filter.ElemMatch(c => c.PhoneNumber, phoneNumber);
            return await _customerContext.Customers.Find(filter).ToListAsync();
        }


        public async Task CreateCustomer(Customer customer)
        {
            await _customerContext.Customers.InsertOneAsync(customer);
        }

        public async Task<bool> DeleteCustomer(string id)
        {
            FilterDefinition<Customer> filter = Builders<Customer>.Filter.ElemMatch(c => c.Id, id);
            DeleteResult deleteResult = await _customerContext.Customers.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            var updateResult = await _customerContext.Customers.ReplaceOneAsync(filter: c => c.Id.Equals(customer.Id), replacement: customer);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
