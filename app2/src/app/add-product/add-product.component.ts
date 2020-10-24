import { Component, OnInit } from '@angular/core';
import { TableServiceService } from '../services/table-service.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  UID:string;
  name:string;
  displaySize:number;
  displayType:string;
  weight:number;
  touchScreen:boolean;

  constructor(private service:TableServiceService, private route:Router) { }

  ngOnInit(): void {
  }
  
  onAdd(){
    let prod = {UID:this.UID, name:this.name, displaySize:this.displaySize, displayType:this.displayType, weight:this.weight, touchScreen:this.touchScreen};
    this.service.addProduct(prod).subscribe(success=>{this.route.navigate(['admin/products']);},error=>{})
    console.warn(prod);
  }

}
