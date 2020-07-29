import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Project } from '../models/project';
import { ProjectService } from '../project.service';

@Component({
  templateUrl: 'project-create.component.html'
})

export class ProjectCreateComponent {
  project: Project = new Project();
  constructor(private projectService: ProjectService, private router: Router) { }

  save() {
    this.projectService.createProject(this.project).subscribe();
    window.location.href = '/projectList';
  }
}
