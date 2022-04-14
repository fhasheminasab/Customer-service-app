using MongoDB.Driver;

namespace Customer_service_app.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Customer> customers)
        {
            if (!(customers.Find(p => true).Any()))
            {
                customers.InsertMany(GetPreConfiguredCustomers());
            }
        }

        private static IEnumerable<Customer> GetPreConfiguredCustomers()
        {
            return new List<Customer>()
            {
                new Customer(){ Id = "602d2149e773f2a3990b47f5", FirstName ="Mammad",LastName ="Mammadi",PhoneNumber ="09121110011"},
                new Customer(){ Id = "602d2149e773f2a3990b47f6", FirstName ="Mammad",LastName ="Mammadzade",PhoneNumber ="09121110012"},
                new Customer(){ Id = "602d2149e773f2a3990b47f7", FirstName ="Mammad",LastName ="Mammadpour",PhoneNumber ="09121110013"}
            };
        }
    }
}
