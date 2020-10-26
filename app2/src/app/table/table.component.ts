import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ProductDetails } from '../ProductDetails';
import { TableServiceService } from '../services/table-service.service';
import {MatPaginator} from '@angular/material/paginator';
import { ViewChild } from '@angular/core';



@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent  {
  
  ELEMENT_DATA:ProductDetails
  displayedColumns: string[] =  ['UID', 'name', 'displaySize', 'displayType', 'weight', 'touchScreen', 'action'];
  dataSource = new MatTableDataSource<ProductDetails>();
  //dataSource = ELEMENT_DATA
  constructor(private service:TableServiceService, private route:Router){}

  
  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngOnInit(): void {
    this.service.getAllProduct().subscribe(
      data=>{
        this.dataSource.data = data as ProductDetails[];
      }
    );
  }
  openDialog(action, obj){
    if (action == "add") {
      this.route.navigate(['product/add']);
    } else if (action == "Update") {
      this.route.navigate(['product/edit'], {state: {data: obj}});
    } else if (action == "Delete") {
      this.service.deleteProduct(obj.UID).subscribe(
        ()=>{
          console.log("request completed");
          this.ngOnInit();
        }
      );

    }
  }

  
  ngAfterViewInit(): void {   
    this.dataSource.paginator = this.paginator;
  }
  
}
