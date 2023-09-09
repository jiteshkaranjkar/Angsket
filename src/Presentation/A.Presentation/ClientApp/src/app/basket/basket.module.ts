import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common'
import { BasketComponent } from './basket.component';
import { BasketService } from './basket.service';
import { MaterialModule } from '../material/material.module';
import { HttpClientModule, HttpClientJsonpModule } from '@angular/common/http';


@NgModule({
  declarations: [ BasketComponent],
  imports: [BrowserModule, CommonModule, MaterialModule, HttpClientModule, HttpClientJsonpModule],
  providers: [BasketService]
})
export class BasketModule { }
