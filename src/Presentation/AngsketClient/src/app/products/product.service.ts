import { Inject, Injectable } from '@angular/core';
import { IProduct } from '../models/product';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';;
import { map, take, tap } from 'rxjs/operators';

@Injectable()
export class ProductsService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

    getProducts(): Observable<any> {
      return this.http.get<IProduct[]>(this.baseUrl + 'api/products')
        .pipe((result: any) => result)
      //products
      //  .pipe(
      //    tap(),
      //    take(1),
      //    map(prods => {
      //        return prods;
      //    })
      //  )
      //  .subscribe(
      //  (result: any) => { //Next
      //    console.log(result);
      //    return of(result);
      //  },
      //  (err) => { //error
      //    console.log("Error getting products", err);
      //    return of([])
      //  },
      //  () => { //Complete
      //    console.log("Fecthing products completed");
      //  }
      //);
    }


}
