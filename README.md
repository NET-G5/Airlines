# ✈️ Airlines WEB

## 📖 Project Description
**Airlines WEB** is a web application designed for managing airlines. It offers functionalities for flight management, bookings, and user roles, enabling users to easily search and book flights.

---

## 🌟 Key Features
- **User Management**: 
  - 🔑 User registration
  - 🔒 Authentication and authorization
- **Flight Management**: 
  - ✈️ Add, edit, and delete flights
- **Booking System**: 
  - 📅 Search, book, and manage flight bookings

---

## 🛠️ Technologies Used
- **ASP.NET Core**: Backend framework
- **Entity Framework Core**: Database management
- **Identity Framework**: User authentication and authorization
- **SQL Server**: Database
- **Razor Pages & MVC**: Frontend development

---

## 🚀 Getting Started

### 📋 Prerequisites
To get started, ensure you have the following installed:
- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### 🛠️ Installation Steps
To set up the project locally, follow these steps:

1. **Clone the repository**:
   ```bash
   git clone https://github.com/NET-G5/Airlines.git
   cd Airlines
2. **Restore the .NET packages:**:
   ```bash
   dotnet restore
3. **Configure the database connection:** Update the appsettings.json file with your database connection string:
   ```json
   "ConnectionStrings": { "DefaultConnection": "Server=localhost; Database=AirlineDataBase; User Id=sa; Password=MyP@ssw0rd123; TrustServerCertificate=True;" }
4. **Apply database migrations:**:
   ```bash
   dotnet ef database update
5. **Run the application:**
   ```bash
   dotnet run
