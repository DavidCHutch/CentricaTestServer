using CentricaTestServer.Domain.Models;
using CentricaTestServer.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentricaTestServer.DataAccess.Services.Interfaces
{
    public interface IDistrictService : IDataService<District, string>
    {
        Task<IEnumerable<Salesman>> GetAllSalesmenInDistrict(string districtID);
    }
}
