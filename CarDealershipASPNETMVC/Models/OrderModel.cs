using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models;
public class OrderModel
{

    [Display(Name = "Auftragsnummer")]
    public int? OrderId { get; set; }
    
    [Display(Name = "Kunde Id")]
    public int? CustomerId { get; set; }
    
    [Display(Name = "Kunde Vorname")]
    public string? CustomerFirstName { get; set; }
    
    [Display(Name = "Kunde Nachname")]
    public string? CustomerLastName { get; set; }
    
    [Display(Name = "Verkäufer Id")]
    public int? SalesPersonId { get; set; }
    
    [Display(Name = "Verkäufer Vorname")]
    public string? SalesPersonFirstName { get; set; }
    
    [Display(Name = "Verkäufer Nachname")]
    public string? SalesPersonLastName { get; set; }
    
    [Display(Name = "Produkt Id")]
    public int? ProductId { get; set; }
    
    [Display(Name = "Produktgruppe")]
    public string? ProductGroup { get; set; }
    
    [Display(Name = "Produktname")]
    public string? ProductName { get; set; }
    
    [Display(Name = "Auto Model")]
    public string? CarModel { get; set; }
    
    [Display(Name = "Autofarbe")]
    public string CarColor { get; set; }
    
    [Display(Name = "Menge")]
    public int? Quantity { get; set; }
    
    [Display(Name = "Bestelldatum")]
    public DateTime? OrderDate { get; set; }
    
    [Display(Name = "Bestellstatus Id")]
    public int? OrderStatusId { get; set; }
    
    [Display(Name = "Bestellstatusname")]
    public string? OrderStatusName { get; set; }
    
    [Display(Name = "Rabatt")]
    public double? Discount { get; set; }
    
    [Display(Name = "Versanddatum")]
    public DateTime? ShippedDate { get; set; }
    
    [Display(Name = "Netto Verkaufsbetrag")]
    public double? SaleAmount { get; set; }
    
    [Display(Name = "Bezahlter Verkaufsbetrag")]
    public double? SaleAmountPaid { get; set; }
    
    [Display(Name = "Steuerprozentsatz")]
    public double? TaxPercentageValue { get; set; }

    [Display(Name = "Verkaufszeit")]
    public DateTime? SaleTime { get; set; }

    public int? UserId { get; set; }

}
