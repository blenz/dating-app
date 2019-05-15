using System.ComponentModel.DataAnnotations;

namespace DatingApp.Dto
{
    public class UserRegisterDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Your password must be 4 and 10 characters")]
        public string Password { get; set; }
    }
}