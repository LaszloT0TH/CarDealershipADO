using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models
{
    public class CarAccessoriesProductGroupInsertOrUpdateModel
    {
        [Display(Name = "Produktgruppe Autozubehör Id")]
        public int? CAPGId { get; set; }

        [Display(Name = "Produktgruppe Autozubehör Name")]
        [Required(ErrorMessage = "Bitte eingeben den Produktgruppe Autozubehör Name")]
        public string CAPGName { get; set; }

    }
}
