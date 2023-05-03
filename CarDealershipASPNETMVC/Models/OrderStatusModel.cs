using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models;
public class OrderStatusModel
{
    [Display(Name = "Auftragsstatus Id")]
    public int? OrderStatusId { get; set; }

    [Display(Name = "Auftragsstatusname")]
    public string? OrderStatusName { get; set; }
}
