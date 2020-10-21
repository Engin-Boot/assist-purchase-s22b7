import {HttpClient} from '@angular/common/http';
import {Inject, Injectable} from '@angular/core';
@Injectable()
export class AdminService{
    httpClient:HttpClient;
    baseUrl:string;
    constructor(httpClient:HttpClient, @Inject('apiBaseAddress')baseUrl:string){
        this.httpClient = httpClient;
        this.baseUrl = baseUrl;
    }

    GetAllProducts(){
        let observableStream = this.httpClient.get(`${this.baseUrl}/api/AdminData`);
        return observableStream;
    }
    AddProduct(product) {
        let observableStream = this.httpClient.post(`${this.baseUrl}/api/AdminData/new`, product);
        return observableStream;
    }
    UpdateProduct(product) {
        let observableStream = this.httpClient.put(`${this.baseUrl}/api/AdminData/update`, product);
        return observableStream;
    }
    DeleteProduct(id) {
        let observableStream = this.httpClient.delete(`${this.baseUrl}/api/AdminData/remove/${id}`);
    }
}