using CRUD.CQRS.ApplicationService.Commands;
using CRUD.CQRS.ApplicationService.Common.DTOs;
using CRUD.CQRS.ApplicationService.Services;
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

        [HttpGet("IsEmailUniqe")]
        public bool IsEmailUniqe(string email)
        {
            return _customerService.IsEmailUniqe(email);
        }

        [HttpPost(Name = "AddNewCustomer")]
        public async Task<IActionResult> AddNewCustomer([FromBody] CustomerDTO customer)
        {
            if (IsEmailUniqe(customer.Email))
            {
                var model = new CreateCustomerCommand(customer);
                return Ok(await _mediator.Send(model));
            }
            return BadRequest();
        }
    }
}