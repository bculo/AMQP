using AzureServiceBus.Messages.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureServiceBus.Dashboard.Consumers
{
    public class OrderSubmitConsumer : IConsumer<SubmitOrder>
    {
        private readonly ILogger<OrderSubmitConsumer> _logger;

        public OrderSubmitConsumer(ILogger<OrderSubmitConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<SubmitOrder> context)
        {
            _logger.LogInformation("HELLO FROM ADMIN DASHBOARD");

            return Task.CompletedTask;
        }
    }
}
