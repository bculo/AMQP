using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Messages.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQ.Producer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {

        private readonly ILogger<TestController> _logger;
        private readonly ISendEndpointProvider _endPointProvider;

        public TestController(ILogger<TestController> logger, ISendEndpointProvider endPointProvider)
        {
            _logger = logger;
            _endPointProvider = endPointProvider;
        }

        [HttpGet]
        public IActionResult Test()
        {
            return Ok("Test");
        }

        [HttpGet("SubmitOrder")]
        public async Task<IActionResult> SubmitOrder()
        {
            Guid orderId = Guid.NewGuid();

            _logger.LogInformation("Submitting order with ID {0}", orderId.ToString());

            var endpoint = await _endPointProvider.GetSendEndpoint(new Uri("queue:order-submit"));

            await endpoint.Send(new OrderSubmit
            {
                OrderId = orderId,
                Amount = new Random().Next(50, 1000)
            });

            return NoContent();
        }
    }
}
