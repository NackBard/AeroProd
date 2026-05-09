# 🏭 AeroProd

A desktop enterprise management system for an aerospace production facility, built with **WPF (.NET Framework)**. The application implements role-based access control with 6 distinct user roles, each with a tailored interface for their responsibilities.

## 📸 Screenshots

> _Add screenshots of the app here_

## ✨ Features

- 🔐 **Role-based authentication** — 6 access levels with individual dashboards per role
- 👔 **Admin panel** — full CRUD for employees and system users, access level management
- 🏗️ **Workshop management** — track workshops, work areas, brigades, and their assignments
- 👷 **Brigade management** — assign staff to brigades, manage foremen
- 🧪 **Tester module** — upload reports with file attachments, view all submitted reports
- 👤 **Employee profiles** — view and edit personal data (phone, email, passport, attributes)
- 📋 **Staff directory** — filterable list of all employees by position
- 🔬 **Laboratory list** — manage laboratories and their assignments

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Language | C# |
| UI Framework | WPF (Windows Presentation Foundation) |
| Platform | .NET Framework 4.7.2 |
| Database | Microsoft SQL Server |
| Data Access | ADO.NET (SqlConnection, SqlDataAdapter, SqlCommand) |
| Config | App.config / ConnectionStrings |

## 🏗️ Architecture

The app uses a **Page-based navigation** pattern inside a single `MainWindow` with a shared `Frame`. Each role gets its own `Page` loaded after login.

```
AeroProd/
├── MainWindow.xaml(.cs)             # Shell window, shared Frame & navigation header
├── AuthPage.xaml(.cs)               # Login screen, role dispatch on successful auth
│
├── AdminPage.xaml(.cs)              # Administrator: manage users & staff (CRUD)
├── ForemanPage.xaml(.cs)            # Foreman: view brigade & zone assignments
├── StaffPage.xaml(.cs)              # Employee: personal dashboard
├── HeadWorkshopPage.xaml(.cs)       # Workshop head: workshop overview
├── HeadWorkShopareaPage.xaml(.cs)   # Workshop area head: areas, brigades, staff
├── TesterPage.xaml(.cs)             # Tester: submit & view test reports with files
│
├── BrigadesPage.xaml(.cs)           # Brigade details
├── StaffList.xaml(.cs)              # Filterable employee directory
├── WorkshopList.xaml(.cs)           # Workshop area management
├── LaboratoryList.xaml(.cs)         # Laboratory & target management
├── ProfilePage.xaml(.cs)            # Employee profile (editable for Admin)
│
└── App.config                       # DB connection string
```

## 👥 Access Levels

| Level | Role | Capabilities |
|---|---|---|
| 1 | Foreman (Бригадир) | View brigade and zone assignments |
| 2 | Administrator | Full user & staff CRUD, profile viewing |
| 3 | Employee (Сотрудник) | Personal area |
| 4 | Workshop Head (Начальник цеха) | Workshop overview |
| 5 | Workshop Area Head (Начальник участка) | Manage areas, brigades, staff assignments |
| 6 | Tester (Испытатель) | Submit and view test reports with file attachments |

## 🚀 Getting Started

### Prerequisites

- Windows OS
- Visual Studio 2019+ with .NET desktop development workload
- Microsoft SQL Server (any edition)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/AeroProd.git
   ```

2. Create the database in SQL Server Management Studio (database name: `AeroProd`).

3. Update the connection string in `App.config` to point to your SQL Server instance:
   ```xml
   <add name="DefaultConnection"
        connectionString="Data Source=YOUR_SERVER;Integrated Security=True;Initial Catalog=AeroProd;"
        providerName="System.Data.SqlClient"/>
   ```

4. Open `AeroProd.sln` in Visual Studio and run the project (F5).

### Database Schema (key tables)

- `Users` — login, password, staff reference, access level
- `Staff` — employee data (name, position, passport, phone, email)
- `Position` — job titles
- `Access_level` — role definitions
- `Brigade` — brigades with foreman and area references
- `Area_of_workshop` — work areas within workshops
- `Report` — tester reports with file paths and content
- `Laboratory` — labs with assigned targets

## 🔮 Roadmap

- [ ] Parameterized SQL queries (prevent SQL injection)
- [ ] Password hashing
- [ ] Export reports to PDF/Excel
- [ ] Search and pagination in data grids
- [ ] Audit log for admin actions

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

---

> Built with ❤️ using C#, WPF and ADO.NET
