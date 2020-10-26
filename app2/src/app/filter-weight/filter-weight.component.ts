import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { FilterModel, Limits } from '../FilterModel';
import { ProductDetails } from '../ProductDetails';
import { SearchProductService } from '../services/search-product.service';
import {MatPaginator} from '@angular/material/paginator';
import { ViewChild } from '@angular/core';

@Component({
  selector: 'app-filter-weight',
  templateUrl: './filter-weight.component.html',
  styleUrls: ['./filter-weight.component.css']
})
export class FilterWeightComponent implements OnInit {

  filterObject:FilterModel=new FilterModel
  limits:Limits=new Limits
  displayedColumns: string[] =  ['UID', 'name', 'displaySize', 'displayType', 'weight', 'touchScreen', 'action'];
  dataSource = new MatTableDataSource<ProductDetails>();

  constructor(private service2:SearchProductService,private router:Router) { }


  
  form:FormGroup = new FormGroup({
    LowerLimit: new FormControl(false),
    UpperLimit: new FormControl(false),
    
  });
  LowerLimit = this.form.get('LowerLimit');
  UpperLimit = this.form.get('UpperLimit');
  
  LowerLimitValue;
  UpperLimitValue;
  

  
  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngOnInit(): void {

    this.filterObject=history.state.data as FilterModel;
   
    
    this.service2.searchByDisplaySize(this.filterObject).subscribe(
      data=>{
        this.dataSource.data = data as ProductDetails[];
      }
    );
   

      let o:Observable<boolean> = this.LowerLimit.valueChanges;
      o.subscribe( v=> {
          this.LowerLimitValue = v;
          console.log(this.LowerLimitValue)
          
      });

      let p:Observable<boolean> = this.UpperLimit.valueChanges;
      p.subscribe( v=> {
          this.UpperLimitValue = v;
          console.log(this.UpperLimitValue)
          
      });


  }

  onLowerLimitEdit(value){
    this.limits.min=value;
  }

    onUpperLimitEdit(value){
        this.limits.max=value;
    }


  applyDisplaySizeFilter(){
   
    
    this.filterObject.Weight=this.limits;

     

       this.service2.searchByWeight(this.filterObject).subscribe(
        data=>{
          this.dataSource.data = data as ProductDetails[];
        }
      );

  }
  goToComponentFilterTouchscreen(): void {
    
    this.router.navigate(['/search-touchscreen'],{state: {data: this.filterObject}});
}

startNewSearch():void{
  this.router.navigate(['/search']);
}


ngAfterViewInit(): void {   
  this.dataSource.paginator = this.paginator;
}


}
