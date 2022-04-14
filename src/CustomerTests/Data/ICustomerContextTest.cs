
using Customer_service_app.Data;
using Customer_service_app.Entity;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

//This Test is performed only to see if the mock works
namespace CustomerTests.Data
{
    public class ICustomerContextTest
    {
        public Mock<ICustomerContext> mock_ICustomerContext = new();
        public Mock<IMongoCollection<Customer>> mock_IMongoCollection = new();

        //////////////////////third try: doesnt work

        //[Fact]
        //public async Task ICustomerContext_ShouldCunstructCustomerContextAsync2( )
        //{
        //    //Arrange
        //    var asyncCursor = new Mock<IAsyncCursor<Customer>>();
        //    var expectedResult = CollectionData();
        //    mock_IMongoCollection.Setup(_collection => _collection.FindSync(
        //    Builders<Customer>.Filter.Empty,
        //    It.IsAny<FindOptions<Customer>>(),
        //    default)).Returns(asyncCursor.Object);
        //    asyncCursor.SetupSequence(_async => _async.MoveNext(default)).Returns(true).Returns(false);
        //    asyncCursor.SetupGet(_async => _async.Current).Returns(expectedResult);
        //    mock_ICustomerContext.Setup(m => m.Customers).Returns(mock_IMongoCollection.Object);
        //    var expectedcustomers = mock_IMongoCollection.Object.Find(c => true).ToListAsync();

        //    //Act

        //    //Assert
        //    (await mock_ICustomerContext.Object.Customers.Find(c => true).ToListAsync()).Should().NotBeEmpty();


        //}
        //private static List<Customer> CollectionData()
        //{
        //    return new List<Customer>()
        //    {
        //        new Customer(){ Id = "602d2149e773f2a3990b47f5", FirstName ="Mammad",LastName ="Mammadi",PhoneNumber ="09121110011"},
        //        new Customer(){ Id = "602d2149e773f2a3990b47f6", FirstName ="Mammad",LastName ="Mammadzade",PhoneNumber ="09121110012"},
        //        new Customer(){ Id = "602d2149e773f2a3990b47f7", FirstName ="Mammad",LastName ="Mammadpour",PhoneNumber ="09121110013"}
        //    };
        //}
       
        //////////////////////First try: works but its shit
        [Fact]
		public async Task ICustomerContext_ShouldCunstructCustomerContextAsync()
		{

			//Arrange
			IConfiguration _configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json").Build();
			CustomerContext _customerContext = new CustomerContext(_configuration);
			mock_ICustomerContext.Setup(m => m.Customers).Returns(_customerContext.Customers);
			//Act
			var expectedCustomers = await mock_ICustomerContext.Object.Customers.Find(c => true).ToListAsync();
			//Assert
			expectedCustomers.Should().NotBeEmpty();
		}

	}
}
