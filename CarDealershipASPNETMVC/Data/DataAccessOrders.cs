using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CarDealershipASPNETMVC.Data
{
    public partial class DataAccess
    {
        // - - - - - - - Orders - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Orders - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Orders - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Orders - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        //GetAllData
        public async Task<List<OrderModel>> OrdersViewData()
        {
            List<OrderModel> listOrdersAllData = new List<OrderModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spOrdersSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OrderModel order = new OrderModel();
                                order.OrderId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                order.CustomerId = reader.IsDBNull(1) ? null : reader.GetInt32(1);
                                order.CustomerFirstName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                order.CustomerLastName = reader.IsDBNull(3) ? null : reader.GetString(3);
                                order.SalesPersonId = reader.IsDBNull(4) ? null : reader.GetInt32(4);
                                order.SalesPersonFirstName = reader.IsDBNull(5) ? null : reader.GetString(5);
                                order.SalesPersonLastName = reader.IsDBNull(6) ? null : reader.GetString(6);
                                order.ProductId = reader.IsDBNull(7) ? null : reader.GetInt32(7);
                                order.ProductGroup = reader.IsDBNull(8) ? null : reader.GetString(8);
                                order.ProductName = reader.IsDBNull(9) ? null : reader.GetString(9);
                                order.CarModel = reader.IsDBNull(10) ? null : reader.GetString(10);
                                order.CarColor = reader.IsDBNull(11) ? null : reader.GetString(11);
                                order.Quantity = reader.IsDBNull(12) ? null : reader.GetInt32(12);
                                order.OrderDate = reader.IsDBNull(13) ? null : reader.GetDateTime(13);
                                order.OrderStatusId = reader.IsDBNull(14) ? null : reader.GetInt32(14);
                                order.OrderStatusName = reader.IsDBNull(15) ? null : reader.GetString(15);
                                order.Discount = reader.IsDBNull(16) ? null : reader.GetDouble(16);
                                order.ShippedDate = reader.IsDBNull(17) ? null : reader.GetDateTime(17);
                                order.SaleAmount = reader.IsDBNull(18) ? null : reader.GetDouble(18);
                                order.SaleAmountPaid = reader.IsDBNull(19) ? null : reader.GetDouble(19);
                                order.TaxPercentageValue = reader.IsDBNull(20) ? null : reader.GetDouble(20);
                                order.OrderDate = reader.IsDBNull(21) ? null : reader.GetDateTime(21);

                                listOrdersAllData.Add(order);
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
                return listOrdersAllData;
            });
        }

        //GetAllData, Search
        public async Task<List<OrderModel>> OrdersViewData(OrderModel orderSearch)
        {
            List<OrderModel> listOrdersAllData = new List<OrderModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spOrdersSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@OrderId", orderSearch.OrderId);
                        command.Parameters.AddWithValue("@CustomerId", orderSearch.CustomerId);
                        command.Parameters.AddWithValue("@CustomerFirstName", orderSearch.@CustomerFirstName);
                        command.Parameters.AddWithValue("@CustomerLastName", orderSearch.CustomerLastName);
                        command.Parameters.AddWithValue("@SalesPersonId", orderSearch.SalesPersonId);
                        command.Parameters.AddWithValue("@SalesPersonFirstName", orderSearch.SalesPersonFirstName);
                        command.Parameters.AddWithValue("@SalesPersonLastName", orderSearch.SalesPersonLastName);
                        command.Parameters.AddWithValue("@ProductId", orderSearch.ProductId);
                        command.Parameters.AddWithValue("ProductGroup", orderSearch.ProductGroup);
                        command.Parameters.AddWithValue("@ProductName", orderSearch.ProductName);
                        command.Parameters.AddWithValue("@CarModel", orderSearch.CarModel);
                        command.Parameters.AddWithValue("@CarColor", orderSearch.CarColor);
                        command.Parameters.AddWithValue("@Quantity", orderSearch.Quantity);
                        command.Parameters.AddWithValue("@OrderDate", orderSearch.OrderDate);
                        command.Parameters.AddWithValue("@OrderStatusId", orderSearch.OrderStatusId);
                        command.Parameters.AddWithValue("@OrderStatusName", orderSearch.OrderStatusName);
                        command.Parameters.AddWithValue("@Discount", orderSearch.Discount);
                        command.Parameters.AddWithValue("@ShippedDate", orderSearch.ShippedDate);
                        command.Parameters.AddWithValue("@SaleAmount", orderSearch.SaleAmount);
                        command.Parameters.AddWithValue("@SaleAmountPaid", orderSearch.SaleAmountPaid);
                        command.Parameters.AddWithValue("@TaxPercentageValue", orderSearch.TaxPercentageValue);
                        command.Parameters.AddWithValue("@SaleTime", orderSearch.SaleTime);

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OrderModel order = new OrderModel();
                                order.OrderId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                order.CustomerId = reader.IsDBNull(1) ? null : reader.GetInt32(1);
                                order.CustomerFirstName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                order.CustomerLastName = reader.IsDBNull(3) ? null : reader.GetString(3);
                                order.SalesPersonId = reader.IsDBNull(4) ? null : reader.GetInt32(4);
                                order.SalesPersonFirstName = reader.IsDBNull(5) ? null : reader.GetString(5);
                                order.SalesPersonLastName = reader.IsDBNull(6) ? null : reader.GetString(6);
                                order.ProductId = reader.IsDBNull(7) ? null : reader.GetInt32(7);
                                order.ProductGroup = reader.IsDBNull(8) ? null : reader.GetString(8);
                                order.ProductName = reader.IsDBNull(9) ? null : reader.GetString(9);
                                order.CarModel = reader.IsDBNull(10) ? null : reader.GetString(10);
                                order.CarColor = reader.IsDBNull(11) ? null : reader.GetString(11);
                                order.Quantity = reader.IsDBNull(12) ? null : reader.GetInt32(12);
                                order.OrderDate = reader.IsDBNull(13) ? null : reader.GetDateTime(13);
                                order.OrderStatusId = reader.IsDBNull(14) ? null : reader.GetInt32(14);
                                order.OrderStatusName = reader.IsDBNull(15) ? null : reader.GetString(15);
                                order.Discount = reader.IsDBNull(16) ? null : reader.GetDouble(16);
                                order.ShippedDate = reader.IsDBNull(17) ? null : reader.GetDateTime(17);
                                order.SaleAmount = reader.IsDBNull(18) ? null : reader.GetDouble(18);
                                order.SaleAmountPaid = reader.IsDBNull(19) ? null : reader.GetDouble(19);
                                order.TaxPercentageValue = reader.IsDBNull(20) ? null : reader.GetDouble(20);
                                order.OrderDate = reader.IsDBNull(21) ? null : reader.GetDateTime(21);

                                listOrdersAllData.Add(order);
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
                return listOrdersAllData;
            });
        }

        // Update Or Insert
        public async Task OrdersUpdateOrInsert(OrderModel insertedOrder)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spOrdersUpdateOrInsert]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@OrderId", insertedOrder.OrderId);
                        command.Parameters.AddWithValue("@CustomerId", insertedOrder.CustomerId);
                        command.Parameters.AddWithValue("@CustomerFirstName", insertedOrder.@CustomerFirstName);
                        command.Parameters.AddWithValue("@CustomerLastName", insertedOrder.CustomerLastName);
                        command.Parameters.AddWithValue("@SalesPersonId", insertedOrder.SalesPersonId);
                        command.Parameters.AddWithValue("@SalesPersonFirstName", insertedOrder.SalesPersonFirstName);
                        command.Parameters.AddWithValue("@SalesPersonLastName", insertedOrder.SalesPersonLastName);
                        command.Parameters.AddWithValue("@ProductId", insertedOrder.ProductId);
                        command.Parameters.AddWithValue("ProductGroup", insertedOrder.ProductGroup);
                        command.Parameters.AddWithValue("@ProductName", insertedOrder.ProductName);
                        command.Parameters.AddWithValue("@CarModel", insertedOrder.CarModel);
                        command.Parameters.AddWithValue("@CarColor", insertedOrder.CarColor);
                        command.Parameters.AddWithValue("@Quantity", insertedOrder.Quantity);
                        command.Parameters.AddWithValue("@OrderDate", insertedOrder.OrderDate);
                        command.Parameters.AddWithValue("@OrderStatusId", insertedOrder.OrderStatusId);
                        command.Parameters.AddWithValue("@OrderStatusName", insertedOrder.OrderStatusName);
                        command.Parameters.AddWithValue("@Discount", insertedOrder.Discount);
                        command.Parameters.AddWithValue("@ShippedDate", insertedOrder.ShippedDate);
                        command.Parameters.AddWithValue("@SaleAmount", insertedOrder.SaleAmount);
                        command.Parameters.AddWithValue("@SaleAmountPaid", insertedOrder.SaleAmountPaid);
                        command.Parameters.AddWithValue("@TaxPercentageValue", insertedOrder.TaxPercentageValue);
                        command.Parameters.AddWithValue("@SaleTime", insertedOrder.SaleTime);

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
        public async Task OrdersDelete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spOrdersDelete]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

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

    }
}
