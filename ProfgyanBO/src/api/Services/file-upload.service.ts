import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';



@Injectable()
export class FileUploadService {

  constructor(private httpClient:HttpClient) { }

  UploadFiles(reqheader:HttpHeaders,Url:string,formData:FormData):Observable<any>
  {
    reqheader = new HttpHeaders({ 'Authorization': 'Bearer  '+localStorage.getItem('userToken') });
    //reqheader.append("Authorization","Bearer  "+localStorage.getItem('userToken'));
    return this.httpClient.post(Url, formData, { headers: reqheader })  
       .map((res:Response) => res)  
       .catch(error => Observable.throw(error))  
  }
}
