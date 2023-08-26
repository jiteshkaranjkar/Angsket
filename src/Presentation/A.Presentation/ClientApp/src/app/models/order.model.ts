import { BaseEntity } from "./baseEntity";
import { Product } from "./product";

export interface OrderItem {
  Id?: string;
  Product?: Product;
  Quantity?: number;
}

export enum OrderStatus {
  NotStarted = 0,
  InProgress = 1,
  Completed = 2,
  Failed = 3
}

export interface Order extends BaseEntity {
  OrderId?: string;
  OrderNumber?: number;
  Status: OrderStatus;
  Total?: Number;
  Description?: string;
  Customer?: string;
  OrderItems?: OrderItem[];
}
