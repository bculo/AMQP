using AzureServiceBus.Messages.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureServiceBus.API.Consumers
{
    public class OrderSubmitConsumer : IConsumer<SubmitOrder>
    {
        private readonly ILogger<OrderSubmitConsumer> _logger;

        public OrderSubmitConsumer(ILogger<OrderSubmitConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<SubmitOrder> context)
        {
            _logger.LogInformation("Order with ID {0} received", context.Message.OrderId);

            await Task.Delay(new Random().Next(2000, 6000));

            _logger.LogInformation("Order with ID {0} saved", context.Message.OrderId);

            await context.Publish(new OrderSubmitted
            {
                OrderId = context.Message.OrderId,
                Created = DateTime.Now,
                Amount = context.Message.Amount
            });
        }

    }
}
