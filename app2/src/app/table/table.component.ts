import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ProductDetails } from '../ProductDetails';
import { TableServiceService } from '../services/table-service.service';

// const ELEMENT_DATA: ProductDetails[] = [
//   {"UID":"ADC789","name":"IntelliVue X4","displaySize":12,"displayType":"LCD","weight":2.5,"touchScreen":false},
//   {"UID":"ADC457","name":"IntelliVue X0","displaySize":9,"displayType":"LED","weight":1.8,"touchScreen":true},
//   {"UID":"ADX577","name":"IntelliVue X56","displaySize":8,"displayType":"Plasma","weight":0.3,"touchScreen":true},
//   {"UID":"ADC577","name":"IntelliVue X7","displaySize":6,"displayType":"LCC","weight":1.3,"touchScreen":true},
//   {"UID":"ADC578","name":"IntelliVue X2","displaySize":15,"displayType":"LCD","weight":5,"touchScreen":true},
//   {"UID":"ADX877","name":"IntelliVue T56","displaySize":8,"displayType":"Plasma","weight":0.3,"touchScreen":true}
// ];


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
  constructor(private service:TableServiceService){}

  ngOnInit(): void {
    this.service.getAllProduct().subscribe(
      data=>{
        this.dataSource.data = data as ProductDetails[];
      }
    );
  }
  openDialog(action, obj){
    
  }
  
}
