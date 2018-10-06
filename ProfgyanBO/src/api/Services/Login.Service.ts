import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { GlobalCons, GlobalStatic } from '../../app/shared/GlobalVariable';
import { LoginModel } from '../Models/Login.model';

@Injectable()
export class LoginService {

    private loginUrl = GlobalCons.loginUrl;
    private claimUrl = GlobalCons.getClaimUrl;

    constructor(private _http: HttpClient) {
    }

    getLogin(_loginModel: LoginModel): Observable<any> {
        const data = 'username=' + _loginModel.username + '&password=' + _loginModel.password + '&grant_type=password';
        const reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded' });
        return this._http.post(this.loginUrl, data, { headers: reqHeader });
    }

    getClaim(_tokken: string): Observable<any> {
        console.log(this.claimUrl);
        const Header = new HttpHeaders({ 'Authorization': 'Bearer ' + _tokken });
        return this._http.get(this.claimUrl, { headers: Header});
    }

    getUserInfo(_tokken: string): Observable<any> {
        const Header = new HttpHeaders({ 'Authorization': 'Bearer ' + _tokken });
        return this._http.get(GlobalStatic.prefixUrl+'/api/GetLoggedInUserInfo', { headers: Header});
    }

    getUserRole(_tokken: string,_username:string): Observable<any> {
        const Header = new HttpHeaders({ 'Authorization': 'Bearer ' + _tokken });
        return this._http.get(GlobalStatic.prefixUrl+'/api/GetRole/'+_username, { headers: Header});
    }
    
    logoutUser(_token:string):Observable<any>{
        const Header = new HttpHeaders({ 'Authorization': 'Bearer ' + _token });
        return this._http.get(GlobalStatic.prefixUrl+'/api/logout', { headers: Header});
    }

    testCall(): void {
        console.log('Hello');
    }
}
