using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Messages.Commands
{
    public class OrderSubmit
    {
        public Guid OrderId { get; set; }
        public int Amount { get; set; }
    }
}
