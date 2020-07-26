using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepApplication.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        ApplicationContext db;
        public UserController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.Users.ToList();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            User user = db.Users.FirstOrDefault(u => u.UserId == id);
            return user;
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                var result = await db.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
                if (result == null)
                {
                    Role userRole = await db.Roles.FirstOrDefaultAsync(r => r.Name == "employee");
                    if (userRole != null)
                        user.Role = userRole;

                    await db.Users.AddAsync(user);
                    await db.SaveChangesAsync();
                    return Ok(user);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(User user)
        {
            if (ModelState.IsValid)
            {
                Role userRole = db.Roles.FirstOrDefault(r => r.Name == "employee");
                if (userRole != null)
                    user.Role = userRole;
                db.Update(user);
                db.SaveChanges();
                return Ok(user);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.UserId == id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
            return Ok(user);
        }

    }
}
