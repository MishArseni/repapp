import { User } from './user';
import { Project } from './project';

export class UserProject {
  constructor(
    public userId?: number,
    public user?: User,
    public projectId?: number,
    public projects?: Project
  ) { }
}
