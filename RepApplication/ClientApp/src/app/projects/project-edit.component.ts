import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Project } from '../models/project';
import { ProjectService } from '../project.service';

@Component({
  templateUrl: './project-edit.component.html'
})

export class ProjectEditComponent implements OnInit {

  id: number;
  project: Project;
  loaded: boolean = false;

  constructor(private projectService: ProjectService, private router: Router, activeRoute: ActivatedRoute) {
    this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
  }

  ngOnInit() {
    if (this.id)
      this.projectService.getProject(this.id).subscribe((data: Project) => {
        this.project = data;
        if (this.project != null) this.loaded = true;
      });
  }

  save() {
    this.projectService.updateProject(this.project).subscribe(data => this.router.navigateByUrl("/"));
    window.location.href = '/userList';
  }

}

