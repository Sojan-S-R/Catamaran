using System.ComponentModel.DataAnnotations;

namespace CatamaranBlazor.Models
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Please check the username entered.")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Please check the password entered.")]
        public string Password { get; set; }
    }
}
