import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IProduct } from '../../shared/models/product.model';

@Component({
  selector: 'product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent {
  @Input() public products: IProduct[] | undefined;
  @Input() public productCount: number = 1;
  @Output() public readonly addProductEmitter = new EventEmitter<number>();
  @Output() public readonly removeProductEmitter = new EventEmitter<number>();
  @Output() public readonly addToCart = new EventEmitter<number>()

  constructor() {

  }

  emitAddProductToCart(productId: number) {
    this.addProductEmitter.emit(productId)
  }

  emitRemoveProductFromCart(productId: number) {
    this.removeProductEmitter.emit(productId)
  }

  emitAddToCart(productId: number) {
    this.addToCart.emit(productId)
  }
}
