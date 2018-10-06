import {
  Component,
  OnInit,
  AfterViewInit,
  ViewChildren,
  ElementRef
} from "@angular/core";
import { SignupService } from "../../api/services/Singup.Service";
import { signupModel } from "../../api/Models/signup.model";
import {
  FormGroup,
  FormBuilder,
  FormControl,
  FormControlName,
  Validators,
  AbstractControl,
  Validator
} from "@angular/forms";
import { ISignupComponent } from "../../api/interfaces/ISignup.component";
import { signupMessages } from "../shared/GlobalVariable";
import { GenericValidator } from "../../utils/validators/generic.validator";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/debounceTime";
import "rxjs/add/operator/map";
import "rxjs/add/observable/merge";

@Component({
  selector: "app-signup",
  templateUrl: "./signup.component.html"
})
export class SignupComponent implements OnInit, AfterViewInit {
  @ViewChildren(FormControlName, { read: ElementRef })
  formInputElements: ElementRef[];

  public _signupModel = new signupModel();

  signupForm: FormGroup;
  isignup: ISignupComponent;
  errorMessage: string;
  passwordMessage: string;

  displayMessage: { [key: string]: string } = {};
  genericValidator: any;

  private readonly validationMessages = signupMessages;

  constructor(private signupservice: SignupService, private fb: FormBuilder) {
    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  ngOnInit() {
    this.signupForm = this.fb.group(
      {
        FirstName: ["", [Validators.required]],
        LastName: ["", [Validators.required]],
        UserName: [
          "",
          [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(10)
          ]
        ],
        Password: ["", [Validators.required, Validators.minLength(6)]],
        ConfirmPassword: ["", [Validators.required, Validators.minLength(6)]],
        Email: [
          "",
          [Validators.required, Validators.pattern("^[^@]+@[^@]+.[^@]{2,}$")]
        ],
        PhoneNumber: [
          "",
          [Validators.required, Validators.pattern("^[^d@]{9,10}$")]
        ],
        Become: ["Trainee"]
      }
    );

    // const confirmpasswordControl = this.signupForm.get("ConfirmPassword");
    // confirmpasswordControl.valueChanges
    //   .debounceTime(1000)
    //   .subscribe(value => this.passwordMatcher(confirmpasswordControl));
  }


  private validationLogic() {
    let controlBlur: Observable<any>[] = this.formInputElements.map(
      (formControl: ElementRef) =>
        Observable.fromEvent(formControl.nativeElement, "blur")
    );

    Observable.merge(this.signupForm.valueChanges, ...controlBlur)
      .debounceTime(1000)
      .subscribe(value => {
        this.displayMessage = this.genericValidator.processMessages(
          this.signupForm
        );
      });
  }

  ngAfterViewInit(): void {
    this.validationLogic();
  }

  saveSignUp(): void {
    console.log("Hello");
    if (this.signupForm.dirty && this.signupForm.valid) {
     let objSignUp = Object.assign({}, this.isignup, this.signupForm.value);

      this.signupservice
        .saveSignup(this.fillData(objSignUp))
        .subscribe(
          () => this.onSaveComplete(),
          (error: any) => (this.errorMessage = <any>error)
        );
    } else if (!this.signupForm.dirty) {
      this.onSaveComplete();
    }
  }

  onSaveComplete(): void {
    this.signupForm.reset();
  }

  fillData(data: any) : ISignupComponent{

    return {
      username: data.UserName,
      password: data.Password,
      ConfirmPassword: data.Password,
      firstname: data.FirstName,
      lastname: data.LastName,
      email: data.Email,
      roles: [data.Become],
      PhoneNumber:data.PhoneNumber
    };

  }

  passwordMatcher(c: AbstractControl): { [key: string]: boolean } | null {
    let passwordControl = c.get("Password");
    let confirmPasswordControl = c.get("ConfirmPassword");
    if (c.touched || c.dirty && c.errors) {
      if (passwordControl.value === confirmPasswordControl.value) {
        return null;
      }
      else{
        this.passwordMessage = Object.keys(c.errors)
        .map(key => this.displayMessage[key])
        .join("");
      }
    }
    return { match: true };
  }
}
