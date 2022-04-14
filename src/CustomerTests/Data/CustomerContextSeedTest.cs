using Customer_service_app.Data;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace CustomerTests.Data
{
    public class CustomerContextSeedTest
    {
        [Fact]
        public async void GetPreConfiguredCustomers_ShouldReturnUnemptyPreConfiguredCustomersAsync()
        {

            //Arrange
            IConfiguration _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();
            var client = new MongoClient(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(_configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            var Customers = database.GetCollection<Customer>(_configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            //Act
            CatalogContextSeed.SeedData(Customers);
            var expectedCustomers = await Customers.Find(c => true).ToListAsync();
            //Assert
            expectedCustomers.Should().NotBeEmpty();
        }

        [Fact]
        public async void GetPreConfiguredCustomers_ShouldReturnListOfPreConfiguredCustomersAsync()
        {

            //Arrange
            IConfiguration _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();
            var client = new MongoClient(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(_configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            var Customers = database.GetCollection<Customer>(_configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            //Act
            CatalogContextSeed.SeedData(Customers);
            var expectedCustomers = await Customers.Find(c => true).ToListAsync();
            //Assert
            expectedCustomers.Should().BeOfType<List<Customer>>();
        }
    }

}
