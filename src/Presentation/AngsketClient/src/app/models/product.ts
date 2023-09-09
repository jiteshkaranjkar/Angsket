import { IBaseEntity } from "./baseEntity";

export interface IProduct extends IBaseEntity {
  id: number;
  name?: string;
  brand?: string;
  type?: string;
  description?: string;
  unitPrice?: number;
  promtionalUnitPrice?: number;
  imageURL?: string;
  promotion?: string;
  promotionDescription?: string;
  stockQuantity: number;
  basketQuantity: number;
}

export interface IProductBrand {
  id: number;
  brand: string;
}

export interface IProductType {
  id: number;
  type: string;
}
