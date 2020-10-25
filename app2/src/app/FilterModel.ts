import { EmailValidator } from '@angular/forms';
import { ProductDetails } from './ProductDetails';

  export class FilterModel
  {
    DisplayType:string[];
    DisplaySize:Limits;
    Weight:Limits;
    TouchScreen:boolean;
  }

 export  class Limits
      {
        max:Int32Array;
        min:Int32Array;
         
      }


  export class UserForSalesDetails{
    CustomerName:string;
    EmailId:EmailValidator
    Description:ProductDetails[]

}
     