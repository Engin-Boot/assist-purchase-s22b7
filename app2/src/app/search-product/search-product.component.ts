import { AfterViewInit, Component, OnInit,ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { ProductDetails } from '../ProductDetails';
import {FilterModel} from '../FilterModel';
import {TableServiceService} from '../services/table-service.service';
import {SearchProductService} from '../services/search-product.service';
import { FormGroup, FormControl,ReactiveFormsModule, AbstractControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { MatListItem } from '@angular/material/list';
import { Router } from '@angular/router';
import {MatPaginator} from '@angular/material/paginator';


@Component({
  selector: 'app-search-product',
  templateUrl: './search-product.component.html',
  styleUrls: ['./search-product.component.css']
})
export class SearchProductComponent implements OnInit,AfterViewInit {
  
  filterObject:FilterModel=new FilterModel
  listOfDiplayTypes:string[]=[]
  displayedColumns: string[] =  ['UID', 'name', 'displaySize', 'displayType', 'weight', 'touchScreen', 'action'];
  dataSource = new MatTableDataSource<ProductDetails>();
  
 

  constructor(private service:TableServiceService,private service2:SearchProductService,private router:Router){}


  form:FormGroup = new FormGroup({
    LCD: new FormControl(false),
    LCC: new FormControl(false),
    Plasma: new FormControl(false),
    LED:new FormControl(false),
  });
  LCD = this.form.get('LCD');
  LCC = this.form.get('LCC');
  LED = this.form.get('LED');
  Plasma = this.form.get('Plasma');
  
  lcdValue;
  lccValue;
  ledValue;
  plasmaValue;

  


  @ViewChild(MatPaginator) paginator: MatPaginator;



  ngOnInit(): void {


    this.service.getAllProduct().subscribe(
      data=>{
        this.dataSource.data = data as ProductDetails[];
      }
    );
    console.log(this.lcdValue);
      let o:Observable<boolean> = this.LCD.valueChanges;
      o.subscribe( v=> {
          this.lcdValue = v;
          console.log(this.lcdValue)
          
      });

      let p:Observable<boolean> = this.LCC.valueChanges;
      p.subscribe( v=> {
          this.lccValue = v;
          console.log(this.lccValue)
          
      });

      let q:Observable<boolean> = this.LED.valueChanges;
      q.subscribe( v=> {
          this.ledValue = v;
          console.log(this.ledValue)
          
      });

      let r:Observable<boolean> = this.Plasma.valueChanges;
      r.subscribe( v=> {
          this.plasmaValue = v;
          console.log(this.plasmaValue)
      });
  }

  

  applyDisplayTypeFilter(){
   
    this.listOfDiplayTypes=[];

      if(this.lcdValue==true)
         this.listOfDiplayTypes.push("LCD")
      if(this.lccValue==true)
         this.listOfDiplayTypes.push("LCC")
      if(this.ledValue==true)
         this.listOfDiplayTypes.push("LED")
       if(this.plasmaValue==true)
         this.listOfDiplayTypes.push("Plasma")
  
  
      this.filterObject.DisplayType=this.listOfDiplayTypes;

     

       this.service2.searchByDisplayTypes(this.filterObject).subscribe(
        data=>{
          this.dataSource.data = data as ProductDetails[];
        }
      );

  }

  ngAfterViewInit(): void {   
    this.dataSource.paginator = this.paginator;
  }

  goToComponentFilterDisplaySize(): void {
    
    this.router.navigate(['/search-display-size'],{state: {data: this.filterObject}});
  }

  addToCart(){

    alert("Item added to cart");
  }
}