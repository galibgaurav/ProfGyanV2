import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from '../../api/Services/Login.Service';

@Component({
  selector: 'app-verification',
  templateUrl: './verification.component.html'
})
export class VerificationComponent implements OnInit {

  id: string;
  
  constructor(private _actroute: ActivatedRoute, private _router: Router, private _login: LoginService) { }

  ngOnInit() {
    debugger;
      // get param
      this.id = this._actroute.snapshot.params.id;
      console.log(this.id);
      localStorage.setItem('userToken', this.id);
      this._login.getClaim(this.id).subscribe(data =>{
      
        (data != null ? this._router.navigate(['/login'],{ queryParams: { _token: localStorage.getItem('userToken'),_userName:data.UserName} }) : '')}
      );
  }

}
