using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models;

public class StockReplenishmentListModel
{

    [Display(Name = "Id")]
    public int? SRLId { get; set; }

    [Display(Name = "Produkt ID")]
    public int? ProductId { get; set; }
    
    [Display(Name = "Produkt Name")]
    public string? ProductName { get; set; }

    [Display(Name = "Bestellstatus")]
    public bool OrderedStatus { get; set; }

    [Display(Name = "Zeitstempel")]
    public DateTime? SRLTimeStamp { get; set; }
}
