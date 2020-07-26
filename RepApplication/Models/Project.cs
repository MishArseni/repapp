using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepApplication.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Price { get; set; }
        public List<UserProject> UserProjects { get; set; }
        public Project()
        {
            UserProjects = new List<UserProject>();
        }
    }
}
