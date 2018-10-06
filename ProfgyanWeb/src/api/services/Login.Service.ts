import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { loginModel } from '../../api/Models/Login.model';
import { GlobalCons } from '../../app/shared/GlobalVariable';

@Injectable()
export class LoginService {

    private loginUrl = GlobalCons.loginUrl;

    constructor(private _http: HttpClient) {
    }

    getLogin(_loginModel: loginModel): Observable<any> {
        const data = 'username=' + _loginModel.username + '&password=' + _loginModel.password + '&grant_type=password';
        const reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded' });
        return this._http.post(this.loginUrl, data, { headers: reqHeader });
    }

    testCall(): void {
        console.log('Hello');
    }
}
