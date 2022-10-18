import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
export interface Tile {
  color: string;
  cols: number;
  rows: number;
  text: string;
  path: string;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  tiles: Tile[] = [
    {
      text: 'Oportunidades',
      cols: 3,
      rows: 1,
      color: 'lightblue',
      path: '/jobOffers',
    },
    { text: 'Mi Usuario', cols: 1, rows: 2, color: 'lightgreen', path: '' },
    { text: 'Favoritos', cols: 1, rows: 1, color: 'lightpink', path: '' },
    {
      text: 'Mis postulaciones',
      cols: 2,
      rows: 1,
      color: '#DDBDF1',
      path: '',
    },
  ];
}
