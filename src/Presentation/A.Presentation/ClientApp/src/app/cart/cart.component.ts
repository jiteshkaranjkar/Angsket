import { Component, Input, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IBasket, IBasketItem } from '../models/basket.model';
import { BasketService } from '../services/basket.service';

@Component({
  selector: 'cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  badgevisible: boolean = false;
  addBasketItem: Subscription | undefined;
  public itemCount: number = 0;

  constructor(private basketService: BasketService) {

  }
  ngOnInit(): void {
    this.addBasketItem = this.basketService.addBasketItem.subscribe(item => {
      this.itemCount = 0;
      if (this.basketService.basket?.Items?.length === 0) {
        this.basketService.basketItems.push(item);
        this.basketService.basket?.Items?.
          filter(x => x.Product.id === item.Product.id).
          map(x => x.Product.basketQuantity == item.Product.basketQuantity);

      }
      else {
        const basketItem = this.basketService.basket?.Items?.filter(x => x.Product.id === item.Product.id)[0];
        if (basketItem) {
          this.basketService.basket?.Items?.filter(x => x.Product.id === item.Product.id).map(x => x.Product.basketQuantity == item.Product.basketQuantity);
        } else {
          this.basketService.basketItems.push(item);
          this.basketService.basket?.Items?.
            filter(x => x.Product.id === item.Product.id).
            map(x => x.Product.basketQuantity == item.Product.basketQuantity);
        }
      }
      this.basketService.basket?.Items?.forEach(item => { this.itemCount += item.Product.basketQuantity });
    });
  }
}
