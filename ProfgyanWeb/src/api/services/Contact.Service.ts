import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/of';
import { IContactInterface } from '../interfaces/IContact.Interface';
import { GlobalCons } from '../../app/shared/GlobalVariable';


@Injectable()
export class ContactService {

    constructor(private http: Http){}

    saveContact(contact: IContactInterface): Observable<IContactInterface> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.createContact(contact, options);
    }

    private createContact(contact: IContactInterface, options: RequestOptions): Observable<IContactInterface> {

        return this.http.post(GlobalCons.postContact, contact, options)
            .map(this.extractData)
            .do(data => console.log('Contactus created' + JSON.stringify(data)))
            .catch(this.handleError)

    }

    private handleError(error: Response): Observable<any> {
        console.error(error);
        return Observable.throw(error.json().error || 'Server Error');
    }

    private extractData(response: Response) {
        let body = response.json();
        return body.data || {};
    }

    //initialize ContactForm
    initializeContactForm(): IContactInterface {

        return {
            ContactusId: 0,
            Name: null,
            Email: null,
            Mobile: null,
            Subject: null,
            Message: null
        }
    }
}