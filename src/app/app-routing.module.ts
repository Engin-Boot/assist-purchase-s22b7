import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LoginComponent} from './admin/login/login.component'
import {SearchProductComponent}  from './dashboard/search-product/search-product.component';
import {ProductsComponent}  from './admin/products/products.component';


const routes: Routes = [
  {path:"login",component:LoginComponent},
  {path:"dashboard",component:ProductsComponent},
  {path:"search",component:SearchProductComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
