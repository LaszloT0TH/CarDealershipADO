using CarDealershipASPNETMVC.Data;
using CarDealershipASPNETMVC.Models;

namespace CarDealershipASPNETMVC.Global
{
    /// <summary>
    /// Short-term storage of global variables
    /// Kurzzeitspeicherung globaler Variablen
    /// </summary>
    public class GlobalData
    {
        private static readonly DataAccess dataAccess = new DataAccess();
        public static int UserId { get; set; }

        public static string UserAccess
        {
            get
            {
                if (UserId >= 1000)
                {
                    return "Customer";
                }
                else if(UserId < 1000 && UserId > 0)
                {
                    if (dataAccess.IsManager(UserId).Result)
                    {
                        return "Manager";
                    }
                    else
                    {
                        return "Salesperson";
                    }
                }
                else
                {
                    return "Guest";
                }
            }
        }

        public static int? ShoppingCartOrderId { get; set; }

        public static int ShoppingCartCustomerIdNull { get; set; }

    }
}
