using System;
using System.Collections.Generic;
using System.Text;

namespace CentricaTestServer.Domain.Models
{
    public class Address
    {
        public Guid ID { get; set; } 
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Steet { get; set; }
        public string SteetNumber { get; set; }
        public string Floor { get; set; }
    }
}
