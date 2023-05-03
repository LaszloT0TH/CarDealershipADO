using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CarDealershipASPNETMVC.Data
{
    public partial class DataAccess
    {
        // - - - - - - - Gearbox - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Gearbox - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Gearbox - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Gearbox - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        //GetAllData
        public async Task<List<GearboxModel>> GearboxsViewData()
        {
            List<GearboxModel> listGearboxAllData = new List<GearboxModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spGearboxSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GearboxModel gearbox = new GearboxModel();
                                gearbox.GearboxId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                gearbox.GearboxName = reader.IsDBNull(1) ? null : reader.GetString(1);

                                listGearboxAllData.Add(gearbox);
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
                return listGearboxAllData;
            });
        }

        //GetAllData, Search
        public async Task<List<GearboxModel>> GearboxsViewData(GearboxModel gearboxSearch)
        {
            List<GearboxModel> listGearboxSearchResult = new List<GearboxModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spGearboxSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@GearboxId", gearboxSearch.GearboxId);
                        command.Parameters.AddWithValue("@GearboxName", gearboxSearch.GearboxName);

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GearboxModel gearbox = new GearboxModel();
                                gearbox.GearboxId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                gearbox.GearboxName = reader.IsDBNull(1) ? null : reader.GetString(1);

                                listGearboxSearchResult.Add(gearbox);
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
                return listGearboxSearchResult;
            });
        }

        // Update Or Insert
        public async Task GearboxsUpdateOrInsert(GearboxModel InsertedGearbox)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spGearboxUpdateOrInsert]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@GearboxId", InsertedGearbox.GearboxId);
                        command.Parameters.AddWithValue("@GearboxName", InsertedGearbox.GearboxName);

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
        public async Task GearboxsDelete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spGearboxDelete]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@GearboxId", id);

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
