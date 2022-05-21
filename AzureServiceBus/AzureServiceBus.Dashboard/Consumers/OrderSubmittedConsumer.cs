using AzureServiceBus.Messages.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureServiceBus.Dashboard.Consumers
{
    public class OrderSubmittedConsumer : IConsumer<OrderSubmitted>
    {
        private readonly ILogger<OrderSubmittedConsumer> _logger;

        public OrderSubmittedConsumer(ILogger<OrderSubmittedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<OrderSubmitted> context)
        {
            _logger.LogInformation("Order with ID {0} submitted. Created on {1}", context.Message.OrderId, context.Message.Created.ToString("dd.MM.yyyy"));

            return Task.CompletedTask;
        }
    }
}
