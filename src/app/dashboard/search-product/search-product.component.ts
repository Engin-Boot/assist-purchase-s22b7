import { Component, OnInit } from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import { DashboardService } from 'src/app/services/dashboard.service';



@Component({
  selector: 'app-search-product',
  templateUrl: './search-product.component.html',
  styleUrls: ['./search-product.component.css']
})
export class SearchProductComponent implements OnInit {

  dataSource:any;
  displayedColumns:string[];

  constructor(dashboardService:DashboardService) {
  
    this.displayedColumns = ['id', 'name', 'display-size', 'display-type', 'weight', 'touch-screen'];
    this.dataSource = dashboardService.GetAllProducts();
   }

   
  ngOnInit(): void {
  }
    

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

}


