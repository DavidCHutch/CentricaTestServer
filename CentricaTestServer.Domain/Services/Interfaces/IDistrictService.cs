using CentricaTestServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentricaTestServer.Domain.Services.Interfaces
{
    public interface IDistrictService : IDataService<District, string>
    {
        Task<IEnumerable<Salesman>> GetAllSalesmenInDistrict(string districtID);
    }
}
