#  Fridge Rental Management System

A full-stack, data-driven web application designed for a fridge rental company to manage inventory, customer rentals, maintenance workflows, and operational tracking. Built with a strong focus on database design, performance, and real-world business processes.

---


This system simulates a **fridge rental company** where fridges are assigned to customers, tracked throughout their lifecycle, and maintained through technician workflows.

The application enables the business to:

* Display available fridges for customers to rent
* Allow customers to request and place rental orders
* Assign fridges to customers using unique identifiers
* Track which customer has which fridge at any time
* Monitor fridge condition through inspections
* Log issues and escalate serious faults
* Dispatch technicians for maintenance and repairs

---

##  Key Features

* Customer-facing fridge selection and rental requests
* Admin assignment of fridges to customers
* Unique fridge tracking using model/serial numbers
* Full lifecycle tracking (Available → Assigned → Maintenance → Escalated)
* Maintenance logging and technician assignment
* Issue escalation for critical faults
* Full CRUD operations (Customers, Fridges, Rentals, Maintenance Logs)

---

##  User Roles

* **Customer:** Views available fridges and submits rental requests
* **Admin/Staff:** Assigns fridges, manages inventory, monitors allocations
* **Technician:** Inspects fridges, logs issues, performs repairs

---

## 🛠️ Tech Stack

**Backend:** C#, ASP.NET MVC
**Database:** Microsoft SQL Server (T-SQL, SSMS)
**ORM:** Entity Framework / Dapper
**Frontend:** HTML, CSS, JavaScript
**Tools:** Visual Studio, Git

---

##  Architecture & Design

### Database Design

* Normalized relational schema
* Key tables:

  * Customers
  * Fridges (with unique identifiers)
  * Rentals / Allocations
  * MaintenanceLogs
  * Technicians
* Relationships enforced using foreign keys

### Backend Structure

* MVC architecture
* Separation of concerns (Controllers, Models, Views)
* Scalable and maintainable code structure

---

##  Performance & Optimization

* Implemented efficient SQL queries using JOINs
* Reduced redundant data retrieval
* Designed schema for scalability and fast lookups

---

##  Data Integrity & Security

* Enforced relational constraints and data consistency
* Input validation across application layers
* Structured workflows for reliable tracking

---

##  Workflow Example

1. Customer browses available fridges
2. Customer submits a rental request
3. Admin assigns a fridge (tracked by unique ID)
4. System records allocation and updates status
5. Technician performs routine inspections
6. Issues are logged and categorized
7. Critical issues are escalated for urgent resolution

---

##  Testing & Debugging

* Debugged backend logic using Visual Studio
* Tested queries and procedures in SSMS
* Resolved performance and data consistency issues

---

##  My Role

* Designed the relational database schema for a rental business model
* Implemented backend logic using ASP.NET MVC
* Integrated SQL Server with the application
* Developed and optimized SQL queries for tracking and reporting
* Built workflows for rental tracking and maintenance processes
* Debugged and improved system performance

---

##  Key Learnings

* Designing systems for real-world business workflows
* Managing relational data with multiple dependencies
* Writing efficient SQL queries for tracking and reporting
* Implementing role-based system behavior

---

##  Future Improvements

* Implement stored procedures for complex operations
* Add reporting using SQL Server Reporting Services (SSRS)
* Introduce role-based authentication and authorization
* Deploy to cloud (Azure)

---

#  Portfolio Page Version (For Your Website)

## Fridge Rental Management System

### Overview

A full-stack web application built for a fridge rental business to manage inventory, customer rentals, and maintenance operations. This project demonstrates my ability to design scalable systems with strong SQL Server integration and real-world workflows.

### What Makes This Project Strong

* Simulates a real business (fridge rental operations)
* End-to-end system (customer → admin → technician workflow)
* Strong database design and relational data tracking
* Focus on performance, scalability, and maintainability

### Technologies

C#, ASP.NET MVC, SQL Server, Entity Framework, Dapper, JavaScript

### My Contribution

I designed and developed the full system, including database architecture, backend logic, and workflow implementation. I focused on tracking assets (fridges), managing allocations, and handling maintenance processes using efficient SQL queries.

### Outcome

The system provides a structured, scalable solution for managing fridge rentals, tracking assets, and maintaining operational efficiency — demonstrating my ability to build production-ready applications aligned with real business needs.

---

##  Final Note

This project reflects my ability to design and build systems that solve real business problems, with a strong emphasis on SQL, backend development, and system performance.
