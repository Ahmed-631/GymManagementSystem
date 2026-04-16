# Gym Management System

A full-featured **ASP.NET MVC Gym Management System** designed to manage gym operations efficiently. This application allows you to handle **members, trainers, workout plans, and training sessions** with a clean, maintainable, and scalable architecture.

---

## 🛡️ Authentication & Authorization (Security)

- **ASP.NET Core Identity:** Fully integrated for secure user management.
- **Role-Based Access Control:** Separate permissions for **Admins, Trainers, and Members** to ensure data privacy and system integrity.
- **Secure Profiles:** Individual accounts with protected personal and subscription data.

---

## Features

- **Members Management:** Add, update, delete, and view gym members.  
- **Trainers Management:** CRUD operations for trainers and their profiles.  
- **Workout Plans:** Create and assign personalized workout plans to members.  
- **Training Sessions:** Schedule and track training sessions for members.  

---

## Architecture & Design

- **N-Tier Architecture:** Clear separation between Presentation (MVC), Business Logic (BLL), and Data Access (DAL) layers.
- **Generic Repository Pattern & Unit of Work:** Unified and clean data access logic.  
- **Dependency Injection (DI):** Decoupled components for easier testing and maintenance.  
- **Separation of Concerns:** Each layer handles a specific responsibility to ensure scalability.

---

## Technologies Used

- **Backend:** C#, ASP.NET MVC, Entity Framework Core
- **Security:** ASP.NET Core Identity
- **Frontend:** HTML5, CSS3, Bootstrap, Razor Views  
- **Database:** Microsoft SQL Server  
- **Design Patterns:** Generic Repository, Unit of Work, Dependency Injection

---

## Installation

1. **Clone the repository:**
   ```bash
   git clone [https://github.com/Ahmed-631/GymManagementSystem.git](https://github.com/Ahmed-631/GymManagementSystem.git)
