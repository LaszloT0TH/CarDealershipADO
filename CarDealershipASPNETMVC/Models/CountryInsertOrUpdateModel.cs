using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models
{
    public class CountryInsertOrUpdateModel
    {
        [Display(Name = "Länder Id")]
        public int? CountryId { get; set; }

        [Display(Name = "Ländername")]
        [Required(ErrorMessage = "Bitte eingeben den Ländername")]
        public string CountryName { get; set; }

        [Display(Name = "Steuerprozentsatz des Landes")]
        [Required(ErrorMessage = "Bitte eingeben den Steuerprozentsatz des Landes")]
        public double CountryTaxPercentageValue { get; set; }

    }
}
