using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CarDealershipASPNETMVC.Data
{
    public partial class DataAccess
    {
        // - - - - - - - Country - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Country - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Country - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Country - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        //GetAllData
        public async Task<List<CountryModel>> CountrysViewData()
        {
            List<CountryModel> listCountriesAllData = new List<CountryModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spCountrySearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CountryModel country = new CountryModel();
                                country.CountryId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                country.CountryName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                country.CountryTaxPercentageValue = reader.IsDBNull(2) ? null : reader.GetDouble(2);

                                listCountriesAllData.Add(country);
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
                return listCountriesAllData;
            });
        }

        //GetAllData, Search
        public async Task<List<CountryModel>> CountrysViewData(CountryModel countrySearch)
        {
            List<CountryModel> listCountrySearchResult = new List<CountryModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spCountrySearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CountryId", countrySearch.CountryId);
                        command.Parameters.AddWithValue("@CountryName", countrySearch.CountryName);
                        command.Parameters.AddWithValue("@CountryTaxPercentageValue", countrySearch.CountryTaxPercentageValue);

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CountryModel country = new CountryModel();
                                country.CountryId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                country.CountryName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                country.CountryTaxPercentageValue = reader.IsDBNull(2) ? null : reader.GetDouble(2);

                                listCountrySearchResult.Add(country);
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
                return listCountrySearchResult;
            });
        }

        // Update Or Insert
        public async Task CountrysUpdateOrInsert(CountryModel insertedCountry)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spCountryUpdateOrInsert]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CountryId", insertedCountry.CountryId);
                        command.Parameters.AddWithValue("@CountryName", insertedCountry.CountryName);
                        command.Parameters.AddWithValue("@CountryTaxPercentageValue", insertedCountry.CountryTaxPercentageValue);

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
        public async Task CountrysDelete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spCountryDelete]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CountryId", id);

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
