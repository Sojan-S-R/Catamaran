using System;
using System.ComponentModel.DataAnnotations;

namespace CatamaranBlazor.Models
{
    public class RegisterModel
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Please check the First Name.")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Please check the Last Name.")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "Please check the Email address.")]
        public string EmailAddress { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public long PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Please check the chosen user name.")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Please check the password entered.")]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Please check the reentered password.")]
        public string Reenter_Password { get; set; }
    }
}

