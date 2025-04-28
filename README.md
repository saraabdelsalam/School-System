

# SchoolProjectInCleanArchitecture

## 📚 Description
This project is a **School Management System** built using **ASP.NET Core Web API** following the **Clean Architecture** principles.  
It is based on **Code First** approach and implements several best practices and modern patterns to ensure scalability, maintainability, and clean code structure.

---

## 🛠️ Project Components

- **CQRS Design Pattern & MediatR**  
  Implemented CQRS (Command Query Responsibility Segregation) with **MediatR** for a clear separation between read and write operations.

- **Generic Repository Pattern**  
  Built a flexible and reusable data access layer using the **Generic Repository** pattern.

- **Pagination Schema**  
  Integrated pagination for handling large datasets efficiently.

- **Fluent Validations & Custom Error Handling**  
  Used **FluentValidation** for request validations along with centralized and custom error handling middleware.

- **Entity Configurations Using Data Annotations**  
  Applied simple validation and database schema rules directly on models with **Data Annotations**.

- **Entity Configurations Using Fluent API**  
  Handled complex configurations using **Fluent API** inside `DbContext`.

- **Endpoints of Operations**  
  Provided a complete set of CRUD APIs to manage school-related data.

- **CORS Policy Setup**  
  Configured **CORS** (Cross-Origin Resource Sharing) to allow access from specified clients.

- **Identity Integration**  
  Integrated **ASP.NET Core Identity** for user management (registration, login, password hashing, etc.).

- **Authentication**  
  Added **JWT-based Authentication** for securing the API endpoints.

- **Authorization (Roles & Claims)**  
  Implemented **Role-Based** and **Claims-Based** Authorization to control access based on user permissions.

---

## 🚀 How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/saraabdelsalam/SchoolProjectInCleanArchitecture.git
   ```
2. Navigate to the project directory:
   ```bash
   cd SchoolProjectInCleanArchitecture
   ```
3. Set up your database connection string in `appsettings.json`.

4. Run the migrations to create the database:
   ```bash
   Update-Database
   ```

5. Build and run the application:
   ```bash
   dotnet run
   ```

---

## 📂 Technologies Used

- ASP.NET Core 8 Web API
- Entity Framework Core (Code First)
- MediatR
- FluentValidation
- AutoMapper
- JWT Authentication
- ASP.NET Core Identity
- SQL Server

---
