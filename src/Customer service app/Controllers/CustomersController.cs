using Customer_service_app.Data;
using Customer_service_app.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Customer_service_app.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class CustomersController : ControllerBase
	{
		private readonly ICustomerRepository _cusomerRepository;
		private readonly ILogger _logger;

		public CustomersController(ICustomerRepository cusomerRepository, ILogger logger)
		{
			_cusomerRepository = cusomerRepository;
			_logger = logger;
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Customer>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
		{
			var Customers = await _cusomerRepository.GetCustomers();
			return Ok(Customers);
		}

		[HttpGet("{id:length(24)}", Name = "GetCustomerById")]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<Customer>> GetCustomerById(string id)
		{
			var Customer = await _cusomerRepository.GetCustomerById(id);
			if (Customer == null)
			{
				_logger.LogError($"Customer with id : {id}, not found.");
				return NotFound();
			}
			return Ok(Customer);
		}

		//[Route("[action]/{LastName}", Name = "GetCustomerByLastName")]
		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Customer>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<Customer>>> GetCustomerByLastName(string category)
		{
			var Customer = await _cusomerRepository.GetCustomerByLastName(category);
			return Ok(Customer);
		}

		//[Route("[action]/{PhoneNumber}", Name = "GetCustomerByPhoneNumber")]
		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Customer>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<Customer>>> GetCustomerByPhoneNumber(string category)
		{
			var Customer = await _cusomerRepository.GetCustomerByLastName(category);
			return Ok(Customer);
		}

		[HttpPost]
		[ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer Customer)
		{
			await _cusomerRepository.CreateCustomer(Customer);

			return CreatedAtRoute("GetCustomer", new { id = Customer.Id }, Customer);
		}

		[HttpPut]
		[ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> UpdateCustomer([FromBody] Customer Customer)
		{
			return Ok(await _cusomerRepository.UpdateCustomer(Customer));
		}

		[HttpDelete("{id:length(24)}", Name = "DeleteCustomer")]
		[ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> DeleteCustomer(string id)
		{
			return Ok(await _cusomerRepository.DeleteCustomer(id));
		}

	}
}
