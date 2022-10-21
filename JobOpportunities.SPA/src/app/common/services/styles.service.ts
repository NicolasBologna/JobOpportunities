import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class StylesService {
  constructor() {}
  private darkModeChangeSub = new Subject<string>();
  public darkModeChanged = this.darkModeChangeSub.asObservable();

  public sendDarkModeChangeNotification = (isDarkMode: string) => {
    this.darkModeChangeSub.next(isDarkMode);
  };
}
