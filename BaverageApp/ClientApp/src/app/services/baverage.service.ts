import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Observable, Subject} from 'rxjs';
import {map} from 'rxjs/operators';

import {Order} from '../model/Order';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BaverageService {

  apiURL = 'BaverageService.svc';

  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  getDrinks(): Observable<string[]> {
    return this.http.get<string[]>(`${environment.apiUrl}/${this.apiURL}/GetDrinks`);   
  } 
  addOrder(order: Order,user:string): Observable<Order> {
    return this.http.post<Order>(`${environment.apiUrl}/${this.apiURL}/PrepareDrink/${user}`,JSON.stringify(order), this.httpOptions); 
  }
  getLastOrder(username:string):Observable<Order>
  {
    var subject = new Subject<Order>();
    this.http.get<Order>(`${environment.apiUrl}/${this.apiURL}/GetLastSelectedDrink/${username}`).subscribe((order:Order)=>{
      subject.next(order);
   }); 
    return subject.asObservable();
  }
}
