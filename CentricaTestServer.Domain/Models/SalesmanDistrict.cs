using System;
using System.Collections.Generic;
using System.Text;

namespace CentricaTestServer.Domain.Models
{
    public class SalesmanDistrict
    {
        public Salesman Salesman { get; set; }
        public District District { get; set; }
        public bool IsPrimary { get; set; }
    }
}
