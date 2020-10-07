using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace CentricaTestServer.DataAccess
{
    // TEMPORARY FOR TESTING ONLY
    public static class Constants
    {
        //private static readonly IConfiguration _configuration;
        //public static readonly string conString = _configuration.GetConnectionString("DB_CentricaTest");
        public static readonly string conString = "Server=DESKTOP-FN6D56T;Database=CentricaTest;Trusted_Connection=True;MultipleActiveResultSets=true";
    }
}
