using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models
{
    public class CarAccessoriesModel
    {
        [Display(Name = "Auto Zubehör Id")]
        public int? CAId { get; set; }

        // kötelező kitölteni a mezőt
        // [Required]
        [Display(Name = "Produkt")]
        public string? ProductName { get; set; }

        [Display(Name = "Produktgruppe")]
        public string? CAPGName { get; set; }

        [Display(Name = "Lagerbestand")]
        public int? QuantityOfStock { get; set; }

        [Display(Name = "Mindestbestandsmenge")]
        public int? MinimumStockQuantity { get; set; }

        [Display(Name = "Netto-Verkaufspreis")]
        public double? NetSellingPrice { get; set; }

        [Display(Name = "Verkaufseinheit")]
        public double? SalesUnit { get; set; }

        [Display(Name = "Einheit Preis")]
        public double? UnitPrice { get; set; }

        [Display(Name = "Einheit Name")]
        public string? UnitName { get; set; }

        [Display(Name = "Letzte Aktualisierungszeit")]
        public DateTime? LastUpdateTime { get; set; }

        [Display(Name = "Marke")]
        public string? Brand { get; set; }

        [Display(Name = "Erstellungsdatum")]
        public DateTime? CreationDate { get; set; }

        [Display(Name = "Beschreibung")]
        public string? Description { get; set; }

        [Display(Name = "Version")]
        public int? Version { get; set; }

        public string? CarAccessoriesListItem
        {
            get { return CAId + " " + ProductName + " " + UnitName + " " + NetSellingPrice.ToString(); }
        }
    }
}
