import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule,ReactiveFormsModule  } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { BaverageService } from './services/baverage.service';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './helpers/AuthGuard';
import { SignUpComponent } from './sign-up/sign-up.component';
import {AuthenticationService} from './services/authentification.service';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    SignUpComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule, 
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent },
      { path: 'signup', component: SignUpComponent},
      { path: '**', redirectTo: '' }
    ])
  ],
  providers: [BaverageService, AuthenticationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
