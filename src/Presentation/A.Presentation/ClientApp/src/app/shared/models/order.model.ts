import { IBaseEntity } from "./baseEntity.model";
import { IProduct } from "./product.model";

export interface IOrderItem {
  id?: string;
  product?: IProduct;
  quantity?: number;
}

export enum OrderStatus {
  notStarted = 0,
  inProgress = 1,
  completed = 2,
  failed = 3
}

export interface IOrder extends IBaseEntity {
  orderId?: string;
  orderNumber?: number;
  status: OrderStatus;
  total?: number;
  description?: string;
  customer?: string;
  orderItems?: IOrderItem[];
}
