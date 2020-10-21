
import {HttpClient} from '@angular/common/http';
import {Inject, Injectable} from '@angular/core';
@Injectable()
export class DashboardService{
    httpClient:HttpClient;
    baseUrl:string;
    constructor(httpClient:HttpClient, @Inject('apiBaseAddress')baseUrl:string){
        this.httpClient = httpClient;
        this.baseUrl = baseUrl;
    }

    GetAllProducts(){
        let observableStream = this.httpClient.get(`${this.baseUrl}/api/userdata/all`);
        return observableStream;
    }
    AddProduct(product) {
        let observableStream = this.httpClient.post(`${this.baseUrl}/api/userdata/filterlist
        `, product);
        return observableStream;
    }
    
}