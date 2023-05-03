using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CarDealershipASPNETMVC.Data
{
    public partial class DataAccess
    {
        // - - - - - - - Sex - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Sex - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Sex - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Sex - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        //GetAllData
        public async Task<List<SexModel>> SexsViewData()
        {
            List<SexModel> listSexsAllData = new List<SexModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spSexSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SexModel sex = new SexModel();
                                sex.SexId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                sex.SexName = reader.IsDBNull(1) ? null : reader.GetString(1);

                                listSexsAllData.Add(sex);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            return await Task.Run(() =>
            {
                return listSexsAllData;
            });
        }

        //GetAllData, Search
        public async Task<List<SexModel>> SexsViewData(SexModel sexsSearch)
        {
            List<SexModel> listSexsSearchResult = new List<SexModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spSexSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SexId", sexsSearch.SexId);
                        command.Parameters.AddWithValue("@SexName", sexsSearch.SexName);

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SexModel sex = new SexModel();
                                sex.SexId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                sex.SexName = reader.IsDBNull(1) ? null : reader.GetString(1);

                                listSexsSearchResult.Add(sex);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            return await Task.Run(() =>
            {
                return listSexsSearchResult;
            });
        }

        // Update Or Insert
        public async Task SexsUpdateOrInsert(SexModel insertedSex)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spSexUpdateOrInsert]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@SexId", insertedSex.SexId);
                        command.Parameters.AddWithValue("@SexName", insertedSex.SexName);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        // Delete
        public async Task SexsDelete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spSexDelete]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SexId", id);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

    }
}
