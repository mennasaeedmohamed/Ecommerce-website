<h3>this is a web api ecommerce website project</h3>
Endpoints
Products
•	List All Products
•	GET /products
•	Description: Retrieves a list of all products.
•	Parameters:
•	category (optional): Filter products by category.
•	Response:
 [{ "id": 1, "name": "Product Name", "description": "Product Description", "price": 19.99 }] 
•	Get Product
•	GET /products/{id}
•	Description: Retrieves details of a specific product.
•	Parameters:
•	id: Product ID.
•	Response:
•	 { "id": 1, "name": "Product Name", "description": "Product Description", "price": 19.99 }
•	List All Categories
•	GET /categories
•	Description: Fetches all product categories.
•	Response:
•	 [{ "categoryId": 1, "categoryName": "Electronics" }] 
•	Add & update New Product
•	POST /products
•	Description: Adds a new product to the catalog.
•	Request:
•	 { "name": "New Product", "description": "Product Description", "price": 99.99, "categoryId": 1 } 
•	Response:
•	 { "productId": 101, "status": "Created" }

Orders
-	Create Order
•	POST /orders
•	Description: Creates a new order.
•	Request:
{ "customerId": 123, "products": [ { "productId": 1, "quantity": 2 }, { "productId": 2, "quantity": 1 } ] } 
•	Response:
{ "orderId": 456, "status": "success" }

-	Update Order
•	PUT /orders/{orderId}
•	Description: Updates an existing order's status.
•	Parameters:
•	orderId: The ID of the order to update.
•	Request:
{ "status": "Shipped" } 
•	Response:
{ "orderId": 456, "status": "Updated" }

