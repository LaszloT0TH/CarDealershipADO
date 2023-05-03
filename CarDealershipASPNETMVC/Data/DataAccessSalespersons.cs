using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CarDealershipASPNETMVC.Data
{
    public partial class DataAccess
    {

        // - - - - - - - Salespersons - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Salespersons - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Salespersons - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Salespersons - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        //GetAllData
        public async Task<List<SalespersonModel>> SalespersonsViewData()
        {
            List<SalespersonModel> listSalespersonsAllData = new List<SalespersonModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spSalespersonsSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SalespersonModel salesperson = new SalespersonModel();
                                salesperson.SalesId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                salesperson.FirstName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                salesperson.LastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                salesperson.SexName = reader.IsDBNull(3) ? null : reader.GetString(3);
                                salesperson.SpokenLanguesName = reader.IsDBNull(4) ? null : reader.GetString(4);
                                salesperson.ManagerFirstName = reader.IsDBNull(5) ? null : reader.GetString(5);
                                salesperson.ManagerLastName = reader.IsDBNull(6) ? null : reader.GetString(6);
                                salesperson.DateOfBirth = reader.IsDBNull(7) ? null : reader.GetDateTime(7);
                                salesperson.Street = reader.IsDBNull(8) ? null : reader.GetString(8);
                                salesperson.House_Number = reader.IsDBNull(9) ? null : reader.GetString(9);
                                salesperson.PostalCode = reader.IsDBNull(10) ? null : reader.GetInt32(10);
                                salesperson.Location = reader.IsDBNull(11) ? null : reader.GetString(11);
                                salesperson.CountryName = reader.IsDBNull(12) ? null : reader.GetString(12);
                                salesperson.EntryDate = reader.IsDBNull(13) ? null : reader.GetDateTime(13);
                                salesperson.TelNr = reader.IsDBNull(14) ? null : reader.GetDouble(14);
                                salesperson.Email = reader.IsDBNull(15) ? null : reader.GetString(15);

                                listSalespersonsAllData.Add(salesperson);
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
                return listSalespersonsAllData;
            });
        }

        //GetAllData, Search
        public async Task<List<SalespersonModel>> SalespersonsViewData(SalespersonModel salespersonSearch)
        {
            List<SalespersonModel> listSalespersonsAllData = new List<SalespersonModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spSalespersonsSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SalesId", salespersonSearch.SalesId);
                        command.Parameters.AddWithValue("@FirstName", salespersonSearch.FirstName);
                        command.Parameters.AddWithValue("@LastName", salespersonSearch.LastName);
                        command.Parameters.AddWithValue("@SexName", salespersonSearch.SexName);
                        command.Parameters.AddWithValue("@SpokenLanguesName", salespersonSearch.SpokenLanguesName);
                        command.Parameters.AddWithValue("@ManagerId", salespersonSearch.ManagerId);
                        command.Parameters.AddWithValue("@ManagerFirstName", salespersonSearch.ManagerFirstName);
                        command.Parameters.AddWithValue("@ManagerLastName", salespersonSearch.ManagerLastName);
                        command.Parameters.AddWithValue("@DateOfBirth", salespersonSearch.DateOfBirth);
                        command.Parameters.AddWithValue("@Street", salespersonSearch.Street);
                        command.Parameters.AddWithValue("@House_Number", salespersonSearch.House_Number);
                        command.Parameters.AddWithValue("@PostalCode", salespersonSearch.PostalCode);
                        command.Parameters.AddWithValue("@Location", salespersonSearch.Location);
                        command.Parameters.AddWithValue("@CountryName", salespersonSearch.CountryName);
                        command.Parameters.AddWithValue("@EntryDate", salespersonSearch.EntryDate);
                        command.Parameters.AddWithValue("@TelNr", salespersonSearch.TelNr);
                        command.Parameters.AddWithValue("@Email", salespersonSearch.Email);

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SalespersonModel salesperson = new SalespersonModel();
                                salesperson.SalesId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                salesperson.FirstName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                salesperson.LastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                salesperson.SexName = reader.IsDBNull(3) ? null : reader.GetString(3);
                                salesperson.SpokenLanguesName = reader.IsDBNull(4) ? null : reader.GetString(4);
                                salesperson.ManagerFirstName = reader.IsDBNull(5) ? null : reader.GetString(5);
                                salesperson.ManagerLastName = reader.IsDBNull(6) ? null : reader.GetString(6);
                                salesperson.DateOfBirth = reader.IsDBNull(7) ? null : reader.GetDateTime(7);
                                salesperson.Street = reader.IsDBNull(8) ? null : reader.GetString(8);
                                salesperson.House_Number = reader.IsDBNull(9) ? null : reader.GetString(9);
                                salesperson.PostalCode = reader.IsDBNull(10) ? null : reader.GetInt32(10);
                                salesperson.Location = reader.IsDBNull(11) ? null : reader.GetString(11);
                                salesperson.CountryName = reader.IsDBNull(12) ? null : reader.GetString(12);
                                salesperson.EntryDate = reader.IsDBNull(13) ? null : reader.GetDateTime(13);
                                salesperson.TelNr = reader.IsDBNull(14) ? null : reader.GetDouble(14);
                                salesperson.Email = reader.IsDBNull(15) ? null : reader.GetString(15);

                                listSalespersonsAllData.Add(salesperson);
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
                return listSalespersonsAllData;
            });
        }

        // Update Or Insert
        public async Task SalespersonsUpdateOrInsert(SalespersonModel insertedSalesperson)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spSalespersonsUpdateOrInsert]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SalesId", insertedSalesperson.SalesId);
                        command.Parameters.AddWithValue("@FirstName", insertedSalesperson.FirstName);
                        command.Parameters.AddWithValue("@LastName", insertedSalesperson.LastName);
                        command.Parameters.AddWithValue("@SexName", insertedSalesperson.SexName);
                        command.Parameters.AddWithValue("@SpokenLanguesName", insertedSalesperson.SpokenLanguesName);
                        command.Parameters.AddWithValue("@ManagerId", insertedSalesperson.ManagerId);
                        command.Parameters.AddWithValue("@ManagerFirstName", insertedSalesperson.ManagerFirstName);
                        command.Parameters.AddWithValue("@ManagerLastName", insertedSalesperson.ManagerLastName);
                        command.Parameters.AddWithValue("@DateOfBirth", insertedSalesperson.DateOfBirth);
                        command.Parameters.AddWithValue("@Street", insertedSalesperson.Street);
                        command.Parameters.AddWithValue("@House_Number", insertedSalesperson.House_Number);
                        command.Parameters.AddWithValue("@PostalCode", insertedSalesperson.PostalCode);
                        command.Parameters.AddWithValue("@Location", insertedSalesperson.Location);
                        command.Parameters.AddWithValue("@CountryName", insertedSalesperson.CountryName);
                        command.Parameters.AddWithValue("@EntryDate", insertedSalesperson.EntryDate);
                        command.Parameters.AddWithValue("@TelNr", insertedSalesperson.TelNr);
                        command.Parameters.AddWithValue("@Email", insertedSalesperson.Email);

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
        public async Task SalespersonsDelete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spSalespersonsDelete]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SalesId", id);

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
