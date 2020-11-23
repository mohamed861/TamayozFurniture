using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Furniture.MVC.Data;
using Furniture.MVC.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Furniture.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly ITrackRepo _repo;

        public AuthController(ITrackRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserForLoginDto user)
        {
            var admin = await _repo.Login(user.UserName, user.Password);
            if (admin != null)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, admin.Name));

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
    }
}
