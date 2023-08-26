import { BaseEntity } from "./baseEntity";
import { Product } from "./product";

export interface BasketItem {
  Id?: string;
  Product?: Product;
  Quantity?: number;
}

export interface Basket extends BaseEntity {
  BasketId?: string;
  Items?: BasketItem[];
  Buyer?: string;
}
