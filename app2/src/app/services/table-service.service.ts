import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class TableServiceService {

  constructor(private httpClient:HttpClient) { }

  getAllProduct() {
    return this.httpClient.get(`http://localhost:53010/api/AdminData`);
  }

}
