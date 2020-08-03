using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                user = await db.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
                if (user == null)
                {
                    Role userRole = await db.Roles.FirstOrDefaultAsync(r => r.Name == "employee");
                    if (userRole != null)
                        user.Role = userRole;

                    await db.Users.AddAsync(user);
                    await db.SaveChangesAsync();
                    await Authenticate(user.Name);
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
                user = await db.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);
                if (user != null)
                {
                    await Authenticate(user.Name);
                    return Ok(user);

                }
            }
            ModelState.AddModelError(string.Empty, "Некорректные логин и(или) пароль");
            return BadRequest(ModelState);
        }
        private async Task Authenticate(string userName)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }



    }
}
