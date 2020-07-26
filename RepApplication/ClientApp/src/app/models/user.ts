import { Role } from './role';
import { UserProject} from './userProjects'

export class User {
  constructor(
    public userId?: number,
    public name?: string,
    public email?: string,
    public password?: string,
    public roleId?: number,
    public role?: Role,
    public userProjects?: UserProject[]
) { }
}
