using System;
using System.ComponentModel.DataAnnotations;

namespace Rathee_Arsenal.Data.Model
{
    public class User
    {
        [Key]
        public Guid UserUid{ get; set; }

        [EmailAddress]
        [Display(Name = "User name")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is a required field.")]
        public string Email { get; set; }

       
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is a required field.")]
        public string Password { get; set; }


        [Display(Name = "name")]
        [StringLength(25)]
        [Required(ErrorMessage = "Name is a required field.")]
        public string BuyerName { get; set; }

        [Required(ErrorMessage = "Address is a required field.")]
        public string Address { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
}
