import { Component } from '@angular/core';
import { LoginService } from '../api/services/Login.Service';
import { SignupService } from '../api/services/Singup.Service';
import { CourseService } from '../api/services/Course.Service';
import { ContactService } from '../api/services/Contact.Service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  providers: [LoginService, SignupService, CourseService, ContactService]
})
export class AppComponent {
  title = 'Profgyan';
}
