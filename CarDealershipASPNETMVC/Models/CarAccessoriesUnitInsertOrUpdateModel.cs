using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models
{
    public class CarAccessoriesUnitInsertOrUpdateModel
    {
        [Display(Name = "Einheit Id")]
        public int? CAUId { get; set; }

        [Display(Name = "Einheit Name")]
        [Required(ErrorMessage = "Bitte eingeben den Einheitename")]
        public string UnitName { get; set; }

    }
}
