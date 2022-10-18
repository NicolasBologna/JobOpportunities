import { NumberInput } from '@angular/cdk/coercion';
import { Component, OnInit } from '@angular/core';

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
  public breakpoint: NumberInput = 1;
  private smallWindow = (): boolean => {
    return window.innerWidth <= 700;
  };

  private opportunitiesColumns = this.smallWindow() ? 1 : 3;
  private myRequests = this.smallWindow() ? 1 : 2;

  tiles: Tile[] = [
    {
      text: 'Oportunidades',
      cols: this.opportunitiesColumns,
      rows: 1,
      color: '#256D85',
      path: '/jobOffers',
    },
    { text: 'Mi Usuario', cols: 1, rows: 2, color: '#47B5FF', path: '' },
    { text: 'Favoritos', cols: 1, rows: 1, color: 'lightpink', path: '' },
    {
      text: 'Mis postulaciones',
      cols: this.myRequests,
      rows: 1,
      color: '#DDBDF1',
      path: '',
    },
  ];

  ngOnInit() {
    this.breakpoint = this.smallWindow() ? 1 : 4;
  }

  onResize(event) {
    this.tiles[0].cols = this.smallWindow() ? 1 : 3;
    this.tiles[3].cols = this.smallWindow() ? 1 : 2;
    this.breakpoint = this.smallWindow() ? 1 : 4;
    console.log(this.opportunitiesColumns);
  }
}
