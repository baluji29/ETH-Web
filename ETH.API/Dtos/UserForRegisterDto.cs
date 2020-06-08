using System.ComponentModel.DataAnnotations;

namespace ETH.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [Phone]
        [StringLength(10, MinimumLength = 10,  ErrorMessage = "Phone Number must contain 10 digits")]
        public string Mobilenumber { get; set; } 


        [Required]
        [StringLength(8, MinimumLength = 5, ErrorMessage = "Password must between 5 to 8 character ")]
        public string Password { get; set; }  
    }
}