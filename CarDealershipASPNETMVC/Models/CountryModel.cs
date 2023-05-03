using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models;
public class CountryModel
{
    [Display(Name = "Länder Id")]
    public int? CountryId { get; set; }

    [Display(Name = "Ländername")]
    public string? CountryName { get; set; }

    [Display(Name = "Steuerprozentsatz des Landes")]
    public double? CountryTaxPercentageValue { get; set; }

}

