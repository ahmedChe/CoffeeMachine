import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { first } from 'rxjs/operators';
import { passwordConfirming } from '../validators/confirm-password';
import {existAsyncValidator} from '../validators/exist-data';

import { AuthenticationService } from '../services/authentification.service';
import { Client } from '../model/Client';
@Component({
  selector: 'app-login',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';
  title:string = 'Create New account';
  emailPattern:string = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
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
          username: ['', Validators.required, existAsyncValidator(this.authenticationService)],
          email: ['', [Validators.required,Validators.pattern(this.emailPattern)], existAsyncValidator(this.authenticationService)],
          passwords: this.formBuilder.group({
            password: ['', [Validators.required]],
            confirm_password: ['', [Validators.required]],
        }, {validator: passwordConfirming})
      });
      this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }
  
  onSubmit() {
      this.submitted = true;

      if (this.loginForm.invalid) {
          return;
      }

      this.loading = true;
      this.authenticationService.signup(new Client(this.username.value,this.email.value,this.password.value))
          .pipe(first())
          .subscribe(
              data => {
                  this.router.navigate([this.returnUrl]);
              },
              error => {
                  this.error = error;
                  this.loading = false;
              });
  }
  get f() { return this.loginForm.controls; }
  get username() { return this.loginForm.controls.username; }
  get email() { return this.loginForm.controls.email; }
  get password() { return (<FormGroup>this.loginForm.controls.passwords).controls.password;  }

}
