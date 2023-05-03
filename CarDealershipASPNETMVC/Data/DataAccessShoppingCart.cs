using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CarDealershipASPNETMVC.Data
{
    public partial class DataAccess
    {

        // - - - - - - - ShoppingCart - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - ShoppingCart - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - ShoppingCart - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - ShoppingCart - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        public async Task CreateShoppingCartTable(int UserId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipShoppingCartDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spXCreateShoppingCartTable]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserId", UserId);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

        }

        public async Task<List<OrderModel>> AllDataShoppingCartTable(int UserId)
        {
            List<OrderModel> listShoppingCartAllData = new List<OrderModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipShoppingCartDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spXAllDataShoppingCartTable]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserId", UserId);

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OrderModel order = new OrderModel();
                                order.OrderId = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                order.CustomerId = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                                order.SalesPersonId = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                                order.ProductId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                                order.Quantity = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                                order.OrderStatusId = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                                order.Discount = reader.IsDBNull(6) ? 0 : reader.GetDouble(6);

                                listShoppingCartAllData.Add(order);
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
                return listShoppingCartAllData;
            });
        }

        public async Task InsertShoppingCart(OrderModel insertedOrder)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipShoppingCartDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spXInsertShoppingCartTable]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserId", insertedOrder.UserId);
                        command.Parameters.AddWithValue("@ProductId", insertedOrder.ProductId);
                        command.Parameters.AddWithValue("@Quantity", insertedOrder.Quantity);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

        }

        public async Task UpdateShoppingCartTable(OrderModel insertedOrder)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipShoppingCartDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spXUpdateShoppingCartTable]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserId", insertedOrder.UserId);
                        command.Parameters.AddWithValue("@OrderId", insertedOrder.OrderId);
                        command.Parameters.AddWithValue("@Quantity", insertedOrder.Quantity);
                        command.Parameters.AddWithValue("@CustomerId", insertedOrder.CustomerId);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

        }

        public async Task DeleteAllRowsShoppingCartTable(int UserId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipShoppingCartDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spXDeleteAllRowsShoppingCartTable]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserId", UserId);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

        }

        public async Task DeleteRowShoppingCartTable(int id, int UserId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipShoppingCartDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spXDeleteRowShoppingCartTable]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserId", UserId);
                        command.Parameters.AddWithValue("@OrderId", id);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public async Task<int> ShoppingCartCustomerIdNullCount(int UserId)
        {
            int customerIdCount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipShoppingCartDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("spShoppingCartCustomerIdNullCount", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserId", UserId);

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customerIdCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            return await Task.Run(() => { return customerIdCount; });
        }

    }
}
