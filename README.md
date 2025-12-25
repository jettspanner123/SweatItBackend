# 🏋️‍♀️ SweatIt Back End API 🏋️‍♂️

![.NET 10.0](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![API Status](https://img.shields.io/badge/API-Live-brightgreen?style=for-the-badge&logo=dot-net&logoColor=white)

---

## ✨ Project Overview

Welcome to the **SweatIt Back End API**! This project provides a robust and scalable backend for a fitness application, built with ASP.NET Core 10.0. It handles user authentication, user management, and other core functionalities, ensuring a secure and efficient experience.

---

## 🚀 Features

-   **User Authentication**: 🔐 Secure user registration and login with `BCrypt.Net-Next` for password hashing.
-   **User Management**: 👤 Create, retrieve, update, and manage user profiles.
-   **Modular Architecture**: 🏗️ Cleanly separated modules for Authentication and User services.
-   **PostgreSQL Database**: 🐘 Utilizes `Npgsql.EntityFrameworkCore.PostgreSQL` for efficient data storage and retrieval.
-   **OpenAPI Documentation**: 📄 Automatically generated API documentation using `Microsoft.AspNetCore.OpenApi` for easy API exploration and testing.
-   **Password Hashing**: 🔒 Strong password security with `BCrypt.Net-Next`.

---

## 📂 Project Structure

The project follows a well-organized structure to promote maintainability and scalability:

```
.
├── Constants/                  # Application-wide constants (if any)
├── Migrations/                 # Entity Framework Core Migrations
├── Models/                     # Data Transfer Objects (DTOs) and API Responses
│   ├── Auth/                   # Authentication-related models
│   ├── Base/                   # Base models and common responses
│   └── User/                   # User-related models
├── Modules/                    # Core application modules
│   ├── Auth/                   # Authentication logic (Controller, Service, Interface)
│   └── User/                   # User management logic (Controller, Service, Interface)
├── Utils/                      # Utility classes and helpers
│   ├── DBContext.cs            # Database context for Entity Framework Core
│   └── PasswordService.cs      # Service for password hashing and verification
├── Program.cs                  # Application entry point and service configuration
├── appsettings.json            # Application settings
├── appsettings.Development.json# Development-specific application settings
└── SweatItBackEnd.csproj       # Project file with dependencies
```

---

## 🛠️ Getting Started

Follow these steps to get your development environment up and running.

### Prerequisites

Before you begin, ensure you have the following installed:

-   [.NET SDK 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) 🖥️
-   [PostgreSQL](https://www.postgresql.org/download/) 🐘
-   A code editor (e.g., [Visual Studio Code](https://code.visualstudio.com/), [Visual Studio](https://visualstudio.microsoft.com/downloads/)) ✍️

### Installation

1.  **Clone the repository**:

    ```bash
    git clone https://github.com/your-username/SweatItBackEnd.git
    cd SweatItBackEnd
    ```

2.  **Restore NuGet packages**:

    ```bash
    dotnet restore
    ```

3.  **Configure your database**:
    Update the `DefaultConnection` string in `appsettings.json` and `appsettings.Development.json` to point to your PostgreSQL instance.

    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Port=5432;Database=sweatitdb;Username=yourusername;Password=yourpassword"
    }
    ```

4.  **Apply database migrations**:

    ```bash
    dotnet ef database update
    ```

### Running the Application

To run the application in development mode:

```bash
dotnet run
```

The API will typically be accessible at `https://localhost:7000` (or a similar port).

---

## 💡 API Endpoints

The API exposes the following main modules:

### Authentication Module (`/api/Auth`)

-   `POST /api/Auth/register`: Register a new user.
-   `POST /api/Auth/login`: Authenticate an existing user.

### User Module (`/api/User`)

-   `GET /api/User/{id}`: Retrieve user details by ID.
-   `PUT /api/User/{id}`: Update user details by ID.
-   `DELETE /api/User/{id}`: Delete a user by ID.

For detailed information on all available endpoints and their request/response schemas, refer to the OpenAPI documentation available at `/swagger` (e.g., `https://localhost:7000/swagger`) once the application is running.

---

## 🤝 Contributing

We welcome contributions to the SweatIt Back End API! If you'd like to contribute, please follow these steps:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Make your changes and ensure they adhere to the existing code style.
4.  Write tests for your changes.
5.  Submit a pull request with a clear description of your changes.

---

## 📄 License

This project is licensed under the MIT License - see the `LICENSE` file for details (if applicable).

