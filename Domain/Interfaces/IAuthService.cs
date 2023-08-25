using Domain.DtoModels;

namespace Domain.Interfaces
{
    public interface IAuthService
    {
        public string BuildUserToken(LoginUserDto loginUser);
        public string UserRegister(RegisterUserDto registerUser);

    }
}
