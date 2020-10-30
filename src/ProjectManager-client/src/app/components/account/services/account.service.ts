import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { User } from '../models/user.model';
import { environment } from 'src/environments/environment';
import { BaseService } from 'src/app/services/base.service';

@Injectable()
export class AccountService extends BaseService{
    constructor(private httpClient: HttpClient) { super(); }
    
    registerUser(user: User): Observable<any> {
        return this.httpClient
                    .post(environment.accountApiUrl + 'register', user, this.GetJsonHeader())
                    .pipe(
                        catchError(this.ServiceError));
    }

    login(user: User): Observable<any> {
        return this.httpClient
                        .post(environment.accountApiUrl + 'login', user, this.GetJsonHeader())
                        .pipe(
                            catchError(this.ServiceError));
    }
}