using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CarDealershipASPNETMVC.Data
{
    public partial class DataAccess
    {
        // - - - - - - - CarAccessoriesUnit - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - CarAccessoriesUnit - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - CarAccessoriesUnit - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - CarAccessoriesUnit - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        //GetAllData
        public async Task<List<CarAccessoriesUnitModel>> CarAccessoriesUnitsViewData()
        {
            List<CarAccessoriesUnitModel> listCAUAllData = new List<CarAccessoriesUnitModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spCarAccessoriesUnitSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CarAccessoriesUnitModel CAU = new CarAccessoriesUnitModel();
                                CAU.CAUId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                CAU.UnitName = reader.IsDBNull(1) ? null : reader.GetString(1);

                                listCAUAllData.Add(CAU);
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
                return listCAUAllData;
            });
        }

        //GetAllData, Search
        public async Task<List<CarAccessoriesUnitModel>> CarAccessoriesUnitsViewData(CarAccessoriesUnitModel CAUsSearch)
        {
            List<CarAccessoriesUnitModel> listCAUsSearchResult = new List<CarAccessoriesUnitModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spCarAccessoriesUnitSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CAUId", CAUsSearch.CAUId);
                        command.Parameters.AddWithValue("@UnitName", CAUsSearch.UnitName);

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CarAccessoriesUnitModel CAU = new CarAccessoriesUnitModel();
                                CAU.CAUId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                CAU.UnitName = reader.IsDBNull(1) ? null : reader.GetString(1);

                                listCAUsSearchResult.Add(CAU);
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
                return listCAUsSearchResult;
            });
        }

        // Update Or Insert
        public async Task CarAccessoriesUnitsUpdateOrInsert(CarAccessoriesUnitModel InsertedCAU)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spCarAccessoriesUnitUpdateOrInsert]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@CAUId", InsertedCAU.CAUId);
                        command.Parameters.AddWithValue("@UnitName", InsertedCAU.UnitName);

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
        public async Task CarAccessoriesUnitsDelete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spCarAccessoriesUnitDelete]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CAUId", id);

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
