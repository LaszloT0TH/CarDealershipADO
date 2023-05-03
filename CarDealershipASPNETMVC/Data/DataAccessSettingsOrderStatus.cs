using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CarDealershipASPNETMVC.Data
{
    public partial class DataAccess
    {
        // - - - - - - - OrderStatus - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - OrderStatus - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - OrderStatus - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - OrderStatus - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        //GetAllData
        public async Task<List<OrderStatusModel>> OrderStatusViewData()
        {
            List<OrderStatusModel> listOrderStatusAllData = new List<OrderStatusModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spOrderStatusSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                while (reader.Read())
                                {
                                    OrderStatusModel oS = new OrderStatusModel();
                                    oS.OrderStatusId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                    oS.OrderStatusName = reader.IsDBNull(1) ? null : reader.GetString(1);

                                    listOrderStatusAllData.Add(oS);
                                }
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
                return listOrderStatusAllData;
            });
        }

        //GetAllData, Search
        public async Task<List<OrderStatusModel>> OrderStatusViewData(OrderStatusModel orderStatusSearch)
        {
            List<OrderStatusModel> listOrderStatusSearchResult = new List<OrderStatusModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spOrderStatusSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@OrderStatusId", orderStatusSearch.OrderStatusId);
                        command.Parameters.AddWithValue("@OrderStatusName", orderStatusSearch.OrderStatusName);

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OrderStatusModel oS = new OrderStatusModel();
                                oS.OrderStatusId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                oS.OrderStatusName = reader.IsDBNull(1) ? null : reader.GetString(1);

                                listOrderStatusSearchResult.Add(oS);
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
                return listOrderStatusSearchResult;
            });
        }

        // Update Or Insert
        public async Task OrderStatusUpdateOrInsert(OrderStatusModel insertedOrderStatus)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spOrderStatusUpdateOrInsert]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@OrderStatusId", insertedOrderStatus.OrderStatusId);
                        command.Parameters.AddWithValue("@OrderStatusName", insertedOrderStatus.OrderStatusName);

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
        public async Task OrderStatusDelete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spOrderStatusDelete]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@OrderStatusId", id);

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
