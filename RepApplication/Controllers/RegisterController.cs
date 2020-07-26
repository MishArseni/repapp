using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RepApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RepApplication.Controllers
{
    [ApiController]
    [Route("api/registrateuser")]
    public class RegisterController : Controller
    {
        ApplicationContext db;
        public RegisterController(ApplicationContext context)
        {
            db = context;
        }

        [HttpPost]
        
        public async Task<ActionResult<User>> RegistrateUser(User user)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.FirstOrDefault(u => u.Email == user.Email) == null)
                {
                    Role userRole = db.Roles.FirstOrDefault(r => r.Name == "employee");
                    if (userRole != null)
                        user.Role = userRole;

                    db.Users.Add(user);
                   await db.SaveChangesAsync();
                    await Authenticate(user);
                }
            }

            else
            {
                ModelState.AddModelError(string.Empty, "Пользователь с таким Email уже существует");
            }

            return Ok(user);
        }

        [HttpPut]
  
        public async Task<ActionResult<User>> LoginUser(User user)
        {
            if (ModelState.IsValid)
            {
                if(db.Users.FirstOrDefault(u=>u.Email == user.Email && u.Password == user.Password)!= null)
                {
                    await Authenticate(user);
                    return Ok(user);

                }
            }
            ModelState.AddModelError(string.Empty, "Некорректные логин и(или) пароль");
            return BadRequest(ModelState);
        }
        private async Task Authenticate(User user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
               
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
