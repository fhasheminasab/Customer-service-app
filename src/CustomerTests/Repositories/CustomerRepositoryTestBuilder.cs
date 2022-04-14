using Customer_service_app.Data;
using Customer_service_app.Entity;
using Customer_service_app.Repositories;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Moq;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
namespace CustomerTests.Repositories
{
	public class CustomerRepositoryTestBuilder
	{
		public Mock<ICustomerContext> mock_ICustomerContext = new();
		public CustomerContext customerContext;
		public Customer newCustomer;

		public CustomerRepositoryTestBuilder()
		{
			_setCustomerContext();
			_setCustomerFiller();
		}

		private void _setCustomerFiller()
		{
			newCustomer = new Customer();
			newCustomer.Id = "602d2149e773f2a3990b47a5";
			newCustomer.FirstName = "Ali";
			newCustomer.LastName = "Asqari";
			newCustomer.PhoneNumber = "09121110015";
		}

		private void _setCustomerContext()
		{
			IConfiguration _configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json").Build();
			this.customerContext = new(_configuration);
		}

		public CustomerRepository Build()
		{
			;
			//COULDN'T MOCK IMONGOCOLLECTION:
			mock_ICustomerContext.Setup(m => m.Customers).Returns(customerContext.Customers);
			CustomerRepository _CustomerRepository = new CustomerRepository(mock_ICustomerContext.Object);
			return _CustomerRepository;


		}

	}
}
