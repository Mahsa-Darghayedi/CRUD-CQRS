using CRUD.CQRS.ApplicationService.Commands;
using CRUD.CQRS.ApplicationService.Common.DTOs;
using CRUD.CQRS.ApplicationService.Services;
using CRUD.CQRS.ApplicationService.Services.Customer.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(IMediator mediator, ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _mediator = mediator;
            _logger = logger;
            _customerService = customerService;
        }



        [HttpPost(Name = "AddNewCustomer")]
        public async Task<IActionResult> AddNewCustomer([FromBody] CustomerDTO customer)
        {
            if (_customerService.IsEmailUniqe(customer.Email))
            {
                var model = new CreateCustomerCommand(customer);
                return Ok(await _mediator.Send(model));
            }
            return BadRequest("the entered email already exists.");
        }

        [HttpPut(Name = "UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerDTO customer)
        {
            var model = new UpdateCustomerCommand(customer);
            return Ok(await _mediator.Send(model));
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCustomerByID([FromQuery] int id)
        {
            var model = new GetCustomerByIdQuery(id);
            return Ok(await _mediator.Send(model));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var model = new GetAllCustomersQuery();
            return Ok(await _mediator.Send(model));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomerByID([FromQuery] int ID)
        {
            var model = new DeleteCustomerByIDCommand(ID);
            return Ok(await _mediator.Send(model));
        }
    }
}