﻿using System.ComponentModel.DataAnnotations;

namespace CarDealershipASPNETMVC.Models;
public class CustomerModel
{
    [Display(Name = "Kunde Id")]
    public int? CustomerId { get; set; }

    [Display(Name = "Vorname")]
    public string? FirstName { get; set; }

    [Display(Name = "Nachname")]
    public string? LastName { get; set; }

    [Display(Name = "Geschlecht")]
    public string? SexName { get; set; }

    [Display(Name = "Straße")]
    public string? Street { get; set; }
    
    [Display(Name = "Hausnummer")]
    public string? House_Number { get; set; }
    
    [Display(Name = "Postleitzahl")]
    public int? PostalCode { get; set; }
    
    [Display(Name = "Ort")]
    public string? Location { get; set; }
    
    [Display(Name = "Land")]
    public string? CountryName { get; set; }
    
    [Display(Name = "Geburtsdatum")]
    public DateTime? DateOfBirth { get; set; }
    
    [Display(Name = "Telefonnummer")]
    public double? TelNr { get; set; }
    
    [Display(Name = "Email")]
    public string? Email { get; set; }

    public string? CustomersListItem
    {
        get { return CustomerId + " " + FirstName + " " + LastName + ", " + Email; }
    }

}
