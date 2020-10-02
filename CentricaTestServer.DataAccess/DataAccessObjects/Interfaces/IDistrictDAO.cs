using CentricaTestServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentricaTestServer.DataAccess.DataAccessObjects.Interfaces
{
    public interface IDistrictDAO : IDataAccessObject<District, string>
    {
        Task<IEnumerable<Salesman>> GetAllSalesmanInDistrict(string id);

        Task<IEnumerable<Store>> GetAllStoresInDistrict(string id);

        Task<Salesman> AddSalesmanToDistrict(string id);

        Task<IEnumerable<Salesman>> AddSalesmanToDistrict(IEnumerable<string> id);

        Task<Salesman> RemoveSalesmanFromDistrict(string id);

        Task<IEnumerable<Salesman>> RemoveSalesmanFromDistrict(IEnumerable<string> id);

        Task<Salesman> SwapPrimarySalesman(string id);
    }
}
