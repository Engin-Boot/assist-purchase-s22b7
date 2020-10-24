import { Component, OnInit } from '@angular/core';
import { TableServiceService } from '../services/table-service.service';
import {Router} from '@angular/router';
import { ProductDetails } from '../ProductDetails';


@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {

  UID:string;
  name:string;
  displaySize:number;
  displayType:string;
  weight:number;
  touchScreen:boolean;
  
  constructor(private service:TableServiceService, private route:Router) { }

  ngOnInit(): void {
    this.UID = history.state.data.UID;
    this.name = history.state.data.name
    this.displaySize = history.state.data.displaySize;
    this.displayType = history.state.data.displayType;
    this.weight = history.state.data.weight;
    this.touchScreen = history.state.data.touchScreen;
  }

  onEdit() {
    let prod = {UID:this.UID, name:this.name, displaySize:this.displaySize, displayType:this.displayType, weight:this.weight, touchScreen:this.touchScreen};
    this.service.updateProduct(prod).subscribe(success=>{this.route.navigate(['admin/products']);},error=>{});
    console.warn(prod);
  }
}
