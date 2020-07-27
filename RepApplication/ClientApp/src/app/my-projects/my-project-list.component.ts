import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../project.service';
import { Project } from '../models/project';

@Component({
  templateUrl: './my-project-list.component.html'
})

export class MyProjectListComponent implements OnInit {

  projects: Project[];

  constructor(private projectService: ProjectService) { }

  ngOnInit() {
    this.load();
  }
  load() {
    this.projectService.getMyProjects().subscribe((data: Project[]) => this.projects = data);
  }

  delete(id: number) {
    this.projectService.deleteFromMyProjects(id).subscribe(data => this.load());
  }
}
