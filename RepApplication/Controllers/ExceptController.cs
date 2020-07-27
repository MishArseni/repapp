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
    [Route("api/except")]
    public class ExceptController:Controller
    {
        ApplicationContext db;

        public ExceptController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]

        public IEnumerable<Project> GetExcept()
        {
            string name = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            User user = db.Users.FirstOrDefault(u => u.Email == name);

            var projectsId = db.userProjects.Where(u => u.UserId == user.UserId).Select(u => u.ProjectId);
            List<Project> myProjects = new List<Project>();

            foreach (var project in db.Projects.ToList())
            {
                if (projectsId.Contains(project.ProjectId))
                {
                    myProjects.Add(project);
                }
            }

            return db.Projects.ToList().Except(myProjects);
        }

    }
}
