import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { FilterModel, UserForSalesDetails } from '../FilterModel';
import { ProductDetails } from '../ProductDetails';
import { SalesService } from '../services/sales.service';
import { SearchProductService } from '../services/search-product.service';

@Component({
  selector: 'app-sales-person',
  templateUrl: './sales-person.component.html',
  styleUrls: ['./sales-person.component.css']
})
export class SalesPersonComponent implements OnInit {
  filterObject:FilterModel=new FilterModel
  dataSource = new MatTableDataSource<ProductDetails>();
  salesInfo:UserForSalesDetails=new UserForSalesDetails

  constructor(private service2:SearchProductService,private service3:SalesService,private router:Router) { }


  

  ngOnInit(): void {

    this.filterObject=history.state.data as FilterModel;
   
    
    this.service2.searchByTouchscreen(this.filterObject).subscribe(
      data=>{
        this.dataSource.data = data as ProductDetails[];
      }
    );
   


  }

  onNameEdit(value){
    this.salesInfo.CustomerName=value;
  }

    
  onEmailEdit(value){
        this.salesInfo.EmailId=value;
  }



  
  submitDetails(): void {



    this.salesInfo.Description=this.dataSource.data as ProductDetails[];
   
    this.service3.postCustomerDetails(this.salesInfo).subscribe(
      success=>{
        window.alert("Submitted successfully!\nOur executive shall get in touch with you shortly :)");
        console.log("success"),error=>{}}
    );


}

gotoMainPage():void{
  this.router.navigate(['/main-page']);
}

}
