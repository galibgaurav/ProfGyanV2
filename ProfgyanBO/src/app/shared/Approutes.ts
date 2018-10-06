import { Routes } from '@angular/router';
import { LoginComponent } from '../login/login.component';
import { ProcessComponent } from '../process/process.component';
import { VerificationComponent } from '../verification/verification.component';
import { LoginGaurdService } from '../../api/Services/LoginGaurd.Service';


export const appRoutes: Routes =
    [
        { path: 'login', component: LoginComponent },
        { path: '', redirectTo: 'login', pathMatch: 'full' },
        {
            path: 'process',
            canActivate: [LoginGaurdService],
            component: ProcessComponent
        },
        { path: 'verification/:id', component: VerificationComponent }
    ];
