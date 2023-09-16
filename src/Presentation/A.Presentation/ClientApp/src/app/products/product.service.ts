import { Inject, Injectable } from '@angular/core';
import { IProduct } from '../shared/models/product.model';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';;
import { map, take, tap } from 'rxjs/operators';
import { ConfigurationService } from '../shared/services/ConfigurationService';

@Injectable()
export class ProductsService {
  private productUrl: string = "";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private configurationService: ConfigurationService) {
    this.configurationService.serverSettingsLoaded$.subscribe(x => {
      this.productUrl = this.configurationService.serverConfig?.purchaseUrl + 'p/api/v1/products'
    });
  }

    getProducts(): Observable<any> {
      return this.http.get<IProduct[]>(this.baseUrl + 'api/products')
        .pipe((result: any) => result)
    }


}
