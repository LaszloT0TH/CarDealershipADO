using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models
{    
    public class CarInsertUpdateModel
    {
        [Display(Name = "Auto Id")]
        public int? CarId { get; set; }

        [Display(Name = "Modell")]
        [Required(ErrorMessage = "Bitte eingeben den Modell Name")]
        public string Model { get; set; }

        [Display(Name = "Farbe")]
        [Required(ErrorMessage = "Bitte eingeben den Farbe")]
        public string Color { get; set; }

        [Display(Name = "Anzahl Sitzplätze")]
        [Required(ErrorMessage = "Bitte eingeben den Sitzplätze")]
        public int Number_of_seats { get; set; }

        [Display(Name = "Baujahr")]
        [Required(ErrorMessage = "Bitte eingeben den Baujahr")]
        public DateTime Year_of_production { get; set; }

        [Display(Name = "Kraftstoffname")]
        [Required(ErrorMessage = "Bitte eingeben den Kraftstoff Name")]
        public string FuelName { get; set; }

        [Display(Name = "Getriebetyp")]
        [Required(ErrorMessage = "Bitte eingeben den Getriebetyp Name")]
        public string GearboxName { get; set; }

        [Display(Name = "Hubraum")]
        [Required(ErrorMessage = "Bitte eingeben den Hubraum")]
        public double Cubic_capacity { get; set; }

        [Display(Name = "Kilometerstand")]
        [Required(ErrorMessage = "Bitte eingeben den Kilometerstand")]
        public double Mileage { get; set; }

        [Display(Name = "Fahrgestellnummer")]
        [Required(ErrorMessage = "Bitte eingeben den Fahrgestellnummer")]
        public string Chassis_number { get; set; }

        [Display(Name = "Motorleistung")]
        [Required(ErrorMessage = "Bitte eingeben den Motorleistung")]
        public int Engine_power { get; set; }

        [Display(Name = "Eigengewicht")]
        [Required(ErrorMessage = "Bitte eingeben den Eigengewicht")]
        public int Own_Weight { get; set; }

        [Display(Name = "Verkauft")]
        [Required(ErrorMessage = "Bitte eingeben den Verkauftstatus")]
        public bool Sold { get; set; }

        [Display(Name = "Nettopreis")]
        [Required(ErrorMessage = "Bitte eingeben den Nettopreis")]
        public double NettoPrice { get; set; }

    }

}
