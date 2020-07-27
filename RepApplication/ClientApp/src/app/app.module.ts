import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
//Login/Register
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './register/login.component';
//UserCRUDComponents
import { UserFormComponent } from './users/user-form.component';
import { UserCreateComponent } from './users/user-create.component';
import { UserEditComponent } from './users/user-edit.component';
import { UserListComponent } from './users/user-list.component';
//ProjectCRUDComponents
import { ProjectFormComponent } from './projects/project-form.component';
import { ProjectCreateComponent } from './projects/project-create.component';
import { ProjectListComponent } from './projects/project-list.component';
import { ProjectEditComponent } from './projects/project-edit.component';

//Services
import { RegisterUserService } from './registerUser.service';
import { CurrentUserService } from './currentUser.service';
import { UserService } from './user.service';
import { ProjectService } from './project.service';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,

    LoginComponent,
    RegisterComponent,

    UserFormComponent,
    UserCreateComponent,
    UserEditComponent,
    UserListComponent,

    ProjectFormComponent,
    ProjectCreateComponent,
    ProjectListComponent,
    ProjectEditComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: UserListComponent, pathMatch: 'full' },
      { path: 'register', component: RegisterComponent },
      { path: 'login', component: LoginComponent },
      { path: 'createUser', component: UserCreateComponent },
      { path: 'edit/:id', component: UserEditComponent },
      { path: 'createProject', component: ProjectCreateComponent },
      { path: 'projectList', component: ProjectListComponent },
      { path: 'projectList/curproj/:id', component: ProjectEditComponent },
    ])
  ],
  providers: [RegisterUserService, CurrentUserService, UserService, ProjectService],
  bootstrap: [AppComponent]
})
export class AppModule { }
