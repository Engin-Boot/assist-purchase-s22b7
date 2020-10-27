import { Injectable } from '@angular/core';
import {HttpClient }  from '@angular/common/http';
import {FilterModel} from '../FilterModel';
import { observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SearchProductService {

  constructor(private httpClient:HttpClient ){}

  searchByDisplayTypes(filterObject:FilterModel){

    console.log("Disp Type: ")
    console.log(filterObject)
    return this.httpClient.post(`http://localhost:53010/api/UserData/filterList`,filterObject);
  }

  searchByDisplaySize(filterObject:FilterModel){

    
    console.log("Disp Size: ")
    console.log(filterObject)
    return this.httpClient.post(`http://localhost:53010/api/UserData/filterList/size`,filterObject);
  }


  searchByWeight(filterObject:FilterModel){

    
    console.log("weight: ")
    console.log(filterObject)
    return this.httpClient.post(`http://localhost:53010/api/UserData/filterList/weight`,filterObject);
  }


  searchByTouchscreen(filterObject:FilterModel){

    
    console.log("Touchscreen: ")
    console.log(filterObject)
    return this.httpClient.post(`http://localhost:53010/api/UserData/filterList/touchScreen`,filterObject);
  }
}
