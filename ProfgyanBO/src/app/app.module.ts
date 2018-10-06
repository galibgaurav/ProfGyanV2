import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { StudentprofileComponent } from './studentprofile/studentprofile.component';
import { BonavbarComponent } from './bonavbar/bonavbar.component';
import { InstructorprofileComponent } from './instructorprofile/instructorprofile.component';
import { appRoutes } from './shared/Approutes';
import { ProcessComponent } from './process/process.component';

import { TrainerService } from '../api/Services/trainer.service';
import { LoginService } from '../api/Services/Login.Service';
import {FileUploadService} from '../api/Services/file-upload.service';
import { VerificationComponent } from './verification/verification.component';
import { LoginGaurdService } from '../api/Services/LoginGaurd.Service';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    StudentprofileComponent,
    BonavbarComponent,
    InstructorprofileComponent,
    ProcessComponent,
    VerificationComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes, { enableTracing: true }),
    CommonModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(), // ToastrModule added https://www.npmjs.com/package/ngx-toastr
    ],
  providers: [TrainerService, LoginService, LoginGaurdService,FileUploadService],
  bootstrap: [AppComponent]
})
export class AppModule { }
