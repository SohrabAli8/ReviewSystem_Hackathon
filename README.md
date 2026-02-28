# E-commerce Product Review System

A full-stack web application designed for browsing a catalog of products, providing secure and authenticated product reviews, and featuring administrative moderation.

This repository encompasses both the **C# .NET Core Web API (Backend)** and the **Angular 17 Application (Frontend)**.

---

## 🏗️ Architecture

The system utilizes an N-Tier architecture, combining the robust strongly-typed functionality of Entity Framework Core via MySQL, secured with JWT Bearer Authentication, and coupled to an aesthetically stunning and responsive Angular User Interface.

### Backend Tech Stack
*   **Framework:** ASP.NET Core Web API (.NET 10.0)
*   **Database:** MySQL (via `MySql.EntityFrameworkCore`)
*   **Authentication:** JSON Web Tokens (JWT) Identity & Claims
*   **Documentation:** Swagger UI

### Frontend Tech Stack
*   **Framework:** Angular 17+ (Standalone Components API)
*   **Routing:** Angular Router
*   **HTTP Client:** `HttpClientModule` (RxJS Observables)
*   **Styling:** Modern Vanilla CSS (Glassmorphism, CSS Gradients, Flexbox, & CSS Grid)

---

## 🌟 Key Features & Use Cases

### 1. Product Catalog Context
The public-facing `ProductCatalogComponent` retrieves a complete list of items fetching from the `.NET` `ProductsController`. It natively aggregates a star rating and calculates dynamically only using **"Approved"** data rows from the `EcommerceDbContext`. 
*   Displays a beautiful grid format.
*   Features subtle CSS animations on interactive components.

### 2. User Star Ratings & Written Reviews
If an individual securely authenticates inside the `LoginComponent` (generating a JWT), they are permitted via the `AuthInterceptor` pipeline to access `POST /api/reviews`.
*   Includes a fully interactive 1-5 Star Selection system.
*   The `.NET` Backend automatically strips the `UserId` securely from the JWT payload using `ClaimTypes.NameIdentifier`.
*   **Security Validation:** The business logic natively queries `.AnyAsync` against the relational `OrderItems` table to definitively ensure a User directly purchased the product before allowing them to leave a review!

### 3. Dynamic Rating Calculation
Instead of storing hard-coded averages that run the risk of desynchronizing over time, the C# Data Queries utilizing `.Average(r => r.Rating)` compute average numbers natively. This logic prevents "Pending" or "Rejected" reviews from impacting the score shown on the platform.

### 4. Admin Panel & Moderation
Users with the specific `"Admin"` role have access to an administrative dashboard located under `/admin`.
*   This page queries specifically against the `AdminReviewService.cs` hitting `GET /api/admin/reviews/pending`.
*   Moderators have "Approve Review" and "Reject" powers. By acting upon these workflows, the changes dynamically alter the global aggregate scores associated with those individual Products.

---

## 🚀 How to Run Locally

### 1. Boot up the Backend Server
1.  Navigate into the main `ReviewSystem` solution folder (`C:\Users\...source\repos\ReviewSystem - Copy`).
2.  Open the solution in Visual Studio.
3.  Ensure your MySQL connection logic (`appsettings.json`) is valid.
4.  Run the Application via `IIS Express` or CLI (`dotnet run`). Wait for port `https://localhost:7139` to broadcast.

### 2. Boot up the Frontend Client
1.  Navigate to the Angular frontend directory (`...\OneDrive\Desktop\Review\frontend`).
2.  Install initial dependencies:
    ```bash
    npm install
    ```
3.  Launch the Angular CLI server:
    ```bash
    npm run start
    ```
4.  Your aesthetic interface is now live! Simply open an internet browser targetting **`http://localhost:4200`** and enjoy!
