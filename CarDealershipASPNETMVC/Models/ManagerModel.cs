namespace CarDealershipASPNETMVC.Models
{
    public class ManagerModel
    {
        public int ManagerId { get; set; }

        public string ManagerFirstName { get; set; }

        public string ManagerLastName { get; set; }
        public string ManagerFullName {
            get { return ManagerId + " " + ManagerFirstName + " " + ManagerLastName; }
        }
    }
}
