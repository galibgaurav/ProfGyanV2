import { Component, OnInit } from '@angular/core';
import { CourseService } from '../../api/services/Course.Service';
import { ICourseInterface } from '../../api/interfaces/ICourse.Interface';
import { GlobalCons } from '../shared/GlobalVariable';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html'
})
export class CoursesComponent implements OnInit {


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
