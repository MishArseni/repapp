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
    public class ProjectController : Controller
    {
        ApplicationContext db;
        public ProjectController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> Get()
        {
            return await db.Projects.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Project> Get(int id)
        {
            Project project = await db.Projects.FirstOrDefaultAsync(u => u.ProjectId == id);
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
        public async Task<IActionResult> Put(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Update(project);
                await db.SaveChangesAsync();
                return Ok(project);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Project project = await db.Projects.FirstOrDefaultAsync(x => x.ProjectId == id);
            if (project != null)
            {
                db.Projects.Remove(project);
                await db.SaveChangesAsync();
            }
            return Ok(project);
        }

    }
}
