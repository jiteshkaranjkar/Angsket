import { NgModule } from '@angular/core'
import { Routes, RouterModule } from '@angular/router'
import { ChatgptComponent } from './chatgpt/chatgpt.component';
import { SearchComponent } from './search/search.component';
import { HomeComponent } from './home/home.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { LifeCycleComponent } from './lifecycle/lifecycle.component';
import { ProductsComponent } from './products/products.component';
import { BasketComponent } from './basket/basket.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'chatgpt', component: ChatgptComponent },
  { path: 'search', component: SearchComponent },
  { path: 'lifecycle', component: LifeCycleComponent },
  { path: 'contact-us', component: ContactUsComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'basket', component: BasketComponent },
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
