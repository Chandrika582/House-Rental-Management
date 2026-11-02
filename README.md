House Rental Management System
A console-based House Rental Management System developed using C#, ADO.NET, and SQL Server. The application allows administrators to manage rental properties while clients can view available properties.

Technologies Used:

C#
.NET
ADO.NET
SQL Server
SQL Stored Procedures
BCrypt.Net for Password Hashing
Git and GitHub

Features:

Authentication
User login with username and password.
Client registration.
Secure password hashing using BCrypt.
Password strength validation.
Password confirmation.
Masked password input in the console.
Admin Module
Insert new properties.
Update property details.
Delete properties.
Display property details.
Client Module
View property details.
Restricted access to administrative operations.

Project Architecture:

Program: Application entry point.
HouseManagementUI: Handles console interactions.
User: Abstract base class.
Admin: Administrator functionality.
Client: Client functionality.
HouseManagementService: Business logic and authorization.
HouseRepository: Property database operations.
AuthenticationRepository: User authentication and registration.
House: Property model.

Security:

BCrypt password hashing.
Parameterized SQL queries.
Role-based authorization.
Password validation.

Database:

Database: SQL Server
The application uses ADO.NET to communicate with SQL Server and stored procedures for property management.
Database setup scripts will be provided separately.

How to Run:
Clone this repository.
Open HouseRentalManagement.slnx in Visual Studio.
Restore NuGet packages.
Create the required database and tables in SQL Server.
Configure the database connection string in App.config.
Run the application.

Author:

Chandrika

GitHub: Chandrika582
