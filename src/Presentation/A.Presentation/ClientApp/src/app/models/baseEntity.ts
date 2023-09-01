export interface IBaseEntity {
  id?: number,
  isDeleted: boolean,
  createdBy?: string,
  createdOn: Date,
  lastModifiedBy?: string,
  lastModifiedOn: Date
}
