using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models
{
    public class CarModel
    {
        [Display(Name = "Auto Id")]        
        public int? CarId { get; set; }

        [Display(Name = "Modell")]
        public string? Model { get; set; }

        [Display(Name = "Farbe")]
        public string? Color { get; set; }

        [Display(Name = "Anzahl Sitzplätze")]
        public int? Number_of_seats { get; set; }

        [Display(Name = "Baujahr")]
        public DateTime? Year_of_production { get; set; }

        [Display(Name = "Kraftstoffname")]
        public string? FuelName { get; set; }

        [Display(Name = "Getriebetyp")]
        public string? GearboxName { get; set; }

        [Display(Name = "Hubraum")]
        public double? Cubic_capacity { get; set; }

        [Display(Name = "Kilometerstand")]
        public double? Mileage { get; set; }

        [Display(Name = "Fahrgestellnummer")]
        public string? Chassis_number { get; set; }

        [Display(Name = "Motorleistung")]
        public int? Engine_power { get; set; }

        [Display(Name = "Eigengewicht")]
        public int? Own_Weight { get; set; }

        [Display(Name = "Verkauft")]
        public bool Sold { get; set; }

        [Display(Name = "Nettopreis")]
        public double? NettoPrice { get; set; }

        public string? CarListItem
        {
            get { return CarId + " " + Model + " " + Color + " " + Chassis_number; }
        }
    }
}
