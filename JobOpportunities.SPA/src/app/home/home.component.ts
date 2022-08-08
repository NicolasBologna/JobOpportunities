import { Component, OnInit } from '@angular/core';
import { LessonsService } from '../common/services/lessons.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  jobOfferLessons$;
  jobOfferLessons = [];

  selectedLesson: any;

  constructor(private lessonsService: LessonsService) {}

  ngOnInit() {
    this.jobOfferLessons = this.lessonsService.lessons;
    this.jobOfferLessons$ = Array.of(this.lessonsService.lessons$);
  }

  selectLesson(lesson) {
    this.selectedLesson = lesson;
  }

  deleteLesson(lesson) {}
}
