import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { FilterModel } from '../FilterModel';
import { ProductDetails } from '../ProductDetails';
import { SearchProductService } from '../services/search-product.service';
import { TableServiceService } from '../services/table-service.service';

@Component({
  selector: 'app-filter-touchscreen',
  templateUrl: './filter-touchscreen.component.html',
  styleUrls: ['./filter-touchscreen.component.css']
})
export class FilterTouchscreenComponent implements OnInit {
  filterObject:FilterModel=new FilterModel
  touch:boolean
  displayedColumns: string[] =  ['UID', 'name', 'displaySize', 'displayType', 'weight', 'touchScreen', 'action'];
  dataSource = new MatTableDataSource<ProductDetails>();
  listOfDiplayTypes: string[];

  

  constructor(private service:TableServiceService,private service2:SearchProductService,private router:Router){}


  form:FormGroup = new FormGroup({
    Touch: new FormControl(false),
    
  });
  Touch = this.form.get('Touch');
  
  
  touchValue;
  
  

  ngOnInit(): void {

    this.filterObject=history.state.data as FilterModel;
   

    this.service2.searchByWeight(this.filterObject).subscribe(
      data=>{
        this.dataSource.data = data as ProductDetails[];
      }
    );

    console.log(this.touchValue);
      let o:Observable<boolean> = this.Touch.valueChanges;
      o.subscribe( v=> {
          this.touchValue = v;
          console.log(this.touchValue)
          
      });

  }


  applyDisplayTypeFilter(){
   
  
    this.touch=false;
      if(this.touchValue==true)
         this.touch=true;
      
  
  
      this.filterObject.TouchScreen=this.touch;

     

       this.service2.searchByTouchscreen(this.filterObject).subscribe(
        data=>{
          this.dataSource.data = data as ProductDetails[];
        }
      );

  }
  startNewSearch():void{
    this.router.navigate(['/search']);
  }
 
}


