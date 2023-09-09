import { IBaseEntity } from "./baseEntity";
import { IProduct } from "./product";

export interface IBasket extends IBaseEntity {
  Items?: IProduct[];
  Buyer?: string;
}
