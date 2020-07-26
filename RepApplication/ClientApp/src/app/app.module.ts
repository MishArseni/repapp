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
//UserCRUDComponent
import { UserFormComponent } from './users/user-form.component';
import { UserCreateComponent } from './users/user-create.component';
import { UserEditComponent } from './users/user-edit.component';
import { UserListComponent } from './users/user-list.component';


//Services
import { RegisterUserService } from './registerUser.service';
import { CurrentUserService } from './currentUser.service';
import { UserService } from './user.service';


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
    UserListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: UserListComponent, pathMatch: 'full' },
      { path: 'register', component: RegisterComponent },
      { path: 'login', component: LoginComponent },
      { path: 'create', component: UserCreateComponent },
      { path: 'edit/:id', component: UserEditComponent },
    ])
  ],
  providers: [RegisterUserService, CurrentUserService, UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
