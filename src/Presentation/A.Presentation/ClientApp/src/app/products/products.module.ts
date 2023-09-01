import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common'
import { ProductsComponent } from './products.component';
import { ProductsService } from './product.service';
import { MaterialModule } from '../material/material.module';
import { ProductCardComponent } from './product-card/product-card.component';

@NgModule({
  imports: [BrowserModule, CommonModule, MaterialModule],
  declarations: [ProductsComponent, ProductCardComponent],
  providers: [ProductsService]
})
export class ProductsModule {}
