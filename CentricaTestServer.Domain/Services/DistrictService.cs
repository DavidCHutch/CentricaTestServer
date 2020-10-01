using CentricaTestServer.Domain.Models;
using CentricaTestServer.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentricaTestServer.Domain.Services
{
    public class DistrictService : IDistrictService
    {
        public Task<District> Create(District entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<District> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<District>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Salesman>> GetAllSalesmenInDistrict(string districtID)
        {
            throw new NotImplementedException();
        }

        public Task<District> Update(string id, District entity)
        {
            throw new NotImplementedException();
        }
    }
}
