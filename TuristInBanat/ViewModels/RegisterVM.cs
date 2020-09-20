using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TuristInBanat.ViewModels
{
    public class RegisterVM
    {

        [Required, MinLength(5)]
        [Display(Name = "Nume Utilizator")]
        public string Username { get; set; }

        [MinLength(5), Required, DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [Compare("Password"), DataType(DataType.Password)]
        //[Display(Name = "Confirm Password")]
        [Display(Name = "Confirmati parola")]

        public string ConfirmPassword { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

    }
}