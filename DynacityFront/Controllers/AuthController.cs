using AutoMapper;
using DynacityFront.DTO;
using DynacityFront.Models;
using DynacityFront.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using Utility;

namespace DynacityFront.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment webHostEnvironment;
        public AuthController(IAuthService authService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _authService = authService;
            _mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Login()
        {
            Login_Request obj = new();
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login_Request obj)
        {
            APIResponse response = await _authService.LoginAsync<APIResponse>(obj);
            if (response != null && response.IsSuccess)
            {
                Login_Response model = JsonConvert.DeserializeObject<Login_Response>(Convert.ToString(response.Result));
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Email, model.User.Email));
                identity.AddClaim(new Claim(ClaimTypes.Role, model.Roles.FirstOrDefault()));
                var princple = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, princple);


                HttpContext.Session.SetString(SD.SessionToken, model.Token);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", response.ErrorsMessages.FirstOrDefault());
                return View(obj);
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register_Request obj)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(obj.UserImage.FileName);
                string extension = Path.GetExtension(obj.UserImage.FileName);
                obj.UserImageURL = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await obj.UserImage.CopyToAsync(fileStream);
                }
                obj.UserImage = null;
            }
            APIResponse result = await _authService.RegisterAsync<APIResponse>(obj);
            if (result != null && result.IsSuccess)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString(SD.SessionToken, "");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult ForgetPass()
        {
            return View();
        }
    }
}
