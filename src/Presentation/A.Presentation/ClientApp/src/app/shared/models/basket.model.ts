import { IBaseEntity } from "./baseEntity.model";
import { IProduct } from "./product.model";

export interface IBasket extends IBaseEntity {
  items?: IProduct[];
  buyerId?: string;
}
