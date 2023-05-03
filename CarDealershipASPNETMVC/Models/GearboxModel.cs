using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models
{    
    public class GearboxModel
    {
        [Display(Name = "Getriebe Id")]
        public int? GearboxId { get; set; }

        [Display(Name = "Getriebename")]
        public string? GearboxName { get; set; }
    }
}
