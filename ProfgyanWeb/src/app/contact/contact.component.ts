import { Component, OnInit, AfterViewInit, ElementRef, ViewChildren } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControlName } from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/fromEvent';
import 'rxjs/add/observable/merge';
import { GenericValidator } from '../../utils/validators/generic.validator';
import { contactMessages } from '../shared/GlobalVariable';
import { IContactInterface } from '../../api/interfaces/IContact.Interface';
import { ContactService } from '../../api/services/Contact.Service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
})

export class ContactComponent implements OnInit, AfterViewInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errorMessage: string;
  contactForm: FormGroup;
  contact: IContactInterface;

  // Use with the generic validation message class
  displayMessage: { [key: string]: string } = {};
  genericValidator: any;

  private readonly validationMessages = contactMessages

  constructor(private fb: FormBuilder, private contactService: ContactService) {
    // Define an instance of the validator for use with this form,
    // passing in this form's set of validation messages.
    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  ngOnInit() {
    this.contactForm = this.fb.group({
      Name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      Email: ['', [Validators.required, Validators.pattern('^[^\@]+@[^\@]+\.[^\@]{2,}$')]],
      Mobile: ['', [Validators.required, Validators.pattern('^[^\d@]{9,10}$')]],
      Subject: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(50)]],
      Message: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(200)]]
    });
  }

  ngAfterViewInit(): void {
    this.validationlogic();
  }

  //Custom validation initializatiton.
  private validationlogic() {
    // Watch for the blur event from any input element on the form.
    let controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => Observable.fromEvent(formControl.nativeElement, 'blur'));

    // Merge the blur event observable with the valueChanges observable
    Observable.merge(this.contactForm.valueChanges, ...controlBlurs).
    debounceTime(800).subscribe(value => {
      this.displayMessage = this.genericValidator.processMessages(this.contactForm);
    });
  }

  // Save contact details
  saveContact(): void {
    if (this.contactForm.dirty && this.contactForm.valid) {
      // Copy the form values over the contact object values
      let _contact = Object.assign({}, this.contact, this.contactForm.value);

      this.contactService.saveContact(_contact)
        .subscribe(
          () => this.onSaveComplete(),
          (error: any) => this.errorMessage = <any>error
        );
    } else if (!this.contactForm.dirty) {
      this.onSaveComplete();
    }
  }

  onSaveComplete(): void {
    // Reset the form to clear the flags
    this.contactForm.reset();
  }

}
