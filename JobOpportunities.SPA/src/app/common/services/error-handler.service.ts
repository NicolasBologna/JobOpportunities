import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpRequest,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class ErrorHandlerService {
  public errorMessage: string = '';

  constructor(private router: Router, private toastr: ToastrService) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        let errorMessage = this.handleError(error);
        return throwError(() => new Error(errorMessage));
      })
    );
  }

  public handleError = (error: HttpErrorResponse): string => {
    console.log(error);
    if (error.status === 500) {
      return this.handle500Error(error);
    } else if (error.status === 404) {
      return this.handle404Error(error);
    } else if (error.status === 0) {
      return this.handle500Error(error);
    } else if (error.status === 400) {
      return this.handleBadRequest(error);
    } else if (error.status === 401) {
      return this.handleUnauthorized(error);
    } else if (error.status === 403) {
      return this.handle403Error(error);
    } else {
      return this.handleOtherError(error);
    }
  };
  private handle500Error = (error: HttpErrorResponse): string => {
    this.router.navigate(['/500']);
    return this.createErrorMessage(error);
  };
  private handle404Error = (error: HttpErrorResponse): string => {
    //this.router.navigate(['/404']);
    this.toastr.warning('asdasd');
    return this.createErrorMessage(error);
  };
  private handle403Error = (error: HttpErrorResponse) => {
    this.router.navigate(['/403'], {
      queryParams: { returnUrl: this.router.url },
    });
    return 'Forbidden';
  };

  private handleBadRequest = (error: HttpErrorResponse): string => {
    if (this.router.url === '/authentication/register') {
      let message = '';
      const values = Object.values(error.error.errors);
      values.map((m: string) => {
        message += m + '<br>';
      });
      return message.slice(0, -4);
    } else {
      return error.error ? error.error : error.message;
    }
  };

  private handleOtherError = (error: HttpErrorResponse): string => {
    return this.createErrorMessage(error); //TODO: this will be fixed later;
  };
  private createErrorMessage = (error: HttpErrorResponse): string => {
    return error.error ? error.error : error.statusText;
  };

  private handleUnauthorized = (error: HttpErrorResponse) => {
    if (this.router.url === '/authentication/login') {
      return 'Authentication failed. Wrong Username or Password';
    } else {
      this.router.navigate(['/authentication/login'], {
        queryParams: { returnUrl: this.router.url },
      });
      return error.message;
    }
  };
}
