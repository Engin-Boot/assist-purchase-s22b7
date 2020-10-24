import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class TableServiceService {

  constructor(private httpClient:HttpClient) { }

  getAllProduct() {
    return this.httpClient.get(`http://localhost:53010/api/AdminData`);
  }

  addProduct(prod): Observable<any> {
    return this.httpClient.post(`http://localhost:53010/api/AdminData/new`, prod);
  }

  updateProduct(prod): Observable<any> {
    const httpOptions = {
      headers : new HttpHeaders({'Content-Type': 'application/json'})
    };
    return this.httpClient.put(`http://localhost:53010/api/AdminData/update`, prod, httpOptions).pipe();
  }

  deleteProduct(id): Observable<any> {
    return this.httpClient.delete(`http://localhost:53010/api/AdminData/remove/${id}`);
  }
}
