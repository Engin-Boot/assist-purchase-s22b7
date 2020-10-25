import { Component, OnInit } from '@angular/core';
import { TableServiceService } from '../services/table-service.service';
import {Router} from '@angular/router';
import { ProductDetails } from '../ProductDetails';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  UID:string;
  name:string;
  displaySize:string;
  displayType:string;
  weight:string;
  touchScreen:boolean;
  //prod:ProductDetails;
  constructor(private service:TableServiceService, private route:Router) { }

  ngOnInit(): void {
  }
  
  onAdd(){
    //let prod = {UID:this.UID, name:this.name, displaySize:this.displaySize, displayType:this.displayType, weight:this.weight, touchScreen:this.touchScreen};
    // this.prod.UID = this.UID;
    // this.prod.displaySize = this.displaySize;
    // this.prod.displayType = this.displayType;
    // this.prod.name = this.name;
    // this.prod.weight = this.weight;
    // this.prod.touchScreen = this.touchScreen;
    const prod: ProductDetails = {
      UID : this.UID,
      name : this.name,
      displaySize : this.displaySize,
      displayType : this.displayType,
      weight : this.weight,
      touchScreen : this.touchScreen
    };
    this.service.addProduct(prod).subscribe(success=>{this.route.navigate(['admin/products']);},error=>{})
    console.warn(prod);
  }

}
