import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LocalStorageUtils } from 'src/app/helpers/localstorage';
import { MessageType } from 'src/app/helpers/message-type.enum';
import { SnackBarHelper } from 'src/app/helpers/snack-bar.helper';

@Component({
    selector: 'app-dashbord',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent { 
    constructor (private snackHelper: SnackBarHelper,
                 private router: Router) {}

    private localStorageUtils = new LocalStorageUtils();

    logout() {
        this.localStorageUtils.clearLocalUserData();

        this.snackHelper.showSnackbar("Efetuando logout", MessageType.OkMessage, 3000);
        setTimeout(() => {
            this.router.navigate(['/account/login']);
        }, 3000);
    }

}