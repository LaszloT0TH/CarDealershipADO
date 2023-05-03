using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models
{
    public class SalespersonInsertUpdateModel
    {
        [Display(Name = "Verkäufer Id")]
        public int? SalesId { get; set; }

        [Display(Name = "Vorname")]
        [Required(ErrorMessage = "Bitte eingeben den Vorname")]
        public string FirstName { get; set; }

        [Display(Name = "Nachname")]
        [Required(ErrorMessage = "Bitte eingeben den Nachname")]
        public string LastName { get; set; }

        [Display(Name = "Geschlecht")]
        [Required(ErrorMessage = "Bitte eingeben den Geschlecht")]
        public string SexName { get; set; }

        [Display(Name = "Muttersprache")]
        [Required(ErrorMessage = "Bitte eingeben die Muttersprache")]
        public string SpokenLanguesName { get; set; }

        [Display(Name = "Manager")]
        public int? ManagerId { get; set; }

        [Display(Name = "Geburtsdatum")]
        [Required(ErrorMessage = "Bitte eingeben den Geburtsdatum")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Straße")]
        [Required(ErrorMessage = "Bitte eingeben den Straßename")]
        public string Street { get; set; }

        [Display(Name = "Hausnummer")]
        [Required(ErrorMessage = "Bitte eingeben den Hausnummer")]
        public string House_Number { get; set; }

        [Display(Name = "Postleitzahl")]
        [Required(ErrorMessage = "Bitte eingeben den Postleitzahl")]
        public int PostalCode { get; set; }

        [Display(Name = "Ort")]
        [Required(ErrorMessage = "Bitte eingeben den Ort")]
        public string Location { get; set; }

        [Display(Name = "Land")]
        [Required(ErrorMessage = "Bitte eingeben den Land")]
        public string CountryName { get; set; }

        [Display(Name = "Eintrittsdatum")]
        [Required(ErrorMessage = "Bitte eingeben den Geburtsdatum")]
        public DateTime EntryDate { get; set; }

        [Display(Name = "Telefonnummer")]
        [Required(ErrorMessage = "Bitte eingeben den Telefonnummer")]
        public double TelNr { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Bitte eingeben die EmailAdresse")]
        public string Email { get; set; }

    }

}
