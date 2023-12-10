using System.ComponentModel.DataAnnotations;

namespace Domain.DtoModels
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*\\d).{8,}$", ErrorMessage = "Password must be 8 chars long and must include a number!")]
        public string Password { get; set; }
    }
}
