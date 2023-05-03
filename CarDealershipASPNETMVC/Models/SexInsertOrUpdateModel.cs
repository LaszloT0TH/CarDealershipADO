using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models
{
    public class SexInsertOrUpdateModel
    {
        [Display(Name = "Geschlecht Id")]
        public int? SexId { get; set; }

        [Display(Name = "Geschlechtsname")]
        [Required(ErrorMessage = "Bitte eingeben den Geschlechtsname")]
        public string SexName { get; set; }

    }
}
