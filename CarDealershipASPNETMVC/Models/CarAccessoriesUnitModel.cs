using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models;
public class CarAccessoriesUnitModel
{
    [Display(Name = "Einheit Id")]
    public int? CAUId { get; set; }

    [Display(Name = "Einheit Name")]
    public string? UnitName { get; set; }

}
