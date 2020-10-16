# Assist A Purchase

Controllers:
Assist A Purchase consists of three controllers-
- Admin Controller
- User Controller
- Sales Controller

Database(Database Manager):
- Product database 
- Sales Database(product request from customer) 

Models(Database Contractor)
- Product Model
- Sales Model
- Filter Model

Repository(Database Manager):
- Product Database
        - Filter Database Handler
            functions required for User data controller to get product by filter is written here.

        - Product Database Handler
            functions required for Admin and user data controller is written here.

- Sales Database
        -Sales Database Handler
            functions required for Sales Data Controller is written here.




### 1. Admin Data Controller
   
    Admin can access "Admin Data controller" to Add new product, Update Product and Delete Product from Product Database.

    To access this methods URL format is
    http://localhost:53010/api/admindata/{ActionName}
    
        - Add New Product
            - Http Post request is used here.
            - URL format : http://localhost:53010/api/admindata/new
            - provide new product data in json body
            - It is used to add new product data to product database.

        - Update Product by ID
            - Http Put request is used here.
            - URL : http://localhost:53010/api/admindata/update/{id}
            - provide updated product data of perticular id in Json body
            - It is used to update product database of perticular product.

        - Delete Product by ID
            - Http Delete request is used here.
            - URL : http://localhost:53010/api/admindata/remove/{id}
            - provide id of product which want to remove from product database.
            - It is used to delete product data of perticular product id from product database.

    json body format example for Admin Data Controller:
    {
        "Id" : "X001",
        "Name" : "IntelliVue X3",
        "DisplaySize" : 6,
        "DisplayType" : "LCD",
        "Weight" : 1.5,
        "TouchScreen" : true,
    }

### 2. User Data Controller /Filtering product according to user specification

    User can access "User Data controller" to access Product Database. Various Methods used here to access database are Get all products, Get Filtered Products, Get product by name, get product by id.

    Filtering:

    -User need to provide product specification in required format.
    -Json format with display size, display type, weight and touchscreen with minimum and maximum limits for
     display size and weight
    -Return list of filtered products to user using GetProductsByFilter Method

    To access different methods URL format is
    http://localhost:53010/api/userdata/{ActionName}
    
        - Get all products
            - Http Get request is used here.
            - URL format: http://localhost:53010/api/userdata/all
            - It returns list of all products from product database.

         - Get filtered products
            - Http Get request is used here.
            - URL format: http://localhost:53010/api/userdata/filterlist
            - User has to provide json body in filter model format.
            - It uses function Get Filtered Product and returns list of all products from product database according to user requirement of filter given in json body.
           
            json body format example for Get filtered product request:
            {
                "DisplayType" : ["LCD","LED"],
                "DisplaySize" : [{
                    "Max" : 20,
                    "Min" : 6,
                }]
                "Weight" : [{
                    "Max" : 2.5,
                    "Min" : 1.0,
                }]
                "TouchScreen" : true,
             }

         - Get product by name
            - Http Get request is used here.
            - URL format: http://localhost:53010/api/userdata/productbyname/{name}
            - It returns product data of perticular product name.
            - provide product name in url.
        

### 3. Raise Alert to sales department / Sales data controller
    Sales person can access "Sales Data controller" to get all user requests or user requests by name. User can access "Sales Data Controller" to send product request to sales person.
    -It access Sales database

    To access this methods URL format is
    http://localhost:53010/api/salesdata/{ActionName}
    
        - Add New User Request
            - Http Post request is used here.
            - URL format : http://localhost:53010/api/salesdatadata/contacesales
            - provide request data in json body
            - It is used to add user request in sales database.
            -
    json body format example for Sales Data Controller to raise alert:
    {
        "Customer" : "Tom",
        "EmailId" : "tom124@gmail.com",
        "Description" : "Message",
    }

        - Get All
            - Http Get request is used here.
            - URL format: http://localhost:53010/api/salesdata/allalerts
            - It returns all customer data from sales database.


### 4. Web API testing 
        -API controller test
        -Database Management test