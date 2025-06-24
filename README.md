# 📚 Library Management System (.NET 8 WinForms)

A modern desktop application designed to streamline library operations, including book inventory, reader management, loans, reservations, user roles, and reporting. Built using **C# WinForms** on **.NET 8**, with **SQL Server** as the backend database.

---

## 📁 Project Structure

```plaintext
FINAL_dotNetTechnology/
├── Database/
│   ├── LibraryManagement.mdf  # SQL Server database file
│   └── LMS.sql               # SQL script to initialize the database
├── LibraryManagementSystem/
│   ├── LibraryManagementSystem/  # Main application source code
│   ├── LibraryManagementSystem.sln  # Solution file
│   └── Resources/            # Image assets for UI (icons, images, etc.)
```

---

## ✨ Features

- **🔐 Authentication**: Secure login/register with role-based access (Admin/Reader).
- **📖 Book Management**: Add, update, and delete books in the inventory.
- **👤 Reader Management**: Register and view reader profiles.
- **📆 Reservations & Loans**: Manage book reservations and borrowing requests.
- **📊 Reporting**: Generate reports for loan history, reservations, and overdue books.
- **👨‍💼 Admin Panel**: Comprehensive control over users and data.
- **🖼️ Rich UI**: Professional, image-enhanced interface for an intuitive user experience.

---

## 🧱 Tech Stack

| Layer       | Technology                     |
|-------------|--------------------------------|
| **UI**      | C# WinForms (.NET 8)           |
| **Backend** | ADO.NET, Custom C# Classes     |
| **Database**| SQL Server (.mdf + .sql)       |
| **Reporting**| FastReport (.dlls included)   |
| **Extras**  | iTextSharp for PDF export      |

---

## ⚙️ Setup Instructions

### 🔧 Prerequisites
- **Operating System**: Windows 10 or later
- **IDE**: Visual Studio 2022 or later
- **Framework**: .NET 8 SDK
- **Database**: SQL Server Express or LocalDB

### 🚀 Running the Application

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/realthdat/Library_Management_System.git
   ```

2. **Set Up the Database**:
   - Option 1: Open `Database/LMS.sql` in SQL Server Management Studio and execute the script to create the database.
   - Option 2: Attach `Database/LibraryManagement.mdf` to your SQL Server instance.

3. **Configure the Connection String**:
   - Open `Connection.cs` in the `LibraryManagementSystem` project.
   - Update the connection string to match your SQL Server instance:
     ```csharp
     private string connectionString = "Data Source=.;Initial Catalog=LibraryManagement;Integrated Security=True;";
     ```

4. **Run the Application**:
   - Open `LibraryManagementSystem.sln` in Visual Studio.
   - Set `LibraryManagementSystem` as the startup project.
   - Press **F5** or click **Start** to launch the application.

---

## 🪪 Author

- **Developed by**: DatDev
- **Purpose**: Project for .NET Technology Course
- **Date**: November 2024

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).

---

## 🧠 Keywords

- .NET
- WinForms
- Library Management
- C#
- SQL Server
- Desktop Application
- FastReport
- iTextSharp
