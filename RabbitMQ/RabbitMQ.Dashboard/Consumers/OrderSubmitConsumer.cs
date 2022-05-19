using MassTransit;
using Microsoft.Extensions.Logging;
using RabbitMQ.Messages.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQ.Dashboard.Consumers
{
    public class OrderSubmitConsumer : IConsumer<OrderSubmit>
    {
        private readonly ILogger<OrderSubmitConsumer> _logger;

        public OrderSubmitConsumer(ILogger<OrderSubmitConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<OrderSubmit> context)
        {
            //THIS SHOULD NOT EXECUTE, TEST PURPOSE
            _logger.LogInformation("HELLO FROM ADMIN DASHBOARD");

            return Task.CompletedTask;
        }
    }
}
