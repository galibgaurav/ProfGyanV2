import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../api/services/Login.Service';
import { loginModel } from '../../api/Models/Login.model';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { GlobalCons } from '../shared/GlobalVariable';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  username: string;
  password: string;

  constructor(private _loginService: LoginService, private _router: Router) { }

  ngOnInit() {
  }

  login(): void {
    console.log(this.username + ' ' + this.password);
    const obj = new loginModel();
    obj.username = this.username;
    obj.password = this.password;

    this._loginService.getLogin(obj).subscribe((data: any) => {

      localStorage.setItem('userToken', data.access_token);
      localStorage.setItem('profGyanUserRole', data.role);
      // After successful login take user to home/dashboard
      window.location.href = GlobalCons.backofficePageUrl + 'verification/' + data.access_token;
    },
      (err: HttpErrorResponse) => {
        // Route to the error page/loginpage/login Home page
        this._router.navigate([GlobalCons.homePageUrl]);
      }
    );

    this._loginService.testCall();
  }

}
