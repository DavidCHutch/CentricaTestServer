using System;
using System.Collections.Generic;
using System.Text;

namespace CentricaTestServer.Domain.Models
{
    public class OrderProduct
    {
        public Guid ID { get; set; }
        public int Quantity { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
