using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureServiceBus.Messages.Contracts
{
    public class SubmitOrder
    {
        public Guid OrderId { get; set; }
        public int Amount { get; set; }
    }
}
