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
    [Route("api/getCurrentUser")]
    public class CurrentController:Controller
    {
        ApplicationContext db;
        public CurrentController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public User GetCurrentUser()
        {
            string name = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            User user = db.Users.FirstOrDefault(u => u.Email == name);
            return user;
        }


    }
}
