import { BaseEntity } from "./baseEntity";

export interface Product extends BaseEntity {
  Name?: string;
  Brand?: string;
  Type?: string;
  Description?: string;
  UnitPrice?: number;
  PromtionalUnitPrice?: number;
  ImageURL?: string;
  Promotion?: string;
  PromotionDescription?: string;
}
