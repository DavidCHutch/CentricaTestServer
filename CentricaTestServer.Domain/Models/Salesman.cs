using System;
using System.Collections.Generic;
using System.Text;

namespace CentricaTestServer.Domain.Models
{
    public class Salesman
    {
        public Guid ID { get; set; }
        public string SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Address address { get; set; }
    }
}
