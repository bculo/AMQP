using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQ.Consumer.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public int Amount { get; set; }
    }
}
