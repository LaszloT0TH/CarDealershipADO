using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CarDealershipASPNETMVC.Data
{
    public partial class DataAccess
    {
        static String connectionStringCarDealerShipDB = "Data Source=USER-PC;database=CarDealerShipDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //static String connectionStringCarDealerShipDB = "Data Source=USER-PERSONALCO;database=CarDealerShipDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static String connectionStringCarDealerShipShoppingCartDB = "Data Source=USER-PC;database=CarDealerShipShoppingCartDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //static String connectionStringCarDealerShipShoppingCartDB = "Data Source=USER-PERSONALCO;database=CarDealerShipShoppingCartDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        string errorMessage = "";

        // - - -     help query   - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // GetAllData, Search
        public async Task<List<SexModel>> SexViewData()
        {
            List<SexModel> listSexAllData = new List<SexModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spSexSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SexModel sex = new SexModel();
                                sex.SexId = reader.GetInt32(0);
                                sex.SexName = reader.GetString(1);
                                listSexAllData.Add(sex);
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
                return listSexAllData;
            });
        }

        // GetAllData, Search
        public async Task<List<CountryModel>> CountryViewData()
        {
            List<CountryModel> listCountryAllData = new List<CountryModel>();

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
                                country.CountryId = reader.GetInt32(0);
                                country.CountryName = reader.GetString(1);
                                listCountryAllData.Add(country);
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
                return listCountryAllData;
            });
        }

        // GetAllData, Search
        public async Task<List<ManagerModel>> ManagerViewData()
        {
            List<ManagerModel> listManagersAllData = new List<ManagerModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("select SalesId, FirstName, LastName from tblSalespersons", connection))
                    {
                        command.CommandType = System.Data.CommandType.Text;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ManagerModel manager = new ManagerModel();
                                manager.ManagerId = reader.GetInt32(0);
                                manager.ManagerFirstName = reader.GetString(1);
                                manager.ManagerLastName = reader.GetString(2);
                                listManagersAllData.Add(manager);
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
                return listManagersAllData;
            });
        }

        // GetAllData, Search
        public async Task<List<StockReplenishmentListModel>> StockReplenishmentListViewData()
        {
            List<StockReplenishmentListModel> listStockReplenishmentListAllData = new List<StockReplenishmentListModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spStockReplenishmentListSearchDynamicSQL]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StockReplenishmentListModel SRL = new StockReplenishmentListModel();
                                SRL.SRLId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                SRL.ProductId = reader.IsDBNull(1) ? null : reader.GetInt32(1);
                                SRL.ProductName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                SRL.OrderedStatus = reader.IsDBNull(2) ? false : reader.GetBoolean(3);
                                SRL.SRLTimeStamp = reader.IsDBNull(3) ? null : reader.GetDateTime(4);
                                listStockReplenishmentListAllData.Add(SRL);
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
                return listStockReplenishmentListAllData;
            });
        }

        // GetAllData, Search
        public async Task<List<CustomerModel>> CustomersListViewData()
        {
            List<CustomerModel> customersListAllData = new List<CustomerModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spCustomerSearchDynamicSQL]", connection))
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
                                customer.Email = reader.IsDBNull(11) ? null : reader.GetString(11);
                                customersListAllData.Add(customer);
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
                return customersListAllData;
            });
        }

        // GetAllData, Search
        public async Task<List<SalespersonModel>> SalesPersonsListViewData()
        {
            List<SalespersonModel> salesPersonsListAllData = new List<SalespersonModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spSalespersonsSearchDynamicSQL]", connection))
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
                                salesPersonsListAllData.Add(salesperson);
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
                return salesPersonsListAllData;
            });
        }

        // GetAllData, Search
        public async Task<List<CarAccessoriesModel>> CarAccessoriesListViewData()
        {
            List<CarAccessoriesModel> carAccessoriesListAllData = new List<CarAccessoriesModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spCarAccessoriesSearchDynamicSQL]", connection))
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
                                carAccessories.UnitName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                carAccessories.NetSellingPrice = reader.IsDBNull(5) ? null : reader.GetDouble(5);
                                carAccessoriesListAllData.Add(carAccessories);
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
                return carAccessoriesListAllData;
            });
        }

        // GetAllData, Search
        public async Task<List<CarModel>> CarsListViewData()
        {
            List<CarModel> carList = new List<CarModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spCarsSearchDynamicSQL]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CarModel carListItem = new CarModel();
                                carListItem.CarId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                carListItem.Model = reader.IsDBNull(1) ? null : reader.GetString(1);
                                carListItem.Color = reader.IsDBNull(2) ? null : reader.GetString(2);
                                carListItem.Chassis_number = reader.IsDBNull(9) ? null : reader.GetString(9);
                                carList.Add(carListItem);
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
                return carList;
            });
        }

        public async Task<string> CustomerFirstName(int id)
        {
            string fName = String.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("select FirstName from tblCustomer where CustomerId = " + id, connection))
                    {
                        command.CommandType = System.Data.CommandType.Text;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                fName = reader.IsDBNull(0) ? null : reader.GetString(0);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;

            }

            return fName;
        }

        public async Task<string> CustomerLastName(int id)
        {
            string lName = String.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("select LastName from tblCustomer where CustomerId = " + id, connection))
                    {
                        command.CommandType = System.Data.CommandType.Text;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lName = reader.IsDBNull(0) ? null : reader.GetString(0);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;

            }

            return lName;
        }

        public async Task<string> SalesPersonFirstName(int id)
        {
            string fName = String.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("select FirstName from tblSalespersons where SalesId = " + id, connection))
                    {
                        command.CommandType = System.Data.CommandType.Text;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                fName = reader.IsDBNull(0) ? null : reader.GetString(0);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;

            }

            return await Task.Run(() => { return fName; });
        }

        public async Task<string> SalesPersonLastName(int id)
        {
            string lName = String.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("select LastName from tblSalespersons where SalesId = " + id, connection))
                    {
                        command.CommandType = System.Data.CommandType.Text;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lName = reader.IsDBNull(0) ? null : reader.GetString(0);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;

            }

            return await Task.Run(() => { return lName; });
        }

        public async Task<string> CarModel(int id)
        {
            string Model = String.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("select Model from tblCars where CarId = " + id, connection))
                    {
                        command.CommandType = System.Data.CommandType.Text;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Model = reader.IsDBNull(0) ? null : reader.GetString(0);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;

            }

            return await Task.Run(() => { return Model; });
        }

        public async Task<string> CarColor(int id)
        {
            string Color = String.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("select Color from tblCars where CarId = " + id, connection))
                    {
                        command.CommandType = System.Data.CommandType.Text;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Color = reader.IsDBNull(0) ? null : reader.GetString(0);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;

            }

            return await Task.Run(() => { return Color; });
        }

        public async Task<double> CustomerCountryTaxPercentageValue(int id)
        {
            double countryTaxPercentageValue = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand
                        ("select CountryTaxPercentageValue from tblCustomer join tblCountry " +
                        "on tblCustomer.CountryId = tblCountry.CountryId where CustomerId = " + id, connection))
                    {
                        command.CommandType = System.Data.CommandType.Text;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                countryTaxPercentageValue = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;

            }

            return await Task.Run(() => { return countryTaxPercentageValue; });
        }

        public async Task<string> CarsAccessoriesProductName(int id)
        {
            string Model = String.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("select ProductName from tblCarAccessories where CAId = " + id, connection))
                    {
                        command.CommandType = System.Data.CommandType.Text;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Model = reader.IsDBNull(0) ? null : reader.GetString(0);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;

            }

            return await Task.Run(() => { return Model; });
        }

        public async Task<string> CarsAccessoriesProductGroup(int id)
        {
            string ProductGroup = String.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand
                        ("select CAPGName from tblCarAccessories join tblCarAccessoriesProductGroup " +
                        "on tblCarAccessories.ProductGroupId = tblCarAccessoriesProductGroup.CAPGId where CAId = " + id, connection))
                    {
                        command.CommandType = System.Data.CommandType.Text;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductGroup = reader.IsDBNull(0) ? null : reader.GetString(0);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;

            }

            return await Task.Run(() => { return ProductGroup; });
        }

        public async Task<double> SaleAmount(int id)
        {
            double price = 0;

            // Car Accessories
            if (id < 1000000)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                    {
                        await connection.OpenAsync();

                        using (SqlCommand command = new SqlCommand("select NetSellingPrice from tblCarAccessories where CAId = " + id, connection))
                        {
                            command.CommandType = System.Data.CommandType.Text;

                            command.ExecuteNonQuery();

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    price = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;

                }
            }

            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                    {
                        await connection.OpenAsync();

                        using (SqlCommand command = new SqlCommand("select NettoPrice from tblCars where CarId = " + id, connection))
                        {
                            command.CommandType = System.Data.CommandType.Text;

                            command.ExecuteNonQuery();

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    price = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;

                }
            }
            return await Task.Run(() => { return price; });
        }
    }
}
