using Application.Features.Customers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RESTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ISender _sender;
        public CustomerController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> StoreProduct(CreateCustomerCommand command)
        {
            return Ok(await _sender.Send(command));
        }
    }
}
