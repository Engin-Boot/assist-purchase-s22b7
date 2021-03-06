import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddProductComponent } from './add-product/add-product.component';
//import { DeleteProductComponent } from './delete-product/delete-product.component'
import { EditProductComponent } from './edit-product/edit-product.component';

import { FilterDisplaySizeComponent } from './filter-display-size/filter-display-size.component';
import { FilterTouchscreenComponent } from './filter-touchscreen/filter-touchscreen.component';
import { FilterWeightComponent } from './filter-weight/filter-weight.component';

import { LoginComponent } from './login/login.component';
import { MainPageComponent } from './main-page/main-page.component';
import { SalesPersonComponent } from './sales-person/sales-person.component';
import { SearchProductComponent } from './search-product/search-product.component';
import { TableComponent } from './table/table.component';

const routes: Routes = [
  {path:"" , redirectTo:'home', pathMatch:'full'},
  {path: "home", component: MainPageComponent},
  {path:"login",component:LoginComponent},
  {path:"admin/products",component:TableComponent},

  {path:"product/add", component:AddProductComponent},
  {path:"product/edit", component:EditProductComponent},
  //{path:"product/delete", component:DeleteProductComponent}

  {path:"search",component:SearchProductComponent},
  {path:"search-display-size",component:FilterDisplaySizeComponent},
  {path:"search-weight",component:FilterWeightComponent},
  {path:"search-touchscreen",component:FilterTouchscreenComponent},
  {path:"contact-sales",component:SalesPersonComponent },
  {path:"main-page",redirectTo:'home',pathMatch:'full'}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
