using CustomerApp.API.Common;
using CustomerApp.Core.Features.Customer.Delete;
using CustomerApp.Core.Features.Customer.Get;
using CustomerApp.Core.Features.Customer.Post;
using CustomerApp.Core.Features.Customer.Put;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerApp.API.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(IMediator mediator, ILogger<CustomerController> logger) : base(mediator) 
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("GetCustomers")]
        public async Task<IActionResult> Get([FromQuery] ResourceParameters resourceParameters)
        {
            return Ok(APIResponse<GetCustomerResponse>.Success(await _mediator.Send(new GetCustomerRequest { ResourceParameters = resourceParameters }), ""));
        }

        [HttpPost]
        [Route("SaveCustomer")]
        public async Task<IActionResult> Post([FromBody] PostCustomerCommand command)
        {
            return Ok(APIResponse<PostCustomerResponse>.Success(await _mediator.Send(command), "Saved"));
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public async Task<IActionResult> Put([FromBody] PutCustomerCommand command)
        {
            return Ok(APIResponse<PutCustomerResponse>.Success(await _mediator.Send(command), ""));
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(APIResponse<DeleteCustomerResponse>.Success(await _mediator.Send(new DeleteCustomerCommand { Id = id }), ""));
        }
    }
}
