using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CarDealershipASPNETMVC.Data
{
    public partial class DataAccess
    {
        // - - - - - - - CarAccessoriesProductGroup - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - CarAccessoriesProductGroup - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - CarAccessoriesProductGroup - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - CarAccessoriesProductGroup - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        //GetAllData
        public async Task<List<CarAccessoriesProductGroupModel>> CarAccessoriesProductGroupsViewData()
        {
            List<CarAccessoriesProductGroupModel> listCAPGAllData = new List<CarAccessoriesProductGroupModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spCarAccessoriesProductGroupSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CarAccessoriesProductGroupModel CAPG = new CarAccessoriesProductGroupModel();
                                CAPG.CAPGId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                CAPG.CAPGName = reader.IsDBNull(1) ? null : reader.GetString(1);

                                listCAPGAllData.Add(CAPG);
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
                return listCAPGAllData;
            });
        }

        //GetAllData, Search
        public async Task<List<CarAccessoriesProductGroupModel>> CarAccessoriesProductGroupsViewData(CarAccessoriesProductGroupModel sexsSearch)
        {
            List<CarAccessoriesProductGroupModel> listSexsSearchResult = new List<CarAccessoriesProductGroupModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spCarAccessoriesProductGroupSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CAPGId", sexsSearch.CAPGId);
                        command.Parameters.AddWithValue("@CAPGName", sexsSearch.CAPGName);

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CarAccessoriesProductGroupModel CAPG = new CarAccessoriesProductGroupModel();
                                CAPG.CAPGId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                CAPG.CAPGName = reader.IsDBNull(1) ? null : reader.GetString(1);

                                listSexsSearchResult.Add(CAPG);
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
        public async Task CarAccessoriesProductGroupsUpdateOrInsert(CarAccessoriesProductGroupModel insertedCAPG)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spCarAccessoriesProductGroupUpdateOrInsert]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@CAPGId", insertedCAPG.CAPGId);
                        command.Parameters.AddWithValue("@CAPGName", insertedCAPG.CAPGName);

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
        public async Task CarAccessoriesProductGroupsDelete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spCarAccessoriesProductGroupDelete]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CAPGId", id);

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
