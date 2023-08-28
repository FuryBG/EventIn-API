using Domain.DtoModels;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthPollRepository _pollRepository;
        private readonly IConfiguration _configuration;
        private readonly EmailService _emailService;
        public AuthService(IAuthPollRepository pollRepository, IConfiguration configuration, EmailService emailService)
        {
            _pollRepository = pollRepository;
            _configuration = configuration;
            _emailService = emailService;
        }

        public string BuildUserToken(LoginUserDto loginUser)
        {
            User user = _pollRepository.GetUserByEmail(loginUser.Email);
            if (user != null && CheckPassword(user.HashPassword, loginUser.Password))
            {
                return BuildJwt(user);
            }
            throw new Exception("Wrong Email or Password");
        }

        public void UserRegister(RegisterUserDto registerUser)
        {
            if (CheckIfUserExists(registerUser.Email))
            {
                User user = RegisterUserDto.RegisterUserToUser(registerUser);
                user.HashPassword = HashPassword(registerUser.Password);
                user.ActivationHash = BuildActivateHash(registerUser.Email);
                _emailService.SendEmail(EmailMessageBuilder(user.ActivationHash), registerUser.Email);
                _pollRepository.SaveUser(user);
                return;
            }
            throw new Exception("Email is already taken!");
        }

        private string HashPassword(string password)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(password);
            Byte[] keyBytes = encoding.GetBytes(_configuration["Hash:Salt"]);
            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes);
        }

        private bool CheckPassword(string hashedPassword, string password)
        {
            string userInputHash = HashPassword(password);
            if (hashedPassword == userInputHash)
            {
                return true;
            }
            return false;
        }

        private bool CheckIfUserExists(string email)
        {
            User user = _pollRepository.GetUserByEmail(email);
            if (user != null) { return false; }
            return true;
        }

        private string BuildJwt(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Email, user.Email),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("Jwt:Key").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: cred,
            audience: _configuration.GetSection("Jwt:Issuer").Value,
            issuer: _configuration.GetSection("Jwt:Issuer").Value);
            string jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private string EmailMessageBuilder(string hash)
        {
            return $"Activate your account on this link: <a href=\"https://localhost:7029/Account/Activate?activatehash={hash}\">https://localhost:7029/Account/Activate?activatehash={hash}</a>";
        }

        private string BuildActivateHash(string email)
        {
            return HashPassword(email);
        }
    }
}
