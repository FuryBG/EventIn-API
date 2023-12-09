using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Domain.DtoModels
{
    public class RegisterUserDto : LoginUserDto
    {
        [Required(ErrorMessage = "This field is required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        [Compare("Password", ErrorMessage = "Passwords must match!")]
        public string RepeatPassword { get; set; }

        public static User RegisterUserToUser(RegisterUserDto registerUser)
        {
            User user = new User();
            user.FirstName = registerUser.FirstName;
            user.LastName = registerUser.LastName;
            user.Email = registerUser.Email;
            return user;
        }
    }
}
