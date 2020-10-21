import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { AdminService } from 'src/app/services/AdminService';



import {DialogBoxComponent} from '../dialog-box/dialog-box.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  dataSource:any; 
  displayedColumns: string[] = ['Id', 'Name', 'DisplaySize', 'DisplayType', 'Weight', 'TouchScreen', 'Action'];

  @ViewChild(MatTable,{static:true}) table: MatTable<any>;
  constructor(public dialog: MatDialog, private adminService:AdminService) {
    this.dataSource = adminService.GetAllProducts();
  }

  ngOnInit(): void {
  }

  openDialog(action,obj) {
    obj.action = action;
    const dialogRef = this.dialog.open(DialogBoxComponent, {
      width: '250px',
      data:obj
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result.event == 'Add'){
        this.addRowData(result.data);
      }else if(result.event == 'Update'){
        this.updateRowData(result.data);
      }else if(result.event == 'Delete'){
        this.deleteRowData(result.data);
      }
    });
  }

  addRowData(row_obj){
    var d = new Date();
    let newData = {
      Id:d.getTime(),
      Name:row_obj.Name,
      DisplaySize:row_obj.DisplaySize,
      DisplayType:row_obj.DisplayType,
      Weight:row_obj.Weight,
      TouchScreen:row_obj.TouchScreen
    };
    this.dataSource.push(newData);
    this.adminService.AddProduct(newData);
    this.table.renderRows();
    
  }
  updateRowData(row_obj){
    this.dataSource = this.dataSource.filter((value,key)=>{
      if(value.Id == row_obj.Id){
        value.Name = row_obj.Name;
        value.DisplaySize = row_obj.DisplaySize;
        value.DisplayType = row_obj.DisplayType;
        value.Weight = row_obj.Weight;
        value.TouchScreen = row_obj.TouchScreen;
      }
      return true;
    });
    this.adminService.UpdateProduct(row_obj);
    this.table.renderRows();
  }
  deleteRowData(row_obj){
    this.dataSource = this.dataSource.filter((value,key)=>{
      return value.id != row_obj.id;
    });
    this.adminService.DeleteProduct(row_obj.id);
  }
}

