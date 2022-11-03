import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.scss'],
})
export class NotFoundComponent implements OnInit {
  notFoundText: string = `El recurso al que intenta acceder no se encuentra!`;

  constructor() {}

  ngOnInit(): void {}
}
