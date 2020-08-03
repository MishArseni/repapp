using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RepApplication.Models
{
    [ApiController]
    [Route("api/myProjects")]
    public class MyProjectsController : Controller
    {
        private ApplicationContext db;
        public MyProjectsController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Project>> GetMyProjects()
        {
            var name = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            User user = await db.Users.FirstOrDefaultAsync(u => u.Email == name);

            var projectsId = db.userProjects.Where(u => u.UserId == user.UserId).Select(u => u.ProjectId);
            List<Project> myProjects = new List<Project>();

            foreach (var project in db.Projects.ToList())
            {
                if (projectsId.Contains(project.ProjectId))
                {
                    myProjects.Add(project);
                }
            }
            return myProjects;
        }

        [HttpPost]
        public async Task<IActionResult> AddToMyProjects([FromBody] int id)
        {
            var name = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            User user = await db.Users.FirstOrDefaultAsync(u => u.Email == name);
            Project project = await db.Projects.FirstOrDefaultAsync(u => u.ProjectId == id);

            UserProject userProj = new UserProject { User = user, Projects = project };
            await db.userProjects.AddAsync(userProj);
            await db.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFromMyProjects(int id)
        {
            Project project = await db.Projects.FirstOrDefaultAsync(u => u.ProjectId == id);

            if (project != null)
            {
                var name = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == name);
                UserProject userProj = new UserProject { User = user, Projects = project };
                db.userProjects.Remove(userProj);
                await db.SaveChangesAsync();
                return Ok(id);
            }
            return BadRequest();
        }
    }
}