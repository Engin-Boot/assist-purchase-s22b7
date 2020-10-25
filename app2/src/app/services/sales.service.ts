import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserForSalesDetails } from '../FilterModel';

@Injectable({
  providedIn: 'root'
})
export class SalesService {

  constructor(private httpClient:HttpClient ){}

  postCustomerDetails(salesInfo:UserForSalesDetails){

    console.log("Sales Info:")
    console.log(salesInfo)
    return this.httpClient.post(`http://localhost:53010/api/SalesData/contactsales`,salesInfo);
  }
}