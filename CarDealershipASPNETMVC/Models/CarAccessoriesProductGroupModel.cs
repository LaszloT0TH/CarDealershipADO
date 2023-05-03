﻿using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models
{
    public class CarAccessoriesProductGroupModel
    {
        [Display(Name = "Produktgruppe Autozubehör Id")]
        public int? CAPGId { get; set; }

        [Display(Name = "Produktgruppe Autozubehör Name")]
        public string? CAPGName { get; set; }
    }
}
