using AzureServiceBus.Messages.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureServiceBus.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingController : ControllerBase
    {

        private readonly ILogger<ShoppingController> _logger;
        private readonly ISendEndpointProvider _endPointProvider;

        public ShoppingController(ILogger<ShoppingController> logger, ISendEndpointProvider endPointProvider)
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
                    
            await endpoint.Send(new SubmitOrder
            {
                OrderId = orderId,
                Amount = new Random().Next(50, 1000)
            });
            

            return NoContent();
        }
    }
}
