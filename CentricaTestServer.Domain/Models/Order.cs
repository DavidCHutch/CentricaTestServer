using System;
using System.Collections.Generic;
using System.Text;

namespace CentricaTestServer.Domain.Models
{
    public class Order
    {
        public Guid ID { get; set; }
        public DateTime OrderDate { get; set; }
        public Store Store { get; set; }
        public Salesman Salesman { get; set; }
        public IEnumerable<OrderProduct> OrderProducts { get; set; }
    }
}
