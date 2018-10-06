import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, ActivatedRoute, Router } from '@angular/router';
import { GlobalCons } from '../../app/shared/GlobalVariable';

@Injectable()
export class LoginGaurdService implements CanActivate {
    constructor(private _route: Router) {}

    canActivate(route: ActivatedRouteSnapshot): boolean {
        if (localStorage.getItem('userToken') == null) {
            this._route.navigate(['/login']);
            return false;
        }

        // TO DO : After LogOut Clear the Token

        console.log(localStorage.getItem('userToken'));
        return true;
    }
}
