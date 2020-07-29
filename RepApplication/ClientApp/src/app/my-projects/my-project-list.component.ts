import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../project.service';
import { Project } from '../models/project';
import { User } from '../models/user';
import { CurrentUserService } from '../currentUser.service';

@Component({
  templateUrl: './my-project-list.component.html',
  styleUrls: ['./my-project-list.component.css']
})

export class MyProjectListComponent implements OnInit {

  projects: Project[];
  user: User
  constructor(private projectService: ProjectService, private curentService: CurrentUserService) { }

  ngOnInit() {
    this.load();
  }
  load() {
    this.projectService.getMyProjects().subscribe((data: Project[]) => this.projects = data);
    this.curentService.getCurrent().subscribe((data: User) => this.user = data);
  }

  delete(id: number) {
    this.projectService.deleteFromMyProjects(id).subscribe(data => this.load());
  }
}
