using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Domain.DtoModels
{
    public class RegisterUserDto : LoginUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Compare("Password")]
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
