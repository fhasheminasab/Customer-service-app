using Customer_service_app.Data;

namespace Customer_service_app.Repositories
{
    public interface ICustomerRepository
    {
        //querry:
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(string id);
        Task<IEnumerable<Customer>> GetCustomerByLastName(string lastName);
        Task<IEnumerable<Customer>> GetCustomerByPhoneNumber(string phoneNumber);
        //command:
        Task CreateCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);
        Task<bool> DeleteCustomer(string id);
    }
}
