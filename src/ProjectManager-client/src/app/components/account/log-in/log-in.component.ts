import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar} from "@angular/material/snack-bar";
import { Router } from '@angular/router';


import { User } from '../models/user.model';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {

  constructor(private accountService: AccountService,
              private snackBar: MatSnackBar,
              private router: Router) { }

  loginForm: FormGroup;
  user: User;
  loginIn: boolean = false;

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required])
    })
  }

  hasError = (controlName: string, errorName: string) => {
    return this.loginForm.controls[controlName].hasError(errorName);
  }

  login(){
    if (this.loginForm.dirty && this.loginForm.valid){
      this.user = Object.assign({}, this.user, this.loginForm.value);

      this.accountService.login(this.user)
          .subscribe(
            response => {this.proccessResult(response)},
            error => {this.proccessError(error)}
      );
    }
  }

  proccessResult = (response: any) => {
    this.loginForm.disable();
    this.loginIn = true;
    
    this.accountService.localStorage.saveUserData(response);

    this.openSnackBar('Usuário logado com sucesso. Redirecionando...');

    // setTimeout(() => {
    //   this.router.navigate(['/dashboard'])
    // }, 3000);
  }

  proccessError = (fail: any) => {
    fail.error.errors.Messages.forEach(errorMessage => {
      this.openSnackBar(errorMessage);
    });    
  }

  openSnackBar = (message: string) => {
    this.snackBar.open(message, 'X', {
      duration: 15000,
      horizontalPosition: 'start',
      verticalPosition: 'top'
    });
  }
}