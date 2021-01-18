using BlogUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogUI.Controllers
{
    public class HomeController : Controller
    {
        [BindProperty]
        public UserData Input { get; set; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                if(Input.Username == "edusie")
                {
                    Input.Role = "Writer";
                }
                if(Input.Username == "edusie2")
                {
                    Input.Role = "Editor";
                }
                if (!string.IsNullOrEmpty(Input.Role))
                {
                    this.SignInUser(Input);
                    returnUrl = "~/";
                }
                else
                {
                    ModelState.AddModelError("noautorized", "No authorized");
                }
            }
            return LocalRedirect(returnUrl);
        }

        private async void SignInUser(UserData loginInfo)
        {
            var claims = new List<Claim>();
            try
            {
                claims.Add(new Claim(ClaimTypes.Name, loginInfo.Username));
                claims.Add(new Claim(ClaimTypes.Role, loginInfo.Role));
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        IsPersistent = true
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
