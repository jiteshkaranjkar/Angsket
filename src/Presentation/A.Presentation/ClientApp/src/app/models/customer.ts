import { BaseEntity } from "./baseEntity";

export interface Address {
  Id?: string;
  Unit?: string;
  Street?: string;
  City?: string;
  State?: string;
  Country?: string;
  ZipCode?: string;
}


export interface Buyer extends BaseEntity {
  Name?: string;
  LoyaltyCard?: string;
  Address?: Address;
}
