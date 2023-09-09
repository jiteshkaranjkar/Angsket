import { IBaseEntity } from "./baseEntity";

export interface IAddress {
  Id?: string;
  Unit?: string;
  Street?: string;
  City?: string;
  State?: string;
  Country?: string;
  ZipCode?: string;
}


export interface IBuyer extends IBaseEntity {
  Name?: string;
  LoyaltyCard?: string;
  Address?: IAddress;
}
