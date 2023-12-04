using Domain.DtoModels;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PollApi.Controllers.MVC
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginUserDto loginUser)
        {
            try
            {
                Response.Cookies.Append("at", _authService.BuildUserToken(loginUser), new CookieOptions() { HttpOnly = true, Secure = true, SameSite = SameSiteMode.Strict });
                return Redirect("https://localhost:5173/");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterUserDto registerUser)
        {
            try
            {
                _authService.UserRegister(registerUser);
                return View();
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("at");
            return Ok();
        }
        [Authorize]
        [HttpGet("GetUser")]
        public IActionResult GetUser()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
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
