import { IBaseEntity } from "./baseEntity.model";

export interface IAddress {
  id?: string;
  unit?: string;
  street?: string;
  city?: string;
  state?: string;
  country?: string;
  zipCode?: string;
}


export interface IBuyer extends IBaseEntity {
  name?: string;
  loyaltyCard?: string;
  address?: IAddress;
}
