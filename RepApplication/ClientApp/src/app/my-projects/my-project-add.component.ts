import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Project } from '../models/project';
import { ProjectService } from '../project.service';

@Component({
  templateUrl: 'my-project-add.component.html'
})

export class MyProjectAddComponent{

  projects: Project[];
  constructor(private projectService: ProjectService, private router: Router) { }

  ngOnInit() {
    this.projectService.getExcept().subscribe((data: Project[]) => this.projects = data);
      
  }

  save(id: number) {
    this.projectService.addToMyProjects(id).subscribe();
    window.location.href = '/projectList';
  }
}
