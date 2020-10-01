using System;
using System.Collections.Generic;
using System.Text;

namespace CentricaTestServer.Domain.Models
{
    public class District
    {
        public Guid ID { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public IEnumerable<Store> Stores { get; set; }
    }
}
