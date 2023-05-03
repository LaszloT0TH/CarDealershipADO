using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models
{
    public class GearboxInsertOrUpdateModel
    {
        [Display(Name = "Getriebe Id")]
        public int? GearboxId { get; set; }

        [Display(Name = "Getriebename")]
        [Required(ErrorMessage = "Bitte eingeben den Getriebename")]
        public string GearboxName { get; set; }

    }
}
