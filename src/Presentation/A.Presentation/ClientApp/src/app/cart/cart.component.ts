import { Component, Input, OnInit } from '@angular/core';
import { catchError, Subscription, throwError } from 'rxjs';
import { IBasket } from '../models/basket.model';
import { BasketService } from '../basket/basket.service';

@Component({
  selector: 'cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  badgevisible: boolean = false;
  addBasketItem: Subscription | undefined;
  public itemCount: number = 0;
  errorReceived: boolean | undefined;

  constructor(private basketService: BasketService) {

  }

  ngOnInit(): void {
    this.itemCount = this.basketService.totalBasketItems;
    this.addBasketItem = this.basketService.addBasketItem.subscribe(item => {
      this.errorReceived = false;
      this.itemCount = this.basketService.addBasketItems(item);
      //this.basketService.updateBasket()
      //  .pipe(catchError((err) => this.handleError(err)))
      //  .subscribe((result: any) => {
      //    console.log(result);
      //  });
    });
  }

  handleError(error: any): any {
    this.errorReceived = true;
    return throwError(() => error);
  }
}
