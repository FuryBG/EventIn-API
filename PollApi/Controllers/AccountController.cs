using Domain.DtoModels;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace PollApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginUserDto loginUser)
        {
            Response.Cookies.Append("at", _authService.BuildUserToken(loginUser));
            return Ok();
        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterUserDto registerUser)
        {
            _authService.UserRegister(registerUser);
            return Created("", "Successful Registration! We sent you, an activation link on your email.");
        }
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("at");
            return Ok();
        }
        [HttpGet("GetUserById")]
        public IActionResult GetUserById(int userId)
        {
            User user = _authService.GetUserById(userId);
            return Ok(user);
        }
        [HttpGet("Activate")]
        public IActionResult Activate(string activateHash)
        {
            User user = _authService.ActivateUser(activateHash);
            return Ok("Activation Successful");
        }
    }
}
