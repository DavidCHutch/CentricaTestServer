using CentricaTestServer.DataAccess.DataAccessObjects.Interfaces;
using CentricaTestServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CentricaTestServer.DataAccess.DataAccessObjects
{
    public class DistrictDAO : IDistrictDAO
    {
        public async Task<bool> AddSalesmanToDistrict(string id, string salesmanId)
        {
            bool didExecute = false;
            await using (SqlConnection _con = new SqlConnection(Constants.conString))
            {
                _con.Open();

                SqlCommand command = new SqlCommand("dbo.Add_SalesMan_To_District", _con);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@DistrictID", id));
                command.Parameters.Add(new SqlParameter("@SalesmanID", salesmanId));

                try
                {
                    int tempVal = await command.ExecuteNonQueryAsync();

                    if (tempVal >= 1)
                    {
                        didExecute = true;
                    }
                    else
                    {
                        didExecute = false;
                    }

                }
                catch (SqlException ex)
                {
                    didExecute = false;
                    throw ex;
                }
                finally
                {
                    _con.Close();
                }
            }
            return didExecute;
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

        public async Task<IEnumerable<Salesman>> GetAllSalesmanInDistrict(string id)
        {
            List<Salesman> result = new List<Salesman>();
            await using (SqlConnection _con = new SqlConnection(Constants.conString))
            {
                _con.Open();

                SqlCommand command = new SqlCommand("dbo.GetAll_SalesMan_In_District", _con);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@DistrictID", id));

                try
                {
                    await using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Address address = new Address()
                            {
                                ID = dataReader.GetGuid(dataReader.GetOrdinal("AddressID")),
                                Country = dataReader.GetValue(dataReader.GetOrdinal("Country"))?.ToString(),
                                PostalCode = dataReader.GetValue(dataReader.GetOrdinal("PostalCode"))?.ToString(),
                                City = dataReader.GetValue(dataReader.GetOrdinal("City"))?.ToString(),
                                Steet = dataReader.GetValue(dataReader.GetOrdinal("Street"))?.ToString(),
                                SteetNumber = dataReader.GetValue(dataReader.GetOrdinal("StreetNumber"))?.ToString(),
                                Floor = dataReader.GetValue(dataReader.GetOrdinal("Floor"))?.ToString()
                            };

                            Salesman salesman = new Salesman()
                            {
                                ID = dataReader.GetGuid(dataReader.GetOrdinal("SalesmanID")),
                                IsPrimary = dataReader.GetBoolean(dataReader.GetOrdinal("IsPrimary")),
                                FirstName = dataReader.GetString(dataReader.GetOrdinal("FirstName")),
                                LastName = dataReader.GetValue(dataReader.GetOrdinal("LastName"))?.ToString(),
                                Email = dataReader.GetString(dataReader.GetOrdinal("Email")),
                                Address = address,
                                BirthDate = dataReader.GetDateTime(dataReader.GetOrdinal("BirthDate")),
                                Salary = dataReader.GetDouble(dataReader.GetOrdinal("Salary")),
                                SSN = dataReader.GetString(dataReader.GetOrdinal("SSN")),
                            };
                            

                            result.Add(salesman);
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

        public async Task<IEnumerable<Store>> GetAllStoresInDistrict(string id)
        {
            List<Store> result = new List<Store>();
            await using (SqlConnection _con = new SqlConnection(Constants.conString))
            {
                _con.Open();

                SqlCommand command = new SqlCommand("dbo.GetAll_Stores_In_District", _con);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@DistrictID", id));

                try
                {
                    await using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Address address = new Address()
                            {
                                ID = dataReader.GetGuid(dataReader.GetOrdinal("AddressID")),
                                Country = dataReader.GetValue(dataReader.GetOrdinal("Country"))?.ToString(),
                                PostalCode = dataReader.GetValue(dataReader.GetOrdinal("PostalCode"))?.ToString(),
                                City = dataReader.GetValue(dataReader.GetOrdinal("City"))?.ToString(),
                                Steet = dataReader.GetValue(dataReader.GetOrdinal("Street"))?.ToString(),
                                SteetNumber = dataReader.GetValue(dataReader.GetOrdinal("StreetNumber"))?.ToString(),
                                Floor = dataReader.GetValue(dataReader.GetOrdinal("Floor"))?.ToString()
                            };

                            District district = new District()
                            {
                                ID = Guid.Parse(id)
                            };

                            Store store = new Store()
                            {
                                ID = dataReader.GetGuid(dataReader.GetOrdinal("ID")),
                                Number = dataReader.GetString(dataReader.GetOrdinal("Number")),
                                Name = dataReader.GetString(dataReader.GetOrdinal("Name")),
                                Address = address,
                                District = district
                            };


                            result.Add(store);
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

        public async Task<bool> RemoveSalesmanFromDistrict(string id, string salesmanId)
        {
            bool didExecute = false;
            await using (SqlConnection _con = new SqlConnection(Constants.conString))
            {
                _con.Open();

                SqlCommand command = new SqlCommand("dbo.Remove_Salesman_From_District", _con);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@DistrictID", id));
                command.Parameters.Add(new SqlParameter("@SalesmanID", salesmanId));

                try
                {
                    int tempVal = await command.ExecuteNonQueryAsync();

                    if (tempVal >= 1)
                    {
                        didExecute = true;
                    }
                    else
                    {
                        didExecute = false;
                    }

                }
                catch (SqlException ex)
                {
                    didExecute = false;
                    throw ex;
                }
                finally
                {
                    _con.Close();
                }
            }
            return didExecute;
        }

        public async Task<bool> RemoveSalesmanFromDistrict(IEnumerable<string> id, IEnumerable<string> salesmanId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Swaps the Current primary salesman to a new salesman within the same district
        /// </summary>
        /// <param name="id"></param>
        /// <param name="promoteId"></param>
        /// <param name="demoteId"></param>
        /// <returns></returns>
        public async Task<bool> SwapPrimarySalesmanInDistrict(string id, string promoteId, string demoteId)
        {
            bool didExecute = false;
            await using (SqlConnection _con = new SqlConnection(Constants.conString))
            {
                _con.Open();

                SqlCommand command = new SqlCommand("dbo.Swap_PrimarySalesMan_In_District", _con);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@DistrictID", id));
                command.Parameters.Add(new SqlParameter("@PromoteSM", promoteId)); 
                command.Parameters.Add(new SqlParameter("@DemoteSM", demoteId));

                try
                {
                    int tempVal = await command.ExecuteNonQueryAsync();

                    if(tempVal >= 1)
                    {
                        didExecute = true;
                    }
                    else
                    {
                        didExecute = false;
                    }
                        
                }
                catch (SqlException ex)
                {
                    didExecute = false;
                    throw ex;
                }
                finally
                {
                    _con.Close();
                }
            }
            return didExecute;
        }

        public Task<District> Update(string id, District entity)
        {
            throw new NotImplementedException();
        }
    }
}
