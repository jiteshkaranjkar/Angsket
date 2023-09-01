import { Injectable } from "@angular/core";
import { Subject } from "rxjs";
import { IBasket, IBasketItem } from "../models/basket.model";

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  basket: IBasket | undefined;
  addBasketItem: Subject<IBasketItem>;
  updateBasketItem: Subject<IBasketItem>;
  basketItems: Array<IBasketItem>;

  constructor() {
    this.addBasketItem = new Subject<IBasketItem>();
    this.updateBasketItem = new Subject<IBasketItem>();
    this.basketItems = new Array<IBasketItem>();
    this.basket = { Items: this.basketItems, createdOn: new Date(), isDeleted: false, lastModifiedOn: new Date()  };
  }
}
