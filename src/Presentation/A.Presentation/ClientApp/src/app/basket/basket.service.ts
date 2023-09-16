import { Inject, Injectable } from '@angular/core';
import { IBasket } from '../shared/models/basket.model';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, of, Subject, Subscription, throwError } from 'rxjs';;
import { catchError, map, take, tap } from 'rxjs/operators';
import { HelperService } from '../shared/services/helper.service';
import { IProduct } from '../shared/models/product.model';
import { ConfigurationService } from '../shared/services/ConfigurationService';



@Injectable({
  providedIn: 'root'
})
export class BasketService {

  private basketUrl: string = '';
  basket: IBasket | undefined;

  addBasketItem: Subject<IProduct>;
  updateBasketItem: Subject<IProduct>;
  basketItems: Array<IProduct>;
  addBasketItemSubscribe: Subscription | undefined;
  public totalBasketItems: number = 0;

  //observable that is fired when item is removed from basket
  private basketUpdateSource = new Subject<void>();
  basketUpdate$ = this.basketUpdateSource.asObservable();

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private helperservice: HelperService, private configurationService: ConfigurationService) {
    if (this.configurationService.isReady) {
      this.basketUrl = this.configurationService.serverConfig?.purchaseUrl!;
    }
    this.addBasketItem = new Subject<IProduct>();
    this.updateBasketItem = new Subject<IProduct>();
    this.basketItems = new Array<IProduct>();
    this.basket = { buyerId: "1", items: this.basketItems, createdOn: new Date(), isDeleted: false, lastModifiedOn: new Date() };
    this.loadData();
  }

  loadData() {
    this.getBasket().
      subscribe(res => {
        if (res != null)
        this.basket = res
      });
  }

  addBasketItems(item: IProduct) {
    this.totalBasketItems = 0;
    if (this.basket?.items?.length === 0) {
      this.basketItems.push(item);
      this.basket?.items?.
        filter(x => x.id === item.id).
        map(x => x.basketQuantity == item.basketQuantity);

    }
    else {
      const basketItem = this.basket?.items?.filter(x => x.id === item.id)[0];
      if (basketItem) {
        this.basket?.items?.filter(x => x.id === item.id).map(x => x.basketQuantity == item.basketQuantity);
      } else {
        this.basketItems.push(item);
        this.basket?.items?.
          filter(x => x.id === item.id).
          map(x => x.basketQuantity == item.basketQuantity);
      }
    }
    this.basket?.items?.forEach(item => { this.totalBasketItems += item.basketQuantity });

    this.addBasket(this.basket)
      .pipe(catchError((err) => this.handleError(err)))
      .subscribe((result: any) => {
        console.log(result);
      });

    return this.totalBasketItems;
  }

  getBasket(): Observable<any> {
    return this.http.get<IBasket>(this.baseUrl + 'b/api/v1/basket/' + this.basket?.buyerId)
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
    let url = this.baseUrl + 'api/baskets';
    return this.http.post<IBasket>(url, this.basket, httpOptions)
      .pipe(
        tap((res: any) => {
          return res;
        }),
        catchError(this.helperservice.handleError)
      );
  }


  addBasket(basket: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<any>(this.baseUrl + 'api/basket', basket, httpOptions);
  }


  handleError(error: any): any {
    return throwError(() => error);
  }
}
