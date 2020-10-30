import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from "@angular/material/snack-bar";

import { MustMatch } from 'src/app/helpers/must-match.validator';
import { User } from '../models/user.model';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private formBuilder: FormBuilder,
              private accountService: AccountService,
              private snackBar: MatSnackBar ) { }

  registerForm: FormGroup;
  user: User;

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      email: new FormControl('', [ 
        Validators.required,
        Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$") 
      ]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(8)
      ]),
      passwordConfirmation: new FormControl('', [
        Validators.required        
      ])
    }, {
      validators: MustMatch('password', 'passwordConfirmation')
    });
  }

  hasError = (controlName: string, errorName: string) => {
    return this.registerForm.controls[controlName].hasError(errorName);
  }

  register = () => {
    if (this.registerForm.dirty && this.registerForm.valid) {
      this.user = Object.assign({}, this.user, this.registerForm.value);

      this.accountService.registerUser(this.user).subscribe(
        result => { this.proccessResult(result) },
        error => { this.proccessError(error) }
      );
    }
  }

  proccessResult = (response: any) => {
    this.registerForm.reset;
    
    this.accountService.localStorage.saveUserData(response);

    this.openSnackBar('Usuário registrado com sucesso');
  }

  proccessError = (fail: any) => {
    console.error(fail);
    this.openSnackBar('Falha ao registrar o novo usuário');
  }

  openSnackBar = (message: string) => {
    this.snackBar.open(message, 'X', {
      duration: 15000,
      horizontalPosition: 'start',
      verticalPosition: 'top'
    });
  }

  showSnackbar (){
    this.snackBar.open("Hallo!!", "X", {
      horizontalPosition: 'start',
      verticalPosition: 'top',
      panelClass: ['snack-info']
    })
  }
}