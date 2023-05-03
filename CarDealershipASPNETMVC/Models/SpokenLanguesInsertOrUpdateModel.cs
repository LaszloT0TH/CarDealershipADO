using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models
{
     public class SpokenLanguesInsertOrUpdateModel
    {
        [Display(Name = "Muttersprache Id")]
        public int? SpokenLanguesId { get; set; }

        [Display(Name = "Muttersprache Name")]
        [Required(ErrorMessage = "Bitte eingeben den Muttersprache Name")]
        public string SpokenLanguesName { get; set; }
    }

}
