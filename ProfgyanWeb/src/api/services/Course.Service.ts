import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ICourseInterface } from '../interfaces/ICourse.Interface';
import { GlobalCons } from '../../app/shared/GlobalVariable';

@Injectable()
export class CourseService {

    constructor(private _http: HttpClient) {
    }

    // Get all the course without Token
    getCourse(): Observable<any> {
        return this._http.get<ICourseInterface>(GlobalCons.getCourse.toString());
    }

    testCall(): void {
        console.log('Hello');
    }

}
