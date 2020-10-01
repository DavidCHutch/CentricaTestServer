using System;
using System.Collections.Generic;
using System.Text;

namespace CentricaTestServer.Domain.Models
{
    public class Product
    {
        public Guid ID { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string Depth { get; set; }
        public string MeassureUnit { get; set; }
        public string Weight { get; set; }
        public string WeightUnit { get; set; }
    }
}
