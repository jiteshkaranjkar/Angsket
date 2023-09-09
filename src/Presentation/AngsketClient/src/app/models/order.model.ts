import { IBaseEntity } from "./baseEntity";
import { IProduct } from "./product";

export interface IOrderItem {
  Id?: string;
  Product?: IProduct;
  Quantity?: number;
}

export enum OrderStatus {
  NotStarted = 0,
  InProgress = 1,
  Completed = 2,
  Failed = 3
}

export interface IOrder extends IBaseEntity {
  OrderId?: string;
  OrderNumber?: number;
  Status: OrderStatus;
  Total?: number;
  Description?: string;
  Customer?: string;
  OrderItems?: IOrderItem[];
}
