using System.ComponentModel.DataAnnotations;
namespace CarDealershipASPNETMVC.Models
{

    public class CarAccessoriesInsertUpdateModel
    {
        [Display(Name = "Auto Zubehör Id")]
        public int? CAId { get; set; }

        [Display(Name = "Produkt")]
        [Required(ErrorMessage = "Bitte eingeben den Produkt Name")]
        public string ProductName { get; set; }


        [Display(Name = "Produktgruppe")]
        [Required(ErrorMessage = "Bitte eingeben den Produktgruppe Name")]
        public string CAPGName { get; set; }

        
        [Display(Name = "Lagerbestand")]
        [Required(ErrorMessage = "Bitte eingeben den Lagerbestand")] 
        public int QuantityOfStock { get; set; }

        [Display(Name = "Mindestbestandsmenge")]
        [Required(ErrorMessage = "Bitte eingeben den Mindestbestandsmenge")]
        public int MinimumStockQuantity { get; set; }

        [Display(Name = "Netto-Verkaufspreis")]
        [Required(ErrorMessage = "Bitte eingeben den Netto-Verkaufspreis")]
        public double NetSellingPrice { get; set; }

        [Display(Name = "Verkaufseinheit")]
        [Required(ErrorMessage = "Bitte eingeben den Verkaufseinheit")]
        public double SalesUnit { get; set; }

        [Display(Name = "Einheit Preis")]
        [Required(ErrorMessage = "Bitte eingeben den Einheit Preis")]
        public double UnitPrice { get; set; }

        [Display(Name = "Einheit Name")]
        [Required(ErrorMessage = "Bitte eingeben den Einheit Name")]
        public string UnitName { get; set; }

        [Display(Name = "Letzte Aktualisierungszeit")]
        [Required(ErrorMessage = "Bitte eingeben den Letzte Aktualisierungszeit")]
        public DateTime LastUpdateTime { get; set; }

        [Display(Name = "Marke")]
        [Required(ErrorMessage = "Bitte eingeben den Marke")]
        public string Brand { get; set; }

        [Display(Name = "Erstellungsdatum")]
        [Required(ErrorMessage = "Bitte eingeben den Erstellungsdatum")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Beschreibung")]
        [Required(ErrorMessage = "Bitte eingeben die Beschreibung")]
        public string Description { get; set; }

        [Display(Name = "Version")]
        [Required(ErrorMessage = "Bitte eingeben den Version")]
        public int Version { get; set; }

    }

}
