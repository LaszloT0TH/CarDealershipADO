using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models
{
    public class OrderStatusInsertOrUpdateModel
    {
        [Display(Name = "Auftragsstatus Id")]
        public int? OrderStatusId { get; set; }

        [Display(Name = "Auftragsstatusname")]
        [Required(ErrorMessage = "Bitte eingeben den Name des Auftragsstatus")]
        public string OrderStatusName { get; set; }

    }
}
