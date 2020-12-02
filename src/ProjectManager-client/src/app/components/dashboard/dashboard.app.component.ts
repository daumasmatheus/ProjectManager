import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';

import { LocalStorageUtils } from 'src/app/helpers/localstorage';
import { MessageType } from 'src/app/helpers/message-type.enum';
import { SnackBarHelper } from 'src/app/helpers/snack-bar.helper';
import { ProfileComponent } from './profile/profile.component';

@Component({
    selector: 'app-dashbord',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit { 

    constructor (private snackHelper: SnackBarHelper,
                 private router: Router,
                 private dialog: MatDialog) {}    

    private localStorageUtils = new LocalStorageUtils();

    userName: string;        

    ngOnInit(): void {
        var loggedUser = this.localStorageUtils.getUser();
        this.userName = `${loggedUser.firstName} ${loggedUser.lastName}`;        
    }

    logout() {
        this.localStorageUtils.clearLocalUserData();

        this.snackHelper.showSnackbar("Efetuando logout", MessageType.OkMessage, 3000);
        setTimeout(() => {
            this.router.navigate(['/account/login']);
        }, 3000);
    }

    openProfileDialog() {
        this.dialog.open(ProfileComponent, {
            hasBackdrop: true,        
            panelClass: 'full-width-dialog',
            height: '490px',
            data: { 
                userName: this.userName,                
            }
        });
    }
}