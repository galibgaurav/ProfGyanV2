import { Component, OnInit } from '@angular/core';
import { LoginModel } from '../../api/Models/Login.model';
import { Router, ActivatedRoute, Route } from '@angular/router';
import { LoginService } from '../../api/Services/Login.Service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',

})
export class LoginComponent implements OnInit {

  username: string;
  password: string;
  isNavBar: boolean;
  redirectToken:string;
  showLoginForm:boolean=false;
  constructor(private _route:ActivatedRoute,private _loginService: LoginService, private _router: Router) { 

    this._route.queryParams.subscribe(params=>{
      debugger;
      this.redirectToken=params['_token'];
      this.username=params['_userName'];
      if((this.redirectToken!==undefined && this.redirectToken!==null)&&(this.username!==undefined && this.username!==null))
      {this.loginViaProfgyanOnline(this.redirectToken,this.username);
      console.log('Navigating from ProfgyanOnline to Profgyan Back office '+this.redirectToken);
      }
    }
    );
  }
  ngOnInit() {
    this.isNavBar = false;   
  }

  login(): void {
    console.log(this.username + ' ' + this.password);
    const obj = new LoginModel();
    obj.username = this.username;
    obj.password = this.password;

    this._loginService.getLogin(obj).subscribe((data: any) => {
      localStorage.setItem('userToken', data.access_token);
      localStorage.setItem('profGyanUserRole', data.role);
      console.log(data.access_token);
      this._router.navigate(['/process']);
    },
      (err: HttpErrorResponse) => {
      }
    );

  }

  loginViaProfgyanOnline(_token:string,_userName:string):void
  {
    localStorage.setItem('userToken', _token);

    this._loginService.getUserRole(_token,_userName).subscribe((data: any) => {
      localStorage.setItem('profGyanUserRole', data.Name);
      console.log(data.access_token);
      this._router.navigate(['/process']);
    },
      (err: HttpErrorResponse) => {
      }
    );
  }
  logout():void{
    debugger;
    console.log('userLog');
  }
}
