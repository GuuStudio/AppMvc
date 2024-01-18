

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace App.Models.Contacts {
    public class Contact {

        [Key]
        public int Id {set;get;}

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Required( ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "Họ Và Tên")]
        public string FullName {set;get;}  = "";
        
        [Required(ErrorMessage = "Phải nhập {0}")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Phải là địa chỉ {0}")]
        public string Email {set;get;}  ="";

        public DateTime DateSent {set;get;}

        [Display(Name = "Tin nhắn")]
        public string? Message {set;get;} 

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Cần phải nhập {0}")]
        public string Phone {set;get;} = "";
    }
}