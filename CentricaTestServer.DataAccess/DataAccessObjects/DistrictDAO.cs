using CentricaTestServer.DataAccess.DataAccessObjects.Interfaces;
using CentricaTestServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CentricaTestServer.DataAccess.DataAccessObjects
{
    public class DistrictDAO : IDistrictDAO
    {
        public Task<Salesman> AddSalesmanToDistrict(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Salesman>> AddSalesmanToDistrict(IEnumerable<string> id)
        {
            throw new NotImplementedException();
        }

        public Task<District> Create(District entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<District> Get(string id)
        {
            District result = null;
            await using (SqlConnection _con = new SqlConnection(Constants.conString)) 
            {
                string sqlQuery = "SELECT * FROM District WHERE ID = @id";
                _con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, _con);
                
                //ANTI sql injection
                command.Parameters.Add(new SqlParameter("@id", id));

                try
                {
                    await using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            result = new District()
                            {
                                ID = dataReader.GetGuid(dataReader.GetOrdinal("ID")),
                                Number = dataReader.GetString(dataReader.GetOrdinal("Number")),
                                Name = dataReader.GetString(dataReader.GetOrdinal("Name")),
                            };
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    _con.Close();
                }
            }
            return result;
        }

        public async Task<IEnumerable<District>> GetAll()
        {
            List<District> result = new List<District>();
            await using(SqlConnection _con = new SqlConnection(Constants.conString))
            {
                string sqlQuery = "SELECT * FROM District";
                _con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, _con);

                try
                {
                    await using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            District district = new District()
                            {
                                ID = dataReader.GetGuid(dataReader.GetOrdinal("ID")),
                                Number = dataReader.GetString(dataReader.GetOrdinal("Number")),
                                Name = dataReader.GetString(dataReader.GetOrdinal("Name")),
                            };

                            result.Add(district);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    _con.Close();
                }
            } 

            return result;
        }

        public Task<IEnumerable<Salesman>> GetAllSalesmanInDistrict(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Store>> GetAllStoresInDistrict(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Salesman> RemoveSalesmanFromDistrict(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Salesman>> RemoveSalesmanFromDistrict(IEnumerable<string> id)
        {
            throw new NotImplementedException();
        }

        public Task<Salesman> SwapPrimarySalesman(string id)
        {
            throw new NotImplementedException();
        }

        public Task<District> Update(string id, District entity)
        {
            throw new NotImplementedException();
        }
    }
}
