import { Routes } from '@angular/router';
import { HomeComponent } from '../home/home.component';
import { AboutComponent } from '../about/about.component';
import { ContactComponent } from '../contact/contact.component';
import { CoursedetailComponent } from '../coursedetail/coursedetail.component';
import { FaqComponent } from '../faq/faq.component';
import { TcComponent } from '../tc/tc.component';


export const appRoutes: Routes =
    [
        { path: 'home', component: HomeComponent },
        { path: '', redirectTo: 'home', pathMatch: 'full' },
        { path: 'about', component: AboutComponent },
        { path: 'contact', component: ContactComponent },
        { path: 'coursedetail', component: CoursedetailComponent },
        { path: 'faq', component: FaqComponent },
        { path: 'tc', component: TcComponent }
    ];
