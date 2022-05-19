using RabbitMQ.Consumer.Contracts;
using RabbitMQ.Consumer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQ.Consumer.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private static List<Order> _context = new List<Order>();

        public async Task AddOrder(Order newOrder)
        {
            _context.Add(newOrder);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return _context;
        }
    }
}
