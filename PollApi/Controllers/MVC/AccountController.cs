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
        private readonly IConfiguration _configuration;
        public AccountController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginUserDto loginUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Response.Cookies.Append("at", _authService.BuildUserToken(loginUser), new CookieOptions() { HttpOnly = true, Secure = true, SameSite = SameSiteMode.None });
                    return Redirect(_configuration["FrontEndApplicationUrl"]);
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterUserDto registerUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _authService.UserRegister(registerUser);
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("at");
            return Ok();
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetUser()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User user = _authService.GetUserById(userId);
            return Ok(user);
        }
        [HttpGet]
        public IActionResult Activate(string activateHash)
        {
            try
            {
                User user = _authService.ActivateUser(activateHash);
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}
