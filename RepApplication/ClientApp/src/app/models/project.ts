import { UserProject } from './userProjects'

export class Project {
  constructor(
    public projectId?: number,
    public name?: string,
    public date?: string,
    public price?: string,
    public userProjects?: UserProject[]
  ) { }
}
