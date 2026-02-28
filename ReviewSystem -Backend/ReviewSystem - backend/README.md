# 🖥 Backend – ASP.NET Core Web API

## 🧠 Architecture Pattern

The backend follows:

Controller Layer → Service Layer → Data Layer

- Controllers handle HTTP requests
- Services contain business logic
- Data layer interacts with database

---

# 📂 Folder Explanation

## Controllers/
Handles HTTP endpoints.
Examples:
- AuthController
- ProductController
- ReviewController

## Models/
Entity classes mapped to database tables.

## DTOs/
Used to transfer data safely.
Prevents over-posting and exposing sensitive fields.

## Services/
Contains:
- JWT generation logic
- Business rules

## Data/
Contains:
- AppDbContext
- Database configuration

---

# 🔐 Authentication Implementation

JWT token contains:
- UserId
- Email
- Role

Token is signed using symmetric security key.

Token expiration is configurable in appsettings.json.

---

# 🧾 API Endpoints

## Authentication

POST /api/auth/register  
POST /api/auth/login  

---

## Products

GET /api/products  
GET /api/products/{id}  
POST /api/products (Admin)  
PUT /api/products/{id} (Admin)  
DELETE /api/products/{id} (Admin)

---

## Reviews

GET /api/reviews  
GET /api/reviews/product/{productId}  
POST /api/reviews (Authenticated User)

---

# 🗄 Database Schema

Users
- Id (PK)
- Name
- Email (Unique)
- PasswordHash
- Role

Products
- Id (PK)
- Name
- Description
- Price

Reviews
- Id (PK)
- UserId (FK)
- ProductId (FK)
- Rating
- Comment
- CreatedAt

---

# ⚙️ Configuration

appsettings.json contains:

- ConnectionStrings
- JWT Secret Key
- Logging configuration

Example:

"Jwt": {
  "Key": "SUPER_SECRET_KEY"
}

---

# 🚀 Run Backend

1. dotnet restore
2. dotnet ef database update
3. dotnet run

Runs on:
https://localhost:5001

---

# 🔍 Error Handling Strategy

- Try-catch blocks
- Proper HTTP status codes
- Validation using DataAnnotations

---

# 🧪 Recommended Improvements

- Global Exception Middleware
- Refresh Tokens
- Repository Pattern
- Unit Testing (xUnit)
- Swagger Documentation
