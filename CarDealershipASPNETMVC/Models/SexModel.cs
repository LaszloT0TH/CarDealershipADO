using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models;
public class SexModel
{
    [Display(Name = "Geschlecht Id")]
    public int? SexId { get; set; }

    [Display(Name = "Geschlechtsname")]
    public string? SexName { get; set; }
}
