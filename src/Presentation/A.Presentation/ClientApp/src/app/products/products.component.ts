import { Component, Inject, OnInit, ViewChild, EventEmitter, Input, Output } from '@angular/core';
import { catchError } from 'rxjs';
import { IProduct } from '../shared/models/product.model';
import { ProductsService } from './product.service';
import { BasketService } from '../basket/basket.service';
import { MatButtonModule } from '@angular/material/button';
import { ProductCardComponent } from './product-card/product-card.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  @Output() public readonly addBasketItem = new EventEmitter<number>();
  products: IProduct[] = [];
  public productCount = 0;
  constructor(private productService: ProductsService, private basketservice: BasketService) {

  }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.getProducts();
  }

  getProducts() {
    this.productService.getProducts()
      .pipe(catchError((err) => this.handleError(err)))
      .subscribe((result: any) => {
        this.products = result;
      })
  }

  handleError(err: any): any {
    throw new Error('Method not implemented.');
  }

  public receiveAddProductToCart(productId: number) {
    this.products.filter((x) => x.id == productId).map(x => x.basketQuantity++);
  }

  public receiveRemoveProductFromCart(productId: number) {
    this.products.filter((x) => x.id == productId && x.basketQuantity > 0).map(x => x.basketQuantity--);
  }

  public receiveAddToCart(productId: number) {
    this.basketservice.addBasketItem.next(this.products.filter((x) => x.id == productId)[0]);
  }

  updateBasket() {
    this.basketservice.updateBasket()
      .pipe(catchError((err) => this.handleError(err)))
      .subscribe((result: any) => {
        this.products = result;
      })
  }
}
