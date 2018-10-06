import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { Http, RequestOptions, Headers, Response } from "@angular/http";
import { ISignupComponent } from "../interfaces/ISignup.component";
import { GlobalCons } from "../../app/shared/GlobalVariable";
import "rxjs/add/operator/catch";
import "rxjs/add/operator/do";
import "rxjs/add/operator/map";
import "rxjs/add/observable/throw";
import "rxjs/add/observable/of";

@Injectable()
export class SignupService {
  _ISignupComponent: ISignupComponent;

  constructor(private http: Http) {}

  saveSignup(Isignup: ISignupComponent): Observable<ISignupComponent> {
    debugger;
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });

    return this.createSignup(Isignup, options);
  }

  private createSignup(Isignup: ISignupComponent, options: RequestOptions) {
    debugger;
    return this.http
      .post(GlobalCons.registerUrl, Isignup)
      .map(this.serverResponse)
      .do(data => console.log("Registered Sucessfully.."))
      .catch(this.handleError);
  }

  private serverResponse(response: Response) {
    let body = response.json();
    return body.data || {};
  }

  private handleError(error: Response): Observable<any> {
    console.log(error);
    return Observable.throw(error.json().error || "Server Error");
  }

  initializeSignUpForm(): ISignupComponent {
    return {
      username: null,
      password: null,
      ConfirmPassword: null,
      firstname: null,
      lastname: null,
      email: null,
      roles: [''],
      PhoneNumber:null
    };
  }
}
