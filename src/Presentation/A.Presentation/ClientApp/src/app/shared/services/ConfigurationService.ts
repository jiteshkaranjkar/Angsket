import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from "@angular/common/http";
import { IConfiguration } from '../models/configuration.model';
import { Subject } from 'rxjs';

@Injectable()
export class ConfigurationService {
  serverConfig: IConfiguration | undefined;
  private serverSettingsLoadedSource = new Subject<void>();
  serverSettingsLoaded$ = this.serverSettingsLoadedSource.asObservable();
  isReady: boolean = false;

  constructor(private http: HttpClient) { }

  load() {
    const baseURI = document.baseURI.endsWith('/') ? document.baseURI : `${document.baseURI}/`;
    let url = `${baseURI}Home/Configuration`;
    this.http.get(url).subscribe((response) => {
      this.serverConfig = response as IConfiguration;
      console.log('Server Config settings loaded ' + this.serverConfig);
      console.log('purchase Url', this.serverConfig.purchaseUrl);
      this.isReady = true;
      this.serverSettingsLoadedSource.next();
    })
  }
}
