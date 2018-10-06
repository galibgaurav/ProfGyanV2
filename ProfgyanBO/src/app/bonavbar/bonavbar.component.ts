import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../api/Services/Login.Service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-bonavbar',
  templateUrl: './bonavbar.component.html'
})
export class BonavbarComponent implements OnInit {
 profileEdit:boolean;
  constructor(private _loginService: LoginService) { }

  ngOnInit() {
    this.profileEdit=true;
  }
  logout():void{
    debugger;
    const token=localStorage.getItem("userToken");
    this._loginService.logoutUser(token).subscribe((data: any) => {
      localStorage.removeItem("userToken");
      localStorage.removeItem("profGyan");
      window.location.href = data;
     
    },
      (err: HttpErrorResponse) => {
        localStorage.removeItem("userToken");
        localStorage.removeItem("profGyan");
        console.log(err);
      }
    );

   
  }
}
