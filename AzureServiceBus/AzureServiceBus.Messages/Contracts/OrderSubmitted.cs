using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureServiceBus.Messages.Contracts
{
    public class OrderSubmitted
    {
        public Guid OrderId { get; set; }
        public DateTime Created { get; set; }
        public int Amount { get; set; }
    }
}
