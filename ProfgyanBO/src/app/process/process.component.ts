import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl, ValidatorFn, FormArray } from '@angular/forms';
import 'rxjs/add/operator/debounce';
import { Instructor } from '../instructorprofile/instructor';
import { HttpErrorResponse } from '@angular/common/http';
import { TrainerService } from '../../api/Services/trainer.service';
import {FileUploadService} from '../../api/Services/file-upload.service';
import { GlobalCons } from '../shared/GlobalVariable';
import { ToastrService } from 'ngx-toastr';
import {LoginService} from '../../api/Services/Login.Service';
import { state } from '@angular/animations';
import { DatePipe } from '@angular/common';
import { pipe } from 'rxjs';

@Component({
  selector: 'app-process',
  templateUrl: './process.component.html'
})

export class ProcessComponent implements OnInit {
  
  trainerForm: FormGroup;
  trainerEduForm: FormGroup;
  trainerDocForm: FormGroup;
  IsProfileEdit:boolean;
  avatar: string;
  instructor: Instructor = new Instructor();
  isNavBar: boolean;
  //datePipe:DatePipe;

  private validationMessages = {
    required: 'Please enter your email address.',
    pattern: 'Please enter a valid email address.'
  };

  constructor(private fb: FormBuilder,
     private trainerService: TrainerService,
     private fileUploadService:FileUploadService,
     private toastr: ToastrService,
     private login: LoginService
    ) {
    this.createTrainerForm();
    this.createDocForm();
    this.createEduForm();
    }

  createTrainerForm() {
    this.trainerForm = this.fb.group({
      firstName: ['', [Validators.required, Validators.maxLength(50), Validators.minLength(3)]],
      lastName: ['', [Validators.required, Validators.maxLength(50), Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.pattern('[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+')]],
      phone: ['', [Validators.required, Validators.maxLength(11), Validators.minLength(10)]],
      dob: ['', [Validators.required]],
      address: ['', [Validators.required,Validators.maxLength(200)]],
      state: ['', [Validators.required,Validators.maxLength(50)]],
      City: ['', [Validators.required,Validators.maxLength(50)]],
      PINCode: ['', [Validators.required,Validators.maxLength(10)]]
     });
  }
  createEduForm()
  {
    this.trainerEduForm=this.fb.group(
      {
        highestQualification: ['B.tech', Validators.maxLength(30)],
        department: ['', [Validators.required, Validators.maxLength(30)]],
        academicYear: ['', []],
        industrialExp: ['No Experience', []],
        // companies: ['', [Validators.maxLength(100)]],
         teachingExp: ['No Experience', []],
         skillSet: ['', [Validators.maxLength(300)]],
         socialMediaLink: ['', [Validators.maxLength(300)]],
        });
  
  }
  createDocForm()
  {
    this.trainerDocForm=this.fb.group(
      {
        resume:[null,[Validators.required]],
        avatar:[null,[Validators.required]]
      });
  }
  
  ngOnInit(): void {
    this.isNavBar = false;
    this.IsProfileEdit=false;

    //Initialize user application form 
    this.IntializeUserApplicationForm();
    
    // TO DO : Need to add logic to check login
    // console.log(GlobalCons.getToken);
  }
  
  IntializeUserApplicationForm(){
    let sessionToken=localStorage.getItem('userToken');
    if(sessionToken!=undefined)
    {
      
      this.login.getUserInfo(sessionToken).subscribe(
        (data: any) => {
          debugger;
          const datePipe=new DatePipe('en-US');
          this.trainerForm.setValue({
            firstName:data.FirstName,
            lastName:data.LastName,
            email:data.Email,
            phone:data.PhoneNumber,
            dob:data.trainerDTO!=null? (data.trainerDTO.dob!=null?datePipe.transform(data.trainerDTO.dob,'MM/dd/yyyy'):''):'',
            address:data.trainerDTO!=null? (data.trainerDTO.address!=null?data.trainerDTO.address:''):'',
            state:data.trainerDTO!=null? (data.trainerDTO.state!=null?data.trainerDTO.state:''):'',
            City:data.trainerDTO!=null? (data.trainerDTO.City!=null?data.trainerDTO.City:''):'',
            PINCode:data.trainerDTO!=null? (data.trainerDTO.PINCode!=null?data.trainerDTO.PINCode:''):''
          });

          this.trainerEduForm.setValue(
            {
              highestQualification: data.trainerDTO!=null? (data.trainerDTO.highestQualification!=null?data.trainerDTO.highestQualification:''):'',
              department: data.trainerDTO!=null? (data.trainerDTO.department!=null?data.trainerDTO.department:''):'',
              academicYear: data.trainerDTO!=null? (data.trainerDTO.academicYear!=null?data.trainerDTO.academicYear:''):'',
              industrialExp:  data.trainerDTO!=null? (data.trainerDTO.industrialExp!=null?data.trainerDTO.industrialExp:''):'',
              // companies: ['', [Validators.maxLength(100)]],
              teachingExp: data.trainerDTO!=null? (data.trainerDTO.teachingExp!=null?data.trainerDTO.teachingExp:''):'',
              skillSet: data.trainerDTO!=null? (data.trainerDTO.skillSet!=null?data.trainerDTO.skillSet:''):'',
              socialMediaLink: data.trainerDTO!=null? (data.trainerDTO.socialMediaLink!=null?data.trainerDTO.socialMediaLink:''):''
            });

         },
           (err: HttpErrorResponse) => {
             this.toastr.error('Error while reading user SignUp Information', 'User Information');
           },
           ()=>{

              // this.trainerService.getUserPersonalInfo(sessionToken).subscribe(
              //   (data: any) => {
              //     debugger;
              //     this.trainerForm.setValue({
              //       dob:data.dob,
              //       address:data.address,
              //       state:data.state,
              //       City:data.City,
              //       PINCode:data.PINCode
              //     });  
              //    },
              //      (err: HttpErrorResponse) => {
              //        this.toastr.error('Error while reading user personal information', 'User Information');
              //      }
              // );
           }
      );

    }
  }

  
  SavePersonalData(): void {
    debugger;
   
    this.trainerService.addTrainerPersonalData(localStorage.getItem('userToken'),JSON.stringify(this.trainerForm.value))
      .subscribe((data: any) => {
       this.toastr.success('Personal information saved successfully', 'Application Form');

      },
        (err: HttpErrorResponse) => {
          this.toastr.error('Personal information failed to save', 'Application Form');
        }
      );
  }

  saveEdu(): void {
    this.trainerService.addTrainerProfessionalData(localStorage.getItem('userToken'),JSON.stringify(this.trainerEduForm.value))
      .subscribe((data: any) => {
       this.toastr.success('Professional information saved successfully', 'Application Form');

      },
        (err: HttpErrorResponse) => {
          this.toastr.error('professional information failed to save', 'Application Form');
        }

      );
  }

  // savedoc(): void {
  //   this.trainerService.addTrainer(JSON.stringify(this.trainerForm.value))
  //     .subscribe((data: any) => {
  //      this.toastr.success('Application form submitted successfully', 'Application Form');

  //     },
  //       (err: HttpErrorResponse) => {
  //         this.toastr.error('Application form not submitted', 'Application Form');
  //       }

  //     );
  // }
  

  onResumeFileChange(event) {
    var reader = new FileReader();
    if(event.target.files && event.target.files.length) {
      var file = event.target.files[0];
      var fileType=file.type;
      var fileSize=file.size;
      if(GlobalCons.documentFileType.indexOf(fileType)>-1)
      {
        if(fileSize<=GlobalCons.maxDocumentSize)
        {
          reader.readAsDataURL(file); 

          reader.onload = () => {
             var formData=new FormData();
             formData.append('uploadFile',file,file.name);
             
             let apiUrl = "http://localhost/webapi/api/Documents";
             this.fileUploadService.UploadFiles(null,apiUrl,formData).subscribe
             ({
               next : value=> {
                 console.log(value)
                this.toastr.success('Resume '+value.FileName+ ' Uploaded Successfully');
              },
               error : err=> {
                this.trainerForm.setValue({resume:null});
                if(err.error!=null)
                this.toastr.error(err.error.ExceptionMessage,err.error.ExceptionType);
                else
                this.toastr.error('Error!');
               }
             
               ,
               complete: ()=>{
                 console.log('Resume uploaded')
                }
             });
          };
        }
        else{
          this.toastr.error('Please choose resume of file size lesser than 1 MB','File Size Error');
        }
        
      }
      else{
          this.toastr.error('Please choose resume of file type PDF or Microsoft word','File Type Error');
      }
   }
  }


  onAvatarFileChange(event) {
    var reader = new FileReader();
    if(event.target.files && event.target.files.length) {
      var file = event.target.files[0];
      var fileType=file.type;
      var fileSize=file.size;
      if(GlobalCons.imageFileType.indexOf(fileType)>-1)
      {
        if(fileSize<=GlobalCons.maxDocumentSize)
        {
          reader.readAsDataURL(file); 
          reader.onload = () => {
             var formData=new FormData();
             formData.append('uploadFile',file,file.name);
             let apiUrl = "http://localhost/webapi/api/Documents";
             this.fileUploadService.UploadFiles(null,apiUrl,formData).subscribe
             ({
               next : value=>{console.log(value)
                this.toastr.success('Avatar '+value.FileName+ ' Uploaded Successfully');
              },
               error : err=> 
                {
                  this.trainerForm.setValue({avatar:null});
                  if(err.error!=null)
                  this.toastr.error(err.error.ExceptionMessage,err.error.ExceptionType);
                  else
                  this.toastr.error('Error!');
                }
               ,
               complete: ()=> console.log('avatar uploaded')
             });
   
          };
        }
        else{
          this.toastr.error('Please choose avatar of file size lesser than 1 MB','File Size Error');
        }

     
      }
      else{
        this.toastr.error('Please choose avatar of file type JPEG/JPG or PNG','File Type Error');
      }
      
   }
  }
  clearFile() {
    this.trainerForm.get('avatar').setValue(null);
    // this.fileInput.nativeElement.value = '';
  }
  formReset()
  {
    this.trainerForm.setValue(null);
  }
}
