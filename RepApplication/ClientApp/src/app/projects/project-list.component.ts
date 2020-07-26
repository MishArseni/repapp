import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../project.service';
import { Project } from '../models/project';

@Component({
  templateUrl: './project-list.component.html'
})

export class ProjectListComponent implements OnInit {

  projects: Project[];
  constructor(private projectService:ProjectService) { }

  ngOnInit() {
    this.load();
  }
  load() {
    this.projectService.getProjects().subscribe((data: Project[]) => this.projects = data);
  }

  delete(id: number) {
    this.projectService.deleteProject(id).subscribe(data => this.load());
  }
}
