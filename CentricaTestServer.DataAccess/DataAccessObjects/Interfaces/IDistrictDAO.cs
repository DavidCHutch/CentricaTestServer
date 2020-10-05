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

        Task<bool> AddSalesmanToDistrict(string id, string salesmanId);

        //Task<bool> AddSalesmanToDistrict(IEnumerable<string> id);

        Task<bool> RemoveSalesmanFromDistrict(string id, string salesmanId);

        Task<bool> RemoveSalesmanFromDistrict(IEnumerable<string> id, IEnumerable<string> salesmanId);

        Task<bool> SwapPrimarySalesmanInDistrict(string id, string promoteId, string demotedId);
    }
}
