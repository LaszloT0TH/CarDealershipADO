using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CarDealershipASPNETMVC.Data
{
    public partial class DataAccess
    {
        // Login
        public async Task<int> LoginData(string email)
        {
            int userId = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("spSetUserId", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserEmail", email);

                        SqlParameter outputParameter = new SqlParameter();

                        outputParameter.ParameterName = "@UserId";

                        outputParameter.SqlDbType = System.Data.SqlDbType.Int;

                        outputParameter.Direction = System.Data.ParameterDirection.Output;

                        command.Parameters.Add(outputParameter);

                        command.ExecuteNonQuery();

                        userId = Convert.ToInt32(outputParameter.Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            return await Task.Run(() => { return userId; });
        }

        public async Task<bool> IsManager(int UserId)
        {
            bool manager = false;

            List<int> listManagerID = new List<int>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("Select DISTINCT ManagerID from tblSalespersons", connection))
                    {
                        command.CommandType = System.Data.CommandType.Text;

                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int result = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                listManagerID.Add(result);
                            }
                        }
                    }
                }
                foreach (int managerId in listManagerID)
                {
                    if (UserId == managerId)
                    {
                        manager = true;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            return await Task.Run(() => { return manager; });
        }

        public async Task EmailUpload(string UserEmail)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringCarDealerShipDB))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("[dbo].[spEmailUpload]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserEmail", UserEmail);

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
