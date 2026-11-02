House Rental Management System

A console-based House Rental Management System developed using C#, ADO.NET, and SQL Server. The application provides role-based access for Admin and Client users to manage and view rental properties.

Technologies Used:
  C#
  .NET
  ADO.NET
  SQL Server
  Stored Procedures
  BCrypt.Net
  Git & GitHub

Features:
Authentication
User login with username and password.
Client registration.
Secure password hashing using BCrypt.
Password strength validation.
Password confirmation.
Masked password input.
Admin Module:
  Insert new properties.
  Update existing properties.
  Delete properties.
  Display property details.
Client Module:
  View available properties.
  Restricted access to administrative operations.
Secure login.

OOP Concepts Implemented
Concept	Implementation
  Encapsulation	Protecting user data using private fields and public properties.
  Inheritance	Admin and Client classes inherit from the User class.
  Abstraction	User is an abstract class with an abstract ShowMenu() method.
  Polymorphism	ShowMenu() behaves differently for Admin and Client objects.
Project Architecture
  Program	Application entry point.
  HouseManagementUI:	Handles user interaction.
  User:	Abstract base class.
  Admin:	Admin-specific operations and menu.
  Client:	Client-specific operations and menu.
  HouseManagementService:	Business logic and authorization.
  HouseRepository:	Property database operations.
  AuthenticationRepository:	User registration and authentication.
  House:	Property model.
  
Security:
  BCrypt password hashing.
  Parameterized SQL queries.
  Role-based authorization.
  Password validation.
  Restricted access to administrative operations.
Database:
  Database: SQL Server
  Data access: ADO.NET
  Database operations: SQL Stored Procedures
How to Run?
1.Clone this repository.
2.Open HouseRentalManagement.slnx in Visual Studio.
3.Restore the required NuGet packages.
4.Create the required database and tables in SQL Server.
5.Configure the connection string in App.config.
6.Create the initial Admin account using the application's setup process.
7.Run the application.

Author:
Chandrika
GitHub: Chandrika582
