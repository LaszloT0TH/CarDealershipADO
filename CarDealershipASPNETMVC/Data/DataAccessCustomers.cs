using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CarDealershipASPNETMVC.Data
{
    public partial class DataAccess
    {
        // - - - - - - - Customers - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Customers - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Customers - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Customers - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        //GetAllData
        public async Task<List<CustomerModel>> CustomersViewData()
        {
            List<CustomerModel> listCustomersAllData = new List<CustomerModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spCustomerSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerModel customer = new CustomerModel();
                                customer.CustomerId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                customer.FirstName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                customer.LastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                customer.SexName = reader.IsDBNull(3) ? null : reader.GetString(3);
                                customer.Street = reader.IsDBNull(4) ? null : reader.GetString(4);
                                customer.House_Number = reader.IsDBNull(5) ? null : reader.GetString(5);
                                customer.PostalCode = reader.IsDBNull(6) ? null : reader.GetInt32(6);
                                customer.Location = reader.IsDBNull(7) ? null : reader.GetString(7);
                                customer.CountryName = reader.IsDBNull(8) ? null : reader.GetString(8);
                                customer.DateOfBirth = reader.IsDBNull(9) ? null : reader.GetDateTime(9);
                                customer.TelNr = reader.IsDBNull(10) ? null : reader.GetDouble(10);
                                customer.Email = reader.IsDBNull(11) ? null : reader.GetString(11);

                                listCustomersAllData.Add(customer);
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
                return listCustomersAllData;
            });
        }

        //GetAllData, Search
        public async Task<List<CustomerModel>> CustomersViewData(CustomerModel customerSearch)
        {
            List<CustomerModel> listCustomersAllData = new List<CustomerModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spCustomerSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CustomerId", customerSearch.CustomerId);
                        command.Parameters.AddWithValue("@FirstName", customerSearch.FirstName);
                        command.Parameters.AddWithValue("@LastName", customerSearch.LastName);
                        command.Parameters.AddWithValue("@SexName", customerSearch.SexName);
                        command.Parameters.AddWithValue("@Street", customerSearch.Street);
                        command.Parameters.AddWithValue("@House_Number", customerSearch.House_Number);
                        command.Parameters.AddWithValue("@PostalCode", customerSearch.PostalCode);
                        command.Parameters.AddWithValue("@Location", customerSearch.Location);
                        command.Parameters.AddWithValue("@CountryName", customerSearch.CountryName);
                        command.Parameters.AddWithValue("@DateOfBirth", customerSearch.DateOfBirth);
                        command.Parameters.AddWithValue("@TelNr", customerSearch.TelNr);
                        command.Parameters.AddWithValue("@Email", customerSearch.Email);

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerModel customer = new CustomerModel();
                                customer.CustomerId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                customer.FirstName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                customer.LastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                customer.SexName = reader.IsDBNull(3) ? null : reader.GetString(3);
                                customer.Street = reader.IsDBNull(4) ? null : reader.GetString(4);
                                customer.House_Number = reader.IsDBNull(5) ? null : reader.GetString(5);
                                customer.PostalCode = reader.IsDBNull(6) ? null : reader.GetInt32(6);
                                customer.Location = reader.IsDBNull(7) ? null : reader.GetString(7);
                                customer.CountryName = reader.IsDBNull(8) ? null : reader.GetString(8);
                                customer.DateOfBirth = reader.IsDBNull(9) ? null : reader.GetDateTime(9);
                                customer.TelNr = reader.IsDBNull(10) ? null : reader.GetDouble(10);
                                customer.Email = reader.IsDBNull(11) ? null : reader.GetString(11);

                                listCustomersAllData.Add(customer);
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
                return listCustomersAllData;
            });
        }

        // Update Or Insert
        public async Task CustomersUpdateOrInsert(CustomerModel insertedCustomer)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spCustomerUpdateOrInsert]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CustomerId", insertedCustomer.CustomerId);
                        command.Parameters.AddWithValue("@FirstName", insertedCustomer.FirstName);
                        command.Parameters.AddWithValue("@LastName", insertedCustomer.LastName);
                        command.Parameters.AddWithValue("@SexName", insertedCustomer.SexName);
                        command.Parameters.AddWithValue("@Street", insertedCustomer.Street);
                        command.Parameters.AddWithValue("@House_Number", insertedCustomer.House_Number);
                        command.Parameters.AddWithValue("@PostalCode", insertedCustomer.PostalCode);
                        command.Parameters.AddWithValue("@Location", insertedCustomer.Location);
                        command.Parameters.AddWithValue("@CountryName", insertedCustomer.CountryName);
                        command.Parameters.AddWithValue("@DateOfBirth", insertedCustomer.DateOfBirth);
                        command.Parameters.AddWithValue("@TelNr", insertedCustomer.TelNr);
                        command.Parameters.AddWithValue("@Email", insertedCustomer.Email);


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
        public async Task CustomersDelete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spCustomerDelete]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CustomerId", id);

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
