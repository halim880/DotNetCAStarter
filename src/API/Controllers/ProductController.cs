using Application.Features.Products.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace RESTApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ISender _sender;
        public ProductController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public IActionResult StoreProduct(CreateProductCommand command)
        {
            _sender.Send(command);
            return Ok(command);
        }
    }
}
