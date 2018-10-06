import { Component, OnInit } from '@angular/core';
import { GlobalCons, GlobalStatic } from '../shared/GlobalVariable';
import { CoursesComponent } from '../courses/courses.component';
import { ICourseInterface } from '../../api/interfaces/ICourse.Interface';
import { CourseService } from '../../api/services/Course.Service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html'
})
export class NavbarComponent implements OnInit {

  allCourse: ICourseInterface[];
  preFix = GlobalCons.imagePath;

  constructor(private _courseService: CourseService) { }

  ngOnInit() {
    this.getCourse();
  }

  getCourse(): void {
    this._courseService.getCourse().subscribe((data: ICourseInterface[]) => {
      this.allCourse = data;
    });
  }

}
