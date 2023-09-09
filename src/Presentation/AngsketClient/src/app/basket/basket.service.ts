import { Inject, Injectable } from '@angular/core';
import { IBasket, IBasketItem } from '../models/basket.model';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, of, Subject, Subscription, throwError } from 'rxjs';;
import { catchError, map, take, tap } from 'rxjs/operators';
import { HelperService } from '../services/helper.service';



@Injectable({
  providedIn: 'root'
})
export class BasketService {
  basket: IBasket | undefined;
  addBasketItem: Subject<IBasketItem>;
  updateBasketItem: Subject<IBasketItem>;
  basketItems: Array<IBasketItem>;
  addBasketItemSubscribe: Subscription | undefined;
  public totalBasketItems: number = 0;

  //observable that is fired when item is removed from basket
  private basketUpdateSource = new Subject<void>();
  basketUpdate$ = this.basketUpdateSource.asObservable();

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private helperservice: HelperService) {
    this.addBasketItem = new Subject<IBasketItem>();
    this.updateBasketItem = new Subject<IBasketItem>();
    this.basketItems = new Array<IBasketItem>();
    this.basket = { Items: this.basketItems, createdOn: new Date(), isDeleted: false, lastModifiedOn: new Date() };
  }

  addBasketItems(item: IBasketItem) {
    this.totalBasketItems = 0;
    if (this.basket?.Items?.length === 0) {
      this.basketItems.push(item);
      this.basket?.Items?.
        filter(x => x.Product.id === item.Product.id).
        map(x => x.Product.basketQuantity == item.Product.basketQuantity);

    }
    else {
      const basketItem = this.basket?.Items?.filter(x => x.Product.id === item.Product.id)[0];
      if (basketItem) {
        this.basket?.Items?.filter(x => x.Product.id === item.Product.id).map(x => x.Product.basketQuantity == item.Product.basketQuantity);
      } else {
        this.basketItems.push(item);
        this.basket?.Items?.
          filter(x => x.Product.id === item.Product.id).
          map(x => x.Product.basketQuantity == item.Product.basketQuantity);
      }
    }
    this.basket?.Items?.forEach(item => { this.totalBasketItems += item.Product.basketQuantity });

    this.updateBasket()
      .pipe(catchError((err) => this.handleError(err)))
      .subscribe((result: any) => {
        console.log(result);
      });

    return this.totalBasketItems;
  }

  getBasket(): Observable<any> {
    return this.http.get<IBasket>(this.baseUrl + 'api/basket')
      .pipe((result: any) => result)
  }

  private headers = new HttpHeaders();

  updateBasket(): Observable<any> {
    let options = {};
    let bodyString = JSON.stringify(this.basket);
    const httpOptions = { headers: new HttpHeaders({ 'content-type': 'application/json' }) };


    this.headers = this.headers.append('X-Requested-With', 'XMLHttpRequest');
    this.headers = this.headers.append('Content-Type', 'application/json');
    this.headers = this.headers.append('Accept', 'application/json');
    this.headers = this.headers.append('Access-Control-Allow-Headers', 'content-type');
    //const httpParams = new HttpParams().set('page', queryStringParameters.page).set('sort', queryStringParameters.sort);
    //this.helperservice.setHeaders(options, false);
    //const headers = { 'content-type': 'application/json' }  
    let url = this.baseUrl + 'api/basket';
    return this.http.post<IBasket>(url, this.basket, httpOptions)
      .pipe(
        tap((res: any) => {
          return res;
        }),
        catchError(this.helperservice.handleError)
      );
  }


  handleError(error: any): any {
    return throwError(() => error);
  }
}
