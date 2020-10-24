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

    console.log(filterObject)
    return this.httpClient.post(`http://localhost:53010/api/UserData/filterlist/DisplayType`,filterObject);
  }

  searchByDisplaySize(filterObject:FilterModel){

    console.log(filterObject)
    return this.httpClient.post(`http://localhost:53010/api/UserData/filterlist/DisplaySize`,filterObject);
  }



}
