using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        //For Data Validation.
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}