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
    [Route("api/getCurrentUser")]
    public class CurrentController : Controller
    {
        ApplicationContext db;
        public CurrentController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetCurrentUser()
        {
            var name = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            User user = await db.Users.FirstOrDefaultAsync(u => u.Email == name);
            return user;
        }

        [HttpDelete]

        public async void Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        }


    }
}
