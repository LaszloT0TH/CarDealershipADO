using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CarDealershipASPNETMVC.Data
{
    public partial class DataAccess
    {
        //GetAllData
        public async Task<List<CarAccessoriesModel>> CarAccessoriesViewData()
        {
            List<CarAccessoriesModel> listCarAccessoriesAllData = new List<CarAccessoriesModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spCarAccessoriesSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CarAccessoriesModel carAccessories = new CarAccessoriesModel();
                                carAccessories.CAId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                carAccessories.ProductName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                carAccessories.CAPGName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                carAccessories.QuantityOfStock = reader.IsDBNull(3) ? null : reader.GetInt32(3);
                                carAccessories.MinimumStockQuantity = reader.IsDBNull(4) ? null : reader.GetInt32(4);
                                carAccessories.NetSellingPrice = reader.IsDBNull(5) ? null : reader.GetDouble(5);
                                carAccessories.SalesUnit = reader.IsDBNull(6) ? null : reader.GetDouble(6);
                                carAccessories.UnitPrice = reader.IsDBNull(7) ? null : reader.GetDouble(7);
                                carAccessories.UnitName = reader.IsDBNull(8) ? null : reader.GetString(8);
                                carAccessories.LastUpdateTime = reader.IsDBNull(9) ? null : reader.GetDateTime(9);
                                carAccessories.Brand = reader.IsDBNull(10) ? null : reader.GetString(10);
                                carAccessories.CreationDate = reader.IsDBNull(11) ? null : reader.GetDateTime(11);
                                carAccessories.Description = reader.IsDBNull(12) ? null : reader.GetString(12);
                                carAccessories.Version = reader.IsDBNull(13) ? null : reader.GetInt32(13);

                                listCarAccessoriesAllData.Add(carAccessories);
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
                return listCarAccessoriesAllData;
            });
        }

        //GetAllData, Search
        public async Task<List<CarAccessoriesModel>> CarAccessoriesViewData(CarAccessoriesModel carAccessoriesSearch)
        {
            List<CarAccessoriesModel> listCarAccessoriesSearchResult = new List<CarAccessoriesModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spCarAccessoriesSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CAID", carAccessoriesSearch.CAId);
                        command.Parameters.AddWithValue("@ProductName", carAccessoriesSearch.ProductName);
                        command.Parameters.AddWithValue("@CAPGName", carAccessoriesSearch.CAPGName);
                        command.Parameters.AddWithValue("@QuantityOfStock", carAccessoriesSearch.QuantityOfStock);
                        command.Parameters.AddWithValue("@MinimumStockQuantity", carAccessoriesSearch.MinimumStockQuantity);
                        command.Parameters.AddWithValue("@NetSellingPrice", carAccessoriesSearch.NetSellingPrice);
                        command.Parameters.AddWithValue("@SalesUnit", carAccessoriesSearch.SalesUnit);
                        command.Parameters.AddWithValue("@UnitPrice", carAccessoriesSearch.UnitPrice);
                        command.Parameters.AddWithValue("@UnitName", carAccessoriesSearch.UnitName);
                        command.Parameters.AddWithValue("@LastUpdateTime", carAccessoriesSearch.LastUpdateTime);
                        command.Parameters.AddWithValue("@Brand", carAccessoriesSearch.Brand);
                        command.Parameters.AddWithValue("@CreationDate", carAccessoriesSearch.CreationDate);
                        command.Parameters.AddWithValue("@Description", carAccessoriesSearch.Description);
                        command.Parameters.AddWithValue("@Version", carAccessoriesSearch.Version);

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CarAccessoriesModel carAccessories = new CarAccessoriesModel();
                                carAccessories.CAId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                carAccessories.ProductName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                carAccessories.CAPGName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                carAccessories.QuantityOfStock = reader.IsDBNull(3) ? null : reader.GetInt32(3);
                                carAccessories.MinimumStockQuantity = reader.IsDBNull(4) ? null : reader.GetInt32(4);
                                carAccessories.NetSellingPrice = reader.IsDBNull(5) ? null : reader.GetDouble(5);
                                carAccessories.SalesUnit = reader.IsDBNull(6) ? null : reader.GetDouble(6);
                                carAccessories.UnitPrice = reader.IsDBNull(7) ? null : reader.GetDouble(7);
                                carAccessories.UnitName = reader.IsDBNull(8) ? null : reader.GetString(8);
                                carAccessories.LastUpdateTime = reader.IsDBNull(9) ? null : reader.GetDateTime(9);
                                carAccessories.Brand = reader.IsDBNull(10) ? null : reader.GetString(10);
                                carAccessories.CreationDate = reader.IsDBNull(11) ? null : reader.GetDateTime(11);
                                carAccessories.Description = reader.IsDBNull(12) ? null : reader.GetString(12);
                                carAccessories.Version = reader.IsDBNull(13) ? null : reader.GetInt32(13);

                                listCarAccessoriesSearchResult.Add(carAccessories);
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
                return listCarAccessoriesSearchResult;
            });
        }

        // Update Or Insert
        public async Task CarAccessoriesUpdateOrInsert(CarAccessoriesModel insertedCarAccessories)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spCarAccessoriesUpdateOrInsert]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CarAccessoriesId", insertedCarAccessories.CAId);
                        command.Parameters.AddWithValue("@ProductName", insertedCarAccessories.ProductName);
                        command.Parameters.AddWithValue("@CAPGName", insertedCarAccessories.CAPGName);
                        command.Parameters.AddWithValue("@QuantityOfStock", insertedCarAccessories.QuantityOfStock);
                        command.Parameters.AddWithValue("@MinimumStockQuantity", insertedCarAccessories.MinimumStockQuantity);
                        command.Parameters.AddWithValue("@NetSellingPrice", insertedCarAccessories.NetSellingPrice);
                        command.Parameters.AddWithValue("@SalesUnit", insertedCarAccessories.SalesUnit);
                        command.Parameters.AddWithValue("@UnitPrice", insertedCarAccessories.UnitPrice);
                        command.Parameters.AddWithValue("@UnitName", insertedCarAccessories.UnitName);
                        command.Parameters.AddWithValue("@LastUpdateTime", insertedCarAccessories.LastUpdateTime);
                        command.Parameters.AddWithValue("@Brand", insertedCarAccessories.Brand);
                        command.Parameters.AddWithValue("@CreationDate", insertedCarAccessories.CreationDate);
                        command.Parameters.AddWithValue("@Description", insertedCarAccessories.Description);
                        command.Parameters.AddWithValue("@Version", insertedCarAccessories.Version);

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
        public async Task CarAccessoriesDelete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spCarAccessoriesDelete]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CarAccessoriesId", id);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }


        // - - -     help tables CarAccessories      - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // GetAllData, Search
        public async Task<List<CarAccessoriesProductGroupModel>> CarAccessoriesProductGroupViewData()
        {
            List<CarAccessoriesProductGroupModel> listCarAccessoriesProductGroupAllData = new List<CarAccessoriesProductGroupModel>();

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
                                CarAccessoriesProductGroupModel carAccessoriesProductGroup = new CarAccessoriesProductGroupModel();
                                carAccessoriesProductGroup.CAPGId = reader.GetInt32(0);
                                carAccessoriesProductGroup.CAPGName = reader.GetString(1);
                                listCarAccessoriesProductGroupAllData.Add(carAccessoriesProductGroup);
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
                return listCarAccessoriesProductGroupAllData;
            });
        }

        // GetAllData, Search
        public async Task<List<CarAccessoriesUnitModel>> CarAccessoriesUnitViewData()
        {
            List<CarAccessoriesUnitModel> listCarAccessoriesUnitAllData = new List<CarAccessoriesUnitModel>();

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
                                CarAccessoriesUnitModel carAccessoriesUnit = new CarAccessoriesUnitModel();
                                carAccessoriesUnit.CAUId = reader.GetInt32(0);
                                carAccessoriesUnit.UnitName = reader.GetString(1);
                                listCarAccessoriesUnitAllData.Add(carAccessoriesUnit);
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
                return listCarAccessoriesUnitAllData;
            });
        }



    }
}
