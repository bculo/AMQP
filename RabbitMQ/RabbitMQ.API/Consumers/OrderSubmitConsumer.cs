using MassTransit;
using Microsoft.Extensions.Logging;
using RabbitMQ.Consumer.Contracts;
using RabbitMQ.Consumer.Entities;
using RabbitMQ.Messages.Commands;
using RabbitMQ.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQ.Consumer.Consumers
{
    public class OrderSubmitConsumer : IConsumer<OrderSubmit>
    {
        private readonly ILogger<OrderSubmitConsumer> _logger;
        private readonly IOrderRepository _repo;

        public OrderSubmitConsumer(ILogger<OrderSubmitConsumer> logger, IOrderRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task Consume(ConsumeContext<OrderSubmit> context)
        {
            _logger.LogInformation("Order with ID {0} received");

            var order = await PrepareOrder(context.Message);

            _logger.LogInformation("Order with ID {0} saved");

            await context.Publish(new OrderSubmitted
            {
                OrderId = order.Id,
                Created = order.Created,
                Amount = order.Amount
            });
        }

        public async Task<Order> PrepareOrder(OrderSubmit submittedOrder)
        {
            var newOrder = new Order { Id = submittedOrder.OrderId, Amount = submittedOrder.Amount };

            await _repo.AddOrder(newOrder);

            await Task.Delay(5000);

            return newOrder;
        }
    }
}
