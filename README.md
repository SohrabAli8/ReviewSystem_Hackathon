# 📌 Review System – Enterprise Level Full Stack Application

## 🧾 Project Summary

Review System is a secure full-stack web application built with:

- ASP.NET Core 8 Web API
- Angular 17+ (Standalone Architecture)
- MySQL Database
- JWT Authentication
- Role-Based Authorization

This system demonstrates enterprise-grade backend security,
frontend route protection, and layered architecture.

---

# 🎯 Objectives

- Secure Authentication using JWT
- Role-based Authorization (Admin / User)
- Clean layered backend architecture
- Standalone Angular architecture
- RESTful API design
- Proper separation of concerns

---

# 🏗 High-Level Architecture

Client (Angular SPA)
        ↓
REST API (ASP.NET Core)
        ↓
Entity Framework Core
        ↓
MySQL Database

---

# 🔄 End-to-End Flow

1. User registers
2. Password stored as hashed value
3. User logs in
4. JWT generated
5. Token stored in browser
6. Interceptor attaches token to all requests
7. Backend validates token & role
8. Authorized access granted

---

# 📂 Project Structure

ReviewSystem_Project/
│
├── backend/
│   ├── Controllers/
│   ├── Models/
│   ├── DTOs/
│   ├── Services/
│   ├── Data/
│   ├── Program.cs
│   └── appsettings.json
│
└── frontend/
    ├── src/app/
    │   ├── components/
    │   ├── services/
    │   ├── guards/
    │   ├── interceptors/
    │   ├── app.routes.ts
    │   └── app.config.ts

---

# 🧠 Design Principles Used

- SOLID principles
- Dependency Injection
- DTO Pattern
- Layered Architecture
- Separation of Concerns
- REST API standards

---

# 🔐 Security Features

- Password hashing
- JWT expiry configuration
- Role validation
- Route Guards
- HTTP Interceptor
- CORS configuration

---

# 🛠 Tech Stack

Backend:
- .NET 8
- EF Core
- MySQL

Frontend:
- Angular 17+
- RxJS
- TypeScript

---

# 🚀 Run Project

Backend:
cd backend  
dotnet restore  
dotnet run  

Frontend:
cd frontend  
npm install  
ng serve  

---

# 📈 Future Enhancements

- Refresh Token System
- Pagination & Filtering
- Email Verification
- Docker Deployment
- CI/CD Pipeline
- Unit & Integration Testing
