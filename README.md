## 🎓 Course Enrollment System

A complete Online Course Enrollment System built using **ASP.NET Core MVC**, **Identity**, **ADO.NET**, and **SQL Server LocalDB**. This project allows students to browse and purchase courses, and provides an admin dashboard to manage users and course data efficiently.

---

## 🚀 Features

### 👤 Authentication & Authorization
- Role-based login system using ASP.NET Identity
- Admin and Student roles
- JWT/Cookie-based login with secure authentication

### 🎓 Student Functionalities
- User registration & login
- Browse available courses with filtering
- Enroll in/purchase courses
- View enrollment history
- Cart system for managing course purchases

### 🛠 Admin Functionalities
- Admin dashboard
- Add/Edit/Delete courses
- View enrolled students and analytics
- Manage users and course data

### 📊 Reports & UI Enhancements
- Dynamic dashboards
- Smooth animations and responsive UI using **Bootstrap**
- Notifications and status pages (403/404)
- Custom error handling

---

## 🧰 Tech Stack

| Layer         | Technology                                |
|--------------|--------------------------------------------|
| Frontend     | ASP.NET Core MVC, Bootstrap 5, Razor Views |
| Backend      | ASP.NET Core, ADO.NET, Identity             |
| Database     | SQL Server LocalDB via Entity Framework     |
| Auth         | ASP.NET Identity (with custom ApplicationUser) |
| Deployment   | Visual Studio 2022 (Localhost / Optional Azure) |

---

## ⚙️ Getting Started

### ✅ Prerequisites

- Visual Studio 2022 or later
- .NET 7 SDK or higher
- SQL Server LocalDB

### 📁 Clone the Repository

git clone https://github.com/shaan-Thakkar-1812/CourseEnrollmentSystem.git

cd CourseEnrollmentSystem

## 🔧 Set Up the Database
Open Package Manager Console in Visual Studio

RUN
Update-Database

This creates the required Identity tables and application schema.

## 🧪 Seed Roles and Admin
The app automatically seeds : Admin and Student roles

 ## Run the Application
Press F5 or Ctrl+F5 in Visual Studio to launch

## 📚 Folder Structure

CourseEnrollmentSystem/
│
├── Controllers/
│   ├── AccountController.cs
│   ├── AdminController.cs
│   └── StudentController.cs
│
├── Models/
│   ├── ApplicationUser.cs
│   ├── Course.cs
│   ├── Enrollment.cs
│   └── Visitor.cs
│
├── Views/
│   ├── Account/
│   │   ├── Login.cshtml
│   │   └── Register.cshtml
│   ├── Admin/
│   │   └── Dashboard.cshtml
│   ├── Student/
│   │   └── Dashboard.cshtml
│   └── Shared/
│       ├── _Layout.cshtml
│       └── _ValidationScriptsPartial.cshtml
│
├── Data/
│   └── ApplicationDbContext.cs
│
├── ViewModels/
│   ├── LoginViewModel.cs
│   └── RegisterViewModel.cs
│
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── lib/
│
├── appsettings.json
├── Program.cs
├── Startup.cs (if applicable)
└── CourseEnrollmentSystem.csproj

## 📈 Future Enhancements
Stripe/PayPal Payment Gateway Integration

Course Completion Certificates

Student Profile & Edit Options

Deployment on Azure/AWS

## 👨‍💻 Author
Shaan Thakkar

📧 Email: shaanthakkar4@gmail.com

## Screenshots

![Screenshot 2025-04-11 130513](https://github.com/user-attachments/assets/be793675-fd95-4857-8416-16faeeae23f0)

![Screenshot 2025-04-11 130559](https://github.com/user-attachments/assets/8ebde50d-4cbf-47ad-9c7e-d1663b4cafc9)


![Screenshot 2025-04-11 130623](https://github.com/user-attachments/assets/ce335db4-5e9a-4eae-a15f-d2e3d2f4c997)


![Screenshot 2025-04-11 130641](https://github.com/user-attachments/assets/032bd5fb-6618-447b-92af-a95239d1cd26)

![Screenshot 2025-04-11 130658](https://github.com/user-attachments/assets/f8434814-c541-4298-9f7e-fd16bfd32676)

![Screenshot 2025-04-11 130729](https://github.com/user-attachments/assets/61b9ad4c-ad4d-42b9-8807-0985df730d67)

![Screenshot 2025-04-11 130623](https://github.com/user-attachments/assets/e0cc9b85-dba9-4eef-a53d-c90febe20d76)
