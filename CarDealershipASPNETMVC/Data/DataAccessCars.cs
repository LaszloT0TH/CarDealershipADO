using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CarDealershipASPNETMVC.Data
{
    public partial class DataAccess
    {
        // - - - - - - - Cars - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Cars - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Cars - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // - - - - - - - Cars - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        //GetAllData
        public async Task<List<CarModel>> CarsViewData()
        {
            List<CarModel> listCarsAllData = new List<CarModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spCarsSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CarModel car = new CarModel();
                                car.CarId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                car.Model = reader.IsDBNull(1) ? null : reader.GetString(1);
                                car.Color = reader.IsDBNull(2) ? null : reader.GetString(2);
                                car.Number_of_seats = reader.IsDBNull(3) ? null : reader.GetInt32(3);
                                car.Year_of_production = reader.IsDBNull(4) ? null : reader.GetDateTime(4);
                                car.FuelName = reader.IsDBNull(5) ? null : reader.GetString(5);
                                car.GearboxName = reader.IsDBNull(6) ? null : reader.GetString(6);
                                car.Cubic_capacity = reader.IsDBNull(7) ? null : reader.GetDouble(7);
                                car.Mileage = reader.IsDBNull(8) ? null : reader.GetDouble(8);
                                car.Chassis_number = reader.IsDBNull(9) ? null : reader.GetString(9);
                                car.Engine_power = reader.IsDBNull(10) ? null : reader.GetInt32(10);
                                car.Own_Weight = reader.IsDBNull(11) ? null : reader.GetInt32(11);
                                car.Sold = reader.IsDBNull(12) ? false : reader.GetBoolean(12);
                                car.NettoPrice = reader.IsDBNull(13) ? null : reader.GetDouble(13);

                                listCarsAllData.Add(car);
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
                return listCarsAllData;
            });
        }

        //GetAllData, Search
        public async Task<List<CarModel>> CarsViewData(CarModel carsSearch)
        {
            List<CarModel> listCarsSearchResult = new List<CarModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spCarsSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CarId", carsSearch.CarId);
                        command.Parameters.AddWithValue("@Model", carsSearch.Model);
                        command.Parameters.AddWithValue("@Color", carsSearch.Color);
                        command.Parameters.AddWithValue("@Number_of_seats", carsSearch.Number_of_seats);
                        command.Parameters.AddWithValue("@Year_of_production", carsSearch.Year_of_production);
                        command.Parameters.AddWithValue("@FuelName", carsSearch.FuelName);
                        command.Parameters.AddWithValue("@GearboxName", carsSearch.GearboxName);
                        command.Parameters.AddWithValue("@Cubic_capacity", carsSearch.Cubic_capacity);
                        command.Parameters.AddWithValue("@Mileage", carsSearch.Mileage);
                        command.Parameters.AddWithValue("@Chassis_number", carsSearch.Chassis_number);
                        command.Parameters.AddWithValue("@Engine_power", carsSearch.Engine_power);
                        command.Parameters.AddWithValue("@Own_Weight", carsSearch.Own_Weight);
                        command.Parameters.AddWithValue("@Sold", carsSearch.Sold);
                        command.Parameters.AddWithValue("@NettoPrice", carsSearch.NettoPrice);

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CarModel car = new CarModel();
                                car.CarId = reader.IsDBNull(0) ? null : reader.GetInt32(0);
                                car.Model = reader.IsDBNull(1) ? null : reader.GetString(1);
                                car.Color = reader.IsDBNull(2) ? null : reader.GetString(2);
                                car.Number_of_seats = reader.IsDBNull(3) ? null : reader.GetInt32(3);
                                car.Year_of_production = reader.IsDBNull(4) ? null : reader.GetDateTime(4);
                                car.FuelName = reader.IsDBNull(5) ? null : reader.GetString(5);
                                car.GearboxName = reader.IsDBNull(6) ? null : reader.GetString(6);
                                car.Cubic_capacity = reader.IsDBNull(7) ? null : reader.GetDouble(7);
                                car.Mileage = reader.IsDBNull(8) ? null : reader.GetDouble(8);
                                car.Chassis_number = reader.IsDBNull(9) ? null : reader.GetString(9);
                                car.Engine_power = reader.IsDBNull(10) ? null : reader.GetInt32(10);
                                car.Own_Weight = reader.IsDBNull(11) ? null : reader.GetInt32(11);
                                car.Sold = reader.IsDBNull(12) ? false : reader.GetBoolean(12);
                                car.NettoPrice = reader.IsDBNull(13) ? null : reader.GetDouble(13);

                                listCarsSearchResult.Add(car);
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
                return listCarsSearchResult;
            });
        }

        // Update Or Insert
        public async Task CarsUpdateOrInsert(CarModel insertedCar)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spCarsUpdateOrInsert]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CarId", insertedCar.CarId);
                        command.Parameters.AddWithValue("@Model", insertedCar.Model);
                        command.Parameters.AddWithValue("@Color", insertedCar.Color);
                        command.Parameters.AddWithValue("@Number_of_seats", insertedCar.Number_of_seats);
                        command.Parameters.AddWithValue("@Year_of_production", insertedCar.Year_of_production);
                        command.Parameters.AddWithValue("@FuelName", insertedCar.FuelName);
                        command.Parameters.AddWithValue("@GearboxName", insertedCar.GearboxName);
                        command.Parameters.AddWithValue("@Cubic_capacity", insertedCar.Cubic_capacity);
                        command.Parameters.AddWithValue("@Mileage", insertedCar.Mileage);
                        command.Parameters.AddWithValue("@Chassis_number", insertedCar.Chassis_number);
                        command.Parameters.AddWithValue("@Engine_power", insertedCar.Engine_power);
                        command.Parameters.AddWithValue("@Own_Weight", insertedCar.Own_Weight);
                        if (insertedCar.Sold == true)
                        {
                            command.Parameters.AddWithValue("@Sold", 1);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Sold", 0);
                        }

                        command.Parameters.AddWithValue("@NettoPrice", insertedCar.NettoPrice);

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
        public async Task CarsDelete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spCarsDelete]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CarId", id);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }


        // - - -     help tables Car      - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // GetAllData, Search
        public async Task<List<FuelModel>> FuelViewData()
        {
            List<FuelModel> listFuelAllData = new List<FuelModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spFuelSearchDynamicSQL]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FuelModel fuel = new FuelModel();
                                fuel.FuelID = reader.GetInt32(0);
                                fuel.FuelName = reader.GetString(1);
                                listFuelAllData.Add(fuel);
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
                return listFuelAllData;
            });
        }

        // GetAllData, Search
        public async Task<List<GearboxModel>> GearboxViewData()
        {
            List<GearboxModel> listGearboxAllData = new List<GearboxModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spGearboxSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GearboxModel gearbox = new GearboxModel();
                                gearbox.GearboxId = reader.GetInt32(0);
                                gearbox.GearboxName = reader.GetString(1);
                                listGearboxAllData.Add(gearbox);
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
                return listGearboxAllData;
            });
        }

        // GetAllData, Search
        public async Task<List<GearboxModel>> SoldViewData()
        {
            List<GearboxModel> listGearboxAllData = new List<GearboxModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("dbo.spGearboxSearchDynamicSQL", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GearboxModel gearbox = new GearboxModel();
                                gearbox.GearboxId = reader.GetInt32(0);
                                gearbox.GearboxName = reader.GetString(1);
                                listGearboxAllData.Add(gearbox);
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
                return listGearboxAllData;
            });
        }

    }
}
