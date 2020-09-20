using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuristInBanat.ViewModels
{
    public class LoginVM
    {

        [Required]
        [Display(Name = "Nume Utilizator")]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }


        [Display(Name = "Recunoaste dispozitivul?")]
        public bool RememberMe { get; set; }

        //public bool Authenticated { get; set; }

        //for the home controller tryout
        //public int LoggedInUserId { get; set; }
    }
}