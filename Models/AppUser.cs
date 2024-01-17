

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace App.Models {
    public class AppUser : IdentityUser  {


        [MaxLength(255)]
        public string HomeAddress {set;get;} = "";


        [DataType(DataType.Date)]
        public DateTime? BirthDate {set;get;}
    }
}