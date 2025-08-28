# 📚 Event Portal

A role-based event management web app for organizing and discovering book-reading events. Admins and Users can register, sign in, create/edit events, and browse past/future sessions. Creators can optionally send **special invitations** to select users.

---

## ✨ Features

### 👩‍💼 Admin
- **Register & Login**
- **Create Event** — Title, Date, Location, Start Time, Type, Duration, Description, Optional Details, and **special invitations**.
- **Edit Future Events** — Can edit **all future events** (own + other users’).
- **View Event Details** — Full details for any event.
- **View All Events** — Card-based lists with **Past** and **Future** tabs (own + users’).

### 👤 User
- **Register & Login**
- **Create Event** — Same fields as Admin, including **special invitations**.
- **Edit Future Events** — Can edit events **they created**.
- **View Event Details** — For own events and admin-created events.
- **View All Events** — Card-based **Past** and **Future** tabs (own + admin).
- **Invited Events** — Separate list of events where the user received a **special invitation**.

---

## 🧱 Tech Stack

- **Backend:** ASP.NET (MVC) · C#
- **Web App:** ASP.NET MVC Views / Razor
- **Auth:** Cookie / Forms Auth with a custom authorization filter (`CustomAuthFilter.cs`)
- **Logging:** NLog (see `PlugIn/BookReadingEvent.Logging.NLog`)
- **Data:** SQL Server (typical setup); repository/service pattern in `Business` / `Foundation`
- **Build:** Visual Studio / `dotnet` CLI
- **Containerization:** `.dockerignore` included (add a `Dockerfile` to containerize)

---

## 🗂️ Solution Structure

```text
BookReadingEvent.sln
├─ Business/
│  └─ ProductDomain/
│     └─ BookReadingEvent.*          # Domain entities, services, repositories
├─ Foundation/                       # Cross-cutting abstractions / base classes
├─ Lib/                              # Shared libraries / helpers
├─ PlugIn/
│  └─ BookReadingEvent.Logging.NLog/ # NLog config & adapters
├─ Web/
│  └─ BookReadingEvent.Web/          # ASP.NET MVC web project (controllers, views)
├─ CustomAuthFilter.cs               # Custom authorization filter attribute
├─ .dockerignore
├─ README.md
└─ (optional) Database scripts / seeders

```

## 🚀 Getting Started

### Prerequisites
- **.NET SDK** (matching the project target; e.g., .NET 6 or classic .NET Framework via VS)
- **SQL Server** / **LocalDB**
- **Visual Studio** or `dotnet` CLI

### 1) Configure Database & App Settings
Create or update `appsettings.json` (or `Web.config` for classic MVC) in `Web/BookReadingEvent.Web`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=BookReadingEvent;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Logging": {
    "Provider": "NLog"
  },
  "Auth": {
    "CookieName": ".BookReadingEvent.Auth",
    "LoginPath": "/Account/Login"
  }
}
```

## 🔐 Roles & Permissions

| Capability                      | Admin | User |
|---------------------------------|:-----:|:----:|
| Register / Login                |  ✅   |  ✅  |
| Create event                    |  ✅   |  ✅  |
| Edit own future events          |  ✅   |  ✅  |
| Edit others’ future events      |  ✅   |  ❌  |
| View event details (own/admin)  |  ✅   |  ✅  |
| View all events (past/future)   |  ✅   |  ✅  |
| See invited-only events         |  ✅   |  ✅  |
| Send special invitations        |  ✅   |  ✅  |

---

## 🚀 Getting Started

### Prerequisites
- **.NET SDK** (matching the project target; e.g., .NET 6 or classic .NET Framework via VS)
- **SQL Server** / **LocalDB**
- **Visual Studio** or `dotnet` CLI

### 1) Configure Database & App Settings
Create/update `appsettings.json` (or `Web.config` for classic MVC) in `Web/BookReadingEvent.Web`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=BookReadingEvent;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Logging": {
    "Provider": "NLog"
  },
  "Auth": {
    "CookieName": ".BookReadingEvent.Auth",
    "LoginPath": "/Account/Login"
  }
}
```

For classic **Web.config**, add/update a `<connectionStrings>` entry and configure the auth cookie settings.

### 2) Restore & Build
```bash
# From solution root
dotnet restore
dotnet build
# Or open BookReadingEvent.sln in Visual Studio and Build
```

### 3) Apply Migrations / Create DB
If the project includes EF migrations, run them; otherwise create the schema via scripts.

```bash
# Example (if EF Core is used)
dotnet ef database update --project Web/BookReadingEvent.Web
```

### 4) Run
```bash
# Using CLI
dotnet run --project Web/BookReadingEvent.Web
# Then open the printed URL (e.g., https://localhost:5001/)
```

---

## 🗓️ Events Model (Typical)

- **Core Fields:** Title, Date, Location, Start Time, Type, Duration, Description, Optional Details  
- **Visibility:** General (visible to all) + **Special invitations** to selected users  
- **Ownership:** Creator can edit **future** events; Admin can edit **any** **future** event  

---

## 🪵 Logging

- NLog lives under `PlugIn/BookReadingEvent.Logging.NLog`.  
- Typical logs: request traces, errors, audits, and admin/user actions. 
- Configure targets (file/console/db) in `NLog.config`.

---

## 🧪 Testing (suggested)

- Controllers: authentication, event CRUD, invitation rules  
- Services: ownership checks, filters (past/future)  
- Filters: `CustomAuthFilter` behavior  
- Data access: repositories and integration tests  

---

## 🧭 Roadmap

- Event reminders (email/notifications)  
- iCal export / calendar integration  
- Full-text search and filters (type, date range, location)  
- Attachments and rich descriptions  
- Dockerfile + CI/CD pipeline  
- Public REST API endpoints for mobile/SPA  
