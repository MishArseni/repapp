import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Project } from './models/project';

@Injectable()
export class ProjectService {
  private url = "/api/projects";

  constructor(private http: HttpClient) {
  }

  getProjects() {
    return this.http.get(this.url);
  }

  getProject(id: number) {
    return this.http.get(this.url + '/' + id);
  }

  createProject(project: Project) {
    return this.http.post(this.url, project);
  }

  updateProject(project: Project) {
    return this.http.put(this.url, project);
  }

  deleteProject(id: number) {
    return this.http.delete(this.url + '/' + id);
  }

}
