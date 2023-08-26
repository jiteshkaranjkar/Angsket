export interface BaseEntity {
  id?: Number,
  isDeleted: Boolean,
  createdBy?: String,
  createdOn: Date,
  lastModifiedBy?: String,
  lastModifiedOn: Date
}
