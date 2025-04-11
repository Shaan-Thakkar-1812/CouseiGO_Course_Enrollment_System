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
🔧 Set Up the Database
Open Package Manager Console in Visual Studio

RUN
Update-Database
This creates the required Identity tables and application schema.

🧪 Seed Roles and Admin
The app automatically seeds:
Admin and Student roles

 Run the Application
Press F5 or Ctrl+F5 in Visual Studio to launch
![Screenshot 2025-04-11 130513](https://github.com/user-attachments/assets/7c795a97-24a4-4528-a494-582423624200)


![Screenshot 2025-04-11 130623](https://github.com/user-attachments/assets/fc42ea2b-5a3f-46c9-85d9-3ca7bafdf52c)
![Screenshot 2025-04-11 130559](https://github.com/user-attachments/assets/326f0393-4d48-4e18-87e7-33988545cbe![Upload![Screenshot 2025-04-11 130729](https://github.com/user-attachments/assets/2f52b6e3-d43a-42b6-89dc-4c87af7ae9d1)
![Screenshot 2025-04-11 130658](https://github.com/user-attachments/assets/9ac65632-0af0-45a7-8bc9-1cea381ce0ed)
ing Screenshot 2025-04-11 130641.png…]()
6)

📚 Folder Structure

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
│   └── Enrollment.cs
│
├── Views/
│   ├── Account/
│   ├── Admin/
│   ├── Student/
│   └── Shared/
│
├── Data/
│   └── ApplicationDbContext.cs
│
├── wwwroot/
│   └── css/js/assets
│
├── Program.cs
├── appsettings.json
└── README.md

