using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models;
public class SpokenLanguesModel
{
    [Display(Name = "Muttersprache Id")]
    public int? SpokenLanguesId { get; set; }

    [Display(Name = "Muttersprache Name")]
    public string? SpokenLanguesName { get; set; }
}
