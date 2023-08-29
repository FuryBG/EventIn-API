using Domain.DtoModels;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IAuthService
    {
        public string BuildUserToken(LoginUserDto loginUser);
        public void UserRegister(RegisterUserDto registerUser);
        public User ActivateUser(string activateHash);

    }
}
