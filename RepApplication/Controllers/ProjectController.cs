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
    [Route("api/projects")]
    public class ProjectController:Controller
    {
        ApplicationContext db;
        public ProjectController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return db.Projects.ToList();
        }

        [HttpGet("{id}")]
        public Project Get(int id)
        {
            Project project = db.Projects.FirstOrDefault(u => u.ProjectId == id);
            return project;
        }


        [HttpPost]
        public async Task<IActionResult> CreateProject(Project project)
        {
            if (ModelState.IsValid)
            {
                var result = await db.Projects.FirstOrDefaultAsync(u => u.Name == project.Name);
                if (result == null)
                {
                    await db.Projects.AddAsync(project);
                    await db.SaveChangesAsync();
                    return Ok(project);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Update(project);
                db.SaveChanges();   
                return Ok(project);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Project project = db.Projects.FirstOrDefault(x => x.ProjectId == id);
            if (project != null)
            {
                db.Projects.Remove(project);
                db.SaveChanges();
            }
            return Ok(project);
        }

    }
}
