import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { IBasket } from '../models/basket.model';
import { BasketService } from './basket.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {
  basket: IBasket | undefined;
  constructor(private basketService: BasketService) {
    this.basketService.updateBasket().subscribe(x => {
      console.log('basket updated: ' + x);
    },
      errMessage => console.log(errMessage.messages));
  }

  ngOnInit() {
    this.loadBasket();
  }

  loadBasket() {
    this.getBasket();
  }

  getBasket() {
    this.basketService.getBasket()
      .pipe(catchError((err) => this.handleError(err)))
      .subscribe(basket => { this.basket = basket })
  }

  handleError(err: any): any {
    throw new Error('Method not implemented.');
  }


  update(event: any): Observable<boolean> {
    let setBasketObservable = this.basketService.updateBasket();
    setBasketObservable
      .subscribe((x) => {
          console.log('basket updated: ' + x);
        },
        errMessage => console.log(errMessage.messages));
    return setBasketObservable;
  }     
}
