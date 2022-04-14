using Castle.Core.Logging;
using Customer_service_app.Data;
using Customer_service_app.Repositories;
using CustomerTests.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xunit;

namespace Customer_service_app.Controllers
{
	public class CustomerControllerTests
	{
		//CAN'T MOCK ILOGGER!

		//[Fact]
		//public void CustomersController_ShouldGetCustomers()
		//{
		//	// Arrange
		//	CustomerRepositoryTestBuilder _CustomerRepositoryTestBuilder = new CustomerRepositoryTestBuilder();
		//	CustomerRepository _CustomerRepository = _CustomerRepositoryTestBuilder.Build();
		//	ILogger _logger;
		//	var CustomersController = new CustomersController(_CustomerRepository,_logger);
		//	var customer = new Customer();

		//	// Act
		//	ActionResult<Post> result = CustomersController.CreateCustomer();

		//	// Assert
		//	Post createdPost = result.Value;
		//	Assert.NotNull(createdPost);
		//}
	}
}
