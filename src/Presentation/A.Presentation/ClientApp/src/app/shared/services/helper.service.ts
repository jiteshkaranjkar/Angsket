import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from "@angular/common/http";
import { Guid } from '../common/guid';
import { Observable, throwError } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class HelperService {
  public setHeaders(options: any, needId: boolean = false) {
    if (!needId) {
      options["headers"] = new HttpHeaders()
        //.append('authorization', 'Bearer ' + this.securityService.GetToken())
        .append('Content-Type', 'application/json')
        .append('x-requestid', Guid.newGuid());
    }
    //else if (this.securityService) {
    //  options["headers"] = new HttpHeaders();
    //    //.append('authorization', 'Bearer ' + this.securityService.GetToken());
    //}
  }

  public handleError(error: any) : Observable<any> {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('Client side network error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error('Backend - ' +
        `status: ${error.status}, ` +
        `statusText: ${error.statusText}, ` +
        `message: ${error.error.message}`);
    }

    // return an observable with a user-facing error message
    return throwError(error || 'server error');
  }


}
