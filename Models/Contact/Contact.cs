

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace App.Models.Contacts {
    public class Contact {

        [Key]
        public int Id {set;get;}

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Required]
        public string FullName {set;get;}  = "";
        
        [Required]
        [StringLength(100)]
        public string Email {set;get;}  ="";

        public DateTime DateSent {set;get;}
        public string? Message {set;get;} 

        [StringLength(50)]
        public string Phone {set;get;} = "";
    }
}