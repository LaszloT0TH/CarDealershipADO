using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models
{
    public class FuelInsertOrUpdateModel
    {
        [Display(Name = "Kraftstoff Id")]
        public int? FuelID { get; set; }

        [Display(Name = "Kraftstoff Name")]
        [Required(ErrorMessage = "Bitte eingeben den Kraftstoff Name")]
        public string FuelName { get; set; }

    }
}
