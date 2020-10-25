import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddProductComponent } from './add-product/add-product.component';
//import { DeleteProductComponent } from './delete-product/delete-product.component'
import { EditProductComponent } from './edit-product/edit-product.component';

import { FilterDisplaySizeComponent } from './filter-display-size/filter-display-size.component';
import { FilterTouchscreenComponent } from './filter-touchscreen/filter-touchscreen.component';
import { FilterWeightComponent } from './filter-weight/filter-weight.component';

import { LoginComponent } from './login/login.component';
import { SearchProductComponent } from './search-product/search-product.component';
import { TableComponent } from './table/table.component';

const routes: Routes = [
  {path:"login",component:LoginComponent},
  {path:"admin/products",component:TableComponent},

  {path:"product/add", component:AddProductComponent},
  {path:"product/edit", component:EditProductComponent},
  //{path:"product/delete", component:DeleteProductComponent}

  {path:"search",component:SearchProductComponent},
  {path:"search-display-size",component:FilterDisplaySizeComponent},
  {path:"search-weight",component:FilterWeightComponent},
  {path:"search-touchscreen",component:FilterTouchscreenComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
