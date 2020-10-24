import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FilterDisplaySizeComponent } from './filter-display-size/filter-display-size.component';
import { LoginComponent } from './login/login.component';
import { SearchProductComponent } from './search-product/search-product.component';
import { TableComponent } from './table/table.component';

const routes: Routes = [
  {path:"login",component:LoginComponent},
  {path:"admin/products",component:TableComponent},
  {path:"search",component:SearchProductComponent},
  {path:"search-display-size",component:FilterDisplaySizeComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
