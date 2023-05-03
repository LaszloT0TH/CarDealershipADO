using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CarDealershipASPNETMVC.Data
{
    public partial class DataAccess
    {
        // - - - - - - - SettingsSpokenLangues - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - SettingsSpokenLangues - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - SettingsSpokenLangues - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - SettingsSpokenLangues - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        //GetAllData
        public async Task<List<SpokenLanguesModel>> SpokenLanguesViewData()
        {
            List<SpokenLanguesModel> listSpokenLanguesAllData = new List<SpokenLanguesModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spSpokenLanguesSearchDynamicSQL]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SpokenLanguesModel spokenLangues = new SpokenLanguesModel();
                                spokenLangues.SpokenLanguesId = reader.GetInt32(0);
                                spokenLangues.SpokenLanguesName = reader.GetString(1);
                                listSpokenLanguesAllData.Add(spokenLangues);
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
                return listSpokenLanguesAllData;
            });
        }

        //GetAllData, Search
        public async Task<List<SpokenLanguesModel>> SpokenLanguesViewData(SpokenLanguesModel spokenLangues)
        {
            List<SpokenLanguesModel> listSpokenLanguesAllData = new List<SpokenLanguesModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spSpokenLanguesSearchDynamicSQL]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SpokenLanguesId", spokenLangues.SpokenLanguesId);
                        command.Parameters.AddWithValue("@SpokenLanguesName", spokenLangues.SpokenLanguesName);

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SpokenLanguesModel spLangues = new SpokenLanguesModel();
                                spLangues.SpokenLanguesId = reader.GetInt32(0);
                                spLangues.SpokenLanguesName = reader.GetString(1);
                                listSpokenLanguesAllData.Add(spLangues);
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
                return listSpokenLanguesAllData;
            });
        }

        // Update Or Insert
        public async Task SpokenLanguesUpdateOrInsert(SpokenLanguesModel spokenLangues)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spSpokenLanguesUpdateOrInsert]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SpokenLanguesId", spokenLangues.SpokenLanguesId);
                        command.Parameters.AddWithValue("@SpokenLanguesName", spokenLangues.SpokenLanguesName);

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
        public async Task SpokenLanguesDelete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spSpokenLanguesDelete]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SpokenLanguesId", id);

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
