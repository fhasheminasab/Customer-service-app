using Customer_service_app.Data;
using Customer_service_app.Entity;
using Customer_service_app.Repositories;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;
namespace CustomerTests.Repositories
{
	public class CustomerRepositoryTest
	{
		public Mock<ICustomerContext> mock_ICustomerContext = new();

		[Fact]
		public async Task CustomerRepository_Should_GetCustomersAsync()
		{
			//Arrange
			CustomerRepositoryTestBuilder _CustomerRepositoryTestBuilder = new CustomerRepositoryTestBuilder();
			CustomerRepository _CustomerRepository = _CustomerRepositoryTestBuilder.Build();
			CustomerContext _customerContext = _CustomerRepositoryTestBuilder.customerContext;
			//Act 
			IEnumerable<Customer> Generated = await _CustomerRepository.GetCustomers();
			IEnumerable<Customer> expected = await _customerContext.Customers.Find(c => true).ToListAsync();
			//Assert
			Generated.Should().BeEquivalentTo(expected);
		}

		[Fact]
		public async Task CustomerRepository_Should_GetCustomerByIdAsync()
		{
			//Arrange
			CustomerRepositoryTestBuilder _CustomerRepositoryTestBuilder = new CustomerRepositoryTestBuilder();
			CustomerRepository _CustomerRepository = _CustomerRepositoryTestBuilder.Build();
			CustomerContext _customerContext = _CustomerRepositoryTestBuilder.customerContext;
			string id = "602d2149e773f2a3990b47f5";
			//Act 
			Customer Generated = await _CustomerRepository.GetCustomerById(id);
			Customer expected = await _customerContext.Customers.Find(c => c.Id.Equals(id)).FirstOrDefaultAsync();
			//Assert
			Generated.Should().BeEquivalentTo(expected);
		}

		[Fact]
		public async Task CustomerRepository_Should_GetCustomerByLastNameAsync()
		{
			//Arrange
			CustomerRepositoryTestBuilder _CustomerRepositoryTestBuilder = new CustomerRepositoryTestBuilder();
			CustomerRepository _CustomerRepository = _CustomerRepositoryTestBuilder.Build();
			CustomerContext _customerContext = _CustomerRepositoryTestBuilder.customerContext;
			string lastName = "Mammadi";
			//Act
			IEnumerable<Customer> Generated = await _CustomerRepository.GetCustomerByLastName(lastName);
			FilterDefinition<Customer> filter = Builders<Customer>.Filter.ElemMatch(c => c.LastName, lastName);
			IEnumerable<Customer> expected = await _customerContext.Customers.Find(filter).ToListAsync();
			//Assert
			Generated.Should().BeEquivalentTo(expected);
		}
		[Fact]
		public async Task CustomerRepository_Should_GetCustomerByPhoneNumberAsync()
		{
			//Arrange
			CustomerRepositoryTestBuilder _CustomerRepositoryTestBuilder = new CustomerRepositoryTestBuilder();
			CustomerRepository _CustomerRepository = _CustomerRepositoryTestBuilder.Build();
			CustomerContext _customerContext = _CustomerRepositoryTestBuilder.customerContext;
			string phoneNumber = "09121110011";
			//Act 
			var Generated = await _CustomerRepository.GetCustomerByPhoneNumber(phoneNumber);
			FilterDefinition<Customer> filter = Builders<Customer>.Filter.ElemMatch(c => c.PhoneNumber, phoneNumber);
			var expected = await _customerContext.Customers.Find(filter).ToListAsync();
			//Assert
			Generated.Should().BeEquivalentTo(expected);
		}
		[Fact]
		public async Task CustomerRepository_ShouldBeAbleTo_CreateCustomerAsync()
		{
			//Arrange
			CustomerRepositoryTestBuilder _CustomerRepositoryTestBuilder = new CustomerRepositoryTestBuilder();
			CustomerRepository _CustomerRepository = _CustomerRepositoryTestBuilder.Build();
			CustomerContext _customerContext = _CustomerRepositoryTestBuilder.customerContext;
			Customer customer = _CustomerRepositoryTestBuilder.newCustomer;
			//Act 
			var Generated = await _customerContext.Customers.Find(c => c.Id.Equals(customer.Id)).FirstOrDefaultAsync();
			await _CustomerRepository.CreateCustomer(customer);
			//Assert
			Generated.Should().BeEquivalentTo(customer);
		}
		[Fact]
		public async Task CustomerRepository_ShouldBeAbleTo_UpdateCustomerAsync()
		{
			//Arrange
			CustomerRepositoryTestBuilder _CustomerRepositoryTestBuilder = new CustomerRepositoryTestBuilder();
			CustomerRepository _CustomerRepository = _CustomerRepositoryTestBuilder.Build();
			Customer customer = _CustomerRepositoryTestBuilder.newCustomer;
			//Act 
			bool done = await _CustomerRepository.UpdateCustomer(customer);
			//Assert
			done.Should().BeTrue();
		}

		[Fact]
		public async Task CustomerRepository_ShouldBeAbleTo_DeleteCustomerAsync()
		{
			//Arrange
			CustomerRepositoryTestBuilder _CustomerRepositoryTestBuilder = new CustomerRepositoryTestBuilder();
			CustomerRepository _CustomerRepository = _CustomerRepositoryTestBuilder.Build();
			string id = "602d2149e773f2a3990b47f5";
			//Act 
			bool done = await _CustomerRepository.DeleteCustomer(id);
			//Assert
			done.Should().BeTrue();
		}

	}
}
