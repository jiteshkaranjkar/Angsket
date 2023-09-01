import { IBaseEntity } from "./baseEntity";
import { IProduct } from "./product";

export interface IBasketItem {
  Id?: string;
  Product: IProduct;
  Quantity?: number;
}

export interface IBasket extends IBaseEntity {
  BasketId?: string;
  Items?: IBasketItem[];
  Buyer?: string;
}
