import { Component } from '@angular/core';
import {BaverageService} from '../services/baverage.service';
import {Observable} from 'rxjs';
import {Order} from '../model/Order';
import { Router } from '@angular/router';
import{ map} from 'rxjs/operators';
import { AuthenticationService } from '../services/authentification.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  private model: Order;
  private tests:any []=['test1','test2'];
  private drinks$: Observable<string[]>;
  private exist:boolean=false;
  title:string ='Baverage machine';
  successMessage:string ='';
    constructor (private bs: BaverageService,private authentification:AuthenticationService,private router: Router)
    {
      this.drinks$ = this.bs.getDrinks();
      this.model = new Order();
      this.getLastOrder(this.authentification.currentUserValue);
    }
     submit()
     {   
        this.bs.addOrder(this.model,this.authentification.currentUserValue).subscribe((result:any)=>{
          this.successMessage = "Your order have been registred for next time.."
          this.model = new Order();
        });
     }
     logout()
     {
      this.authentification.logout();
      this.router.navigate(['/login']);
     }
     getLastOrder(username:string)
     {
       this.bs.getLastOrder(username).subscribe((order:Order)=>{
          if(order!==null)
          {
            this.model = order;
            this.exist = true;
          }
       });
     }
}
