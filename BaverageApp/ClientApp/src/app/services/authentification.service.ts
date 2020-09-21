import { HttpClient, HttpParams,HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import {Client} from '../model/Client';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  apiURL = 'ConnexionService.svc';
  constructor(private http: HttpClient) {
  }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  public get currentUserValue() {
      return localStorage.getItem('currentUser');
  }

  login(client:Client):Observable<boolean>{
      var subject = new Subject<boolean>();
     this.http.post<boolean>(`${environment.apiUrl}/${this.apiURL}/CheckValidConnection`, JSON.stringify(client),this.httpOptions)
      .subscribe((result:boolean) => {
        if (result)
        {
          subject.next(true);
          localStorage.setItem('currentUser', client.username);
        }
        else
        {
          subject.next(false);
        }
    });
    return subject.asObservable();
  }
  signup(client:Client) {
      return this.http.post(`${environment.apiUrl}/${this.apiURL}/RegisterClient`, JSON.stringify(client), this.httpOptions)
          .pipe(map(result => {
              if (result)
              {
                localStorage.setItem('currentUser', client.username);
              }
          }));
  }
  existingMail(value:string, field: string): Observable<boolean>
  {
    return this.http.get<boolean>(`${environment.apiUrl}/${this.apiURL}/CheckExistingData/${field.toUpperCase()}=${value}`);
  }
  logout() {
      // remove user from local storage to log user out
      localStorage.removeItem('currentUser');
  }
}
