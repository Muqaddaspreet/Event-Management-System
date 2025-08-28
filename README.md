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

# 🔐 Roles & Permissions

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
