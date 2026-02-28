# 🌐 Frontend – Angular Standalone Application

## 🧠 Architecture Overview

The frontend is built using Angular Standalone Components.

No NgModule-based architecture.
Uses modern Angular routing & configuration.

---

# 📂 Folder Structure

components/
Contains UI components:
- Login
- Register
- Products
- Reviews

services/
Handles API calls:
- AuthService
- ProductService
- ReviewService

guards/
AuthGuard protects routes.

interceptors/
JWT Interceptor attaches token automatically.

app.routes.ts
Application routing configuration.

app.config.ts
Application bootstrap configuration.

---

# 🔐 Authentication Flow

1. User submits login form
2. AuthService sends credentials
3. JWT received
4. Stored in localStorage
5. Interceptor attaches token
6. Backend validates token

---

# 🔄 Route Protection Example

{
  path: 'products',
  component: ProductsComponent,
  canActivate: [AuthGuard]
}

---

# 📡 API Communication

Uses Angular HttpClient.

All API URLs are stored in service files.

Base API URL example:
http://localhost:5001/api

---

# 🧪 State Handling

- Token stored in localStorage
- Simple auth state management
- RxJS used for async handling

---

# 🎨 UI Features

- Reactive Forms
- Validation
- Conditional Rendering
- Error Message Handling

---

# ⚙️ Run Frontend

1. npm install
2. ng serve

Runs at:
http://localhost:4200

---

# 🚀 Production Build

ng build --configuration production

Deploy dist/ folder.

---

# 🔮 Future Improvements

- Angular Signals
- NgRx state management
- Lazy Loading
- UI Framework integration
- Dark Mode
- Unit Testing (Jasmine/Karma)
