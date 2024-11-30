## About the Project

This **API**, developed using **.NET 8**, adopts the principles of **Domain-Driven Design (DDD)** to provide a structured and effective solution for personal expense management. The main goal is to allow users to record their expenses, detailing information such as title, date and time, description, amount, and payment type, with the data being securely stored in a **MySQL** database.

The architecture of the **API** is based on **REST**, using standard **HTTP** methods for efficient and simplified communication. Additionally, it is complemented by **Swagger** documentation, which provides an interactive graphical interface for developers to easily explore and test the endpoints.

Among the NuGet packages used, **AutoMapper** is primarily responsible for mapping between domain objects and request/response, reducing the need for repetitive and manual code. **FluentAssertions** is used in unit tests to make assertions more readable, helping to write clear and understandable tests. For validations, **FluentValidation** is used to implement validation rules in a simple and intuitive way in the request classes, keeping the code clean and easy to maintain. Finally, **EntityFramework** acts as an ORM (Object-Relational Mapper) that simplifies interactions with the database, allowing the use of .NET objects to manipulate data directly without the need to handle SQL queries.

### Features

- **Domain-Driven Design (DDD)**: A modular structure that facilitates understanding and maintenance of the application's domain.
- **Unit Tests**: Comprehensive tests with FluentAssertions to ensure functionality and quality.
- **Report Generation**: Ability to export detailed reports to **Excel**, providing a visual and effective analysis of expenses.
- **RESTful API with Swagger Documentation**: Documented interface that facilitates integration and testing by developers.

### Built with

![.NET Badge](https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff&style=for-the-badge)
![badge-windows](https://img.shields.io/badge/Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white)
![visual-studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white)
![badge-mysql](https://img.shields.io/badge/MySQL-005C84?style=for-the-badge&logo=mysql&logoColor=white)
![badge-swagger](http://img.shields.io/badge/Swagger-85EA2D?logo=swagger&logoColor=000&style=for-the-badge)

## Getting Started

To get a working local copy, follow these simple steps.

### Requirements

* Visual Studio version 2022+ or Visual Studio Code
* Windows 10+ or Linux/MacOS with [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed
* MySQL Server

### Installation

1. Clone the repository: 
```sh
git clone git@github.com:benicio227/cashflow.git
```

2. Fill in the information in the appsettings.Development.json file.
3. Run the API and enjoy your test : )
