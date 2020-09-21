import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { map } from 'rxjs/operators';

import { AuthenticationService } from '../services/authentification.service';
import { Client } from '../model/Client';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';
  title:string ='Connexion';
  constructor(
      private formBuilder: FormBuilder,
      private route: ActivatedRoute,
      private router: Router,
      private authenticationService: AuthenticationService
  ) { 
      if (this.authenticationService.currentUserValue) { 
          this.router.navigate(['/']);
      }
  }

  ngOnInit() {
      this.loginForm = this.formBuilder.group({
          username: ['', Validators.required],
          password: ['', Validators.required]
      });
      this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }
  
  onSubmit() {
      this.submitted = true;

      if (this.loginForm.invalid) {
          return;
      }

      this.loading = true;
      let client:Client = new Client(this.f.username.value,"",this.f.password.value);
      this.authenticationService.login(client)
          .subscribe((result:boolean) => {
                  if (result)
                  {
                    this.router.navigate([this.returnUrl]);
                  }
                  else
                  {
                    this.error ="username/password is wrong";
                  }
                  this.loading = false;
              },
              error => {
                  this.error = error;
                  this.loading = false;
              });
  }
  get f() { return this.loginForm.controls; }
}
