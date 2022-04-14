
using Customer_service_app.Data;
using Customer_service_app.Entity;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace CustomerTests.Entity
{
    public class CustomerContextTest
    {
        [Fact]
        public async Task CustomerContext_ShouldCunstructCustomerContextAsync()
        {

            //Arrange
            IConfiguration _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();
            CustomerContext _customerContext = new CustomerContext(_configuration);
            //Act
            var expectedCustomers = await _customerContext.Customers.Find(c => true).ToListAsync();
            //Assert
            expectedCustomers.Should().NotBeEmpty();
        }
        [Fact]
        public async Task CustomerContext_ShouldCunstructCustomerContextaccuratelyAsync()
        {

            //Arrange
            IConfiguration _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();
            CustomerContext _customerContext = new CustomerContext(_configuration);
            //Act
            var expectedCustomers = await _customerContext.Customers.Find(c => true).ToListAsync();
            //Assert
            expectedCustomers.Should().BeOfType<List<Customer>>();
        }
    }
}
