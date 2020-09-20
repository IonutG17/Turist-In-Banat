using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TuristInBanat.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        [Required, MinLength(5), Index(IsUnique = true), Column(TypeName = "VARCHAR")]
        [Display(Name = "Nume Utilizator:")]
        public string Username { get; set; }

        [MinLength(5), Required, DataType(DataType.Password)]
        [Display(Name = "Parola:")]
        public string Password { get; set; }

        [EmailAddress, Index(IsUnique = true), Column(TypeName = "VARCHAR"), Required]
        [Display(Name = "Adresa email:")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Poza profil:")]
        public string ImageUrl { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Data crearii contului:")]
        public DateTime? CreatedOn { get; set; }
    }
}