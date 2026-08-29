# E-Commerce Website

## Description

This project is a full-stack E-Commerce website that allows users to browse products, view product details, add products to their shopping cart, place orders, and manage their accounts.

The system also includes an admin side for managing products, categories, users, and orders.

## Features

### Customer Features

* User registration and login
* JWT authentication
* Browse products
* Search and filter products
* View product details
* Add products to cart
* Update cart quantities
* Remove products from cart
* Place orders
* View order history
* Manage user profile

### Admin Features

* Admin authentication
* Manage products
* Create, update, and delete products
* Manage product categories
* Manage users
* View and manage orders
* Update order status

## Technologies

### Backend

* C#
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* LINQ
* CQRS
* Clean Architecture
* REST APIs
* JWT Authentication

### Frontend

* Angular
* TypeScript
* HTML
* CSS
* Bootstrap

## Architecture

The backend follows Clean Architecture to separate business logic, application logic, and infrastructure.

```text
Angular
   │
   ▼
ASP.NET Core Web API
   │
   ▼
Application Layer
   │
   ├── CQRS
   ├── Commands
   └── Queries
   │
   ▼
Domain Layer
   │
   ▼
Infrastructure Layer
   │
   ├── Entity Framework Core
   └── SQL Server
```

## Authentication

The application uses JWT Authentication to secure the API.

The authentication flow works as follows:

```text
User Login
    ↓
ASP.NET Core API
    ↓
Validate Credentials
    ↓
Generate JWT Token
    ↓
Return Token
    ↓
Angular Stores Token
    ↓
Token Sent With API Requests
```

Different permissions can be applied depending on the user's role.

## Product Management

Products can be managed through the admin dashboard.

Each product can contain information such as:

* Product name
* Description
* Price
* Quantity
* Category
* Product image
* Product status

The admin can create, update, delete, and view products.

## Shopping Cart

The shopping cart allows users to manage the products they want to purchase.

Users can:

* Add products to the cart
* Change product quantity
* Remove products
* View the total price
* Proceed to checkout

```text
Browse Products
      ↓
Add Product to Cart
      ↓
Update Cart
      ↓
Checkout
      ↓
Create Order
```

## Orders

When a customer completes the checkout process, an order is created and stored in the database.

The order contains:

* Customer information
* Order items
* Product information
* Quantity
* Price
* Total amount
* Order status
* Order date

The admin can view orders and update their status.

Example order statuses:

```text
Pending
   ↓
Confirmed
   ↓
Processing
   ↓
Shipped
   ↓
Delivered
```

## Database

SQL Server is used as the main database.

Entity Framework Core is used for:

* Database access
* Entity mapping
* LINQ queries
* Migrations
* CRUD operations
* Relationships between entities

Main entities include:

```text
User
 │
 ├── Cart
 │    └── CartItems
 │
 └── Orders
      └── OrderItems

Category
 │
 └── Products
```

## CQRS

CQRS is used to separate read and write operations.

### Commands

Commands are used for operations that modify data, such as:

* Create Product
* Update Product
* Delete Product
* Add Product to Cart
* Create Order
* Update Order Status

### Queries

Queries are used to retrieve data, such as:

* Get Products
* Get Product Details
* Get Categories
* Get Cart
* Get User Orders
* Get Orders

## API

The backend provides REST APIs for communication between the Angular frontend and ASP.NET Core backend.

Example API operations:

```text
GET    /api/products
GET    /api/products/{id}
POST   /api/products
PUT    /api/products/{id}
DELETE /api/products/{id}

GET    /api/cart
POST   /api/cart/items
PUT    /api/cart/items/{id}
DELETE /api/cart/items/{id}

POST   /api/orders
GET    /api/orders
GET    /api/orders/{id}
```

## Project Structure

```text
E-Commerce
│
├── Backend
│   │
│   ├── API
│   │   └── Controllers
│   │
│   ├── Application
│   │   ├── Commands
│   │   ├── Queries
│   │   ├── DTOs
│   │   └── Services
│   │
│   ├── Domain
│   │   ├── Entities
│   │   ├── Interfaces
│   │   └── Common
│   │
│   └── Infrastructure
│       ├── Persistence
│       ├── Repositories
│       └── Services
│
└── Frontend
    │
    ├── Components
    ├── Pages
    ├── Services
    ├── Guards
    └── Models
```

## Getting Started

### Prerequisites

* .NET SDK
* SQL Server
* Node.js
* Angular CLI

### Backend

Clone the repository:

```bash
git clone https://github.com/your-username/e-commerce.git
```

Navigate to the backend:

```bash
cd Backend
```

Restore the packages:

```bash
dotnet restore
```

Update the database connection string in `appsettings.json`.

Run the migrations:

```bash
dotnet ef database update
```

Run the API:

```bash
dotnet run
```

### Frontend

Navigate to the frontend:

```bash
cd Frontend
```

Install dependencies:

```bash
npm install
```

Run the Angular application:

```bash
ng serve
```

The application will then be available through the Angular development server.

## Author

**Mohamed Zidan**

.NET / Full Stack Developer
