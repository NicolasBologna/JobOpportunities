import { Component, OnInit } from '@angular/core';
import { LessonsService } from '../common/services/lessons.service';

@Component({
  selector: 'app-knowledge',
  templateUrl: './knowledge.component.html',
  styleUrls: ['./knowledge.component.scss'],
})
export class KnowledgeComponent implements OnInit {
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
