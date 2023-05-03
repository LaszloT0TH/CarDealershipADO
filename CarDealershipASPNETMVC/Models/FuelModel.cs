using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models
{
    public class FuelModel
    {
        [Display(Name = "Kraftstoff Id")]
        public int? FuelID { get; set; }

        [Display(Name = "Kraftstoff Name")]
        public string? FuelName { get; set; }
    }
}
