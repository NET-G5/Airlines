Airlines WEB

Project Description

Airlines WEB is a web application designed for managing airlines, including flight management, bookings, and user roles. The application allows users to search and book flights, while administrators can manage flight schedules, bookings, and user roles.

Key Features

User Management: User registration, authentication, and authorization.
Flight Management: Add, edit, and delete flights.
Booking System: Users can search, book, and manage their flight bookings.
Admin Dashboard: Admins can manage flights, view bookings, and assign user roles.
Technologies Used

ASP.NET Core for the backend.
Entity Framework Core for database management.
Identity Framework for user authentication and authorization.
SQL Server for the database.
Razor Pages and MVC for frontend rendering.
Getting Started

Prerequisites
.NET 6.0 SDK
SQL Server
Installation
Clone the repository:
bash
Copy code
git clone https://github.com/YourUsername/AirlinesWEB.git
cd AirlinesWEB
Restore the .NET packages:
bash
Copy code
dotnet restore
Update the appsettings.json file with your database connection string:
json
Copy code
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=AirlinesDB;Trusted_Connection=True;"
}
Apply the database migrations:
bash
Copy code
dotnet ef database update
Run the application:
bash
Copy code
dotnet run
Usage
Access the application at http://localhost:5000.
Admin users can log in and access the admin dashboard to manage flights and bookings.
Contribution

Fork the repository.
Create a new branch:
bash
Copy code
git checkout -b feature-branch
Commit your changes:
bash
Copy code
git commit -m "Add new feature"
Push to the branch:
bash
Copy code
git push origin feature-branch
Open a pull request.
License

This project is licensed under the MIT License.
