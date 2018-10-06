import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { GlobalCons,GlobalStatic } from '../../app/shared/GlobalVariable';


@Injectable()
export class TrainerService {

  constructor(private _http: HttpClient) { }

  addTrainer(data: string): Observable<any> {
    const reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this._http.post(GlobalCons.trainerUrl, data, { headers: reqHeader });
  }
  addTrainerPersonalData(_tokken:string,data: string): Observable<any> {
    debugger;
    const header=new HttpHeaders({'Authorization':'Bearer '+_tokken,'Content-Type': 'application/json'});
    return this._http.post(GlobalStatic.prefixUrl+'/api/Trainers/AddTrainerPersonalDetail', data, { headers: header });
  }
  addTrainerProfessionalData(_token:string,data: string): Observable<any> {
    debugger;
    const header=new HttpHeaders({'Authorization':'Bearer '+_token,'Content-Type': 'application/json'});
    return this._http.post(GlobalStatic.prefixUrl+'/api/Trainers/AddTrainerProfessonalDetail',data, { headers: header });
  }
  createUserApplicationform(_tokken:string,data:string):Observable<any>{
    const Header=new HttpHeaders({'Authorization':'Bearer '+_tokken});
    return this._http.post(GlobalCons.trainerUrl,data,{ headers: Header});
}
  getUserPersonalInfo(_tokken: string): Observable<any> {
    const Header = new HttpHeaders({ 'Authorization': 'Bearer ' + _tokken });
    return this._http.get(GlobalStatic.prefixUrl+'/api/Trainers/TrainerDetail', { headers: Header});
  }
  getUserProfessionInfo(_tokken: string): Observable<any> {
    const Header = new HttpHeaders({ 'Authorization': 'Bearer ' + _tokken });
    return this._http.get(GlobalStatic.prefixUrl+'/api/Trainers/TrainerDetail', { headers: Header});
  }
}
