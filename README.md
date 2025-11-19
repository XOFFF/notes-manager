# Notes Manager

Notes Manager is a web application for managing notes, built with **ASP.NET MVC**.

![Screenshot of Notes Manager](https://media.licdn.com/dms/image/v2/D4D22AQEF-VvPOw4qTg/feedshare-shrink_2048_1536/B4DZqbszNSJIAw-/0/1763548804452?e=1765411200&v=beta&t=Ox_MQXJa5P9QgKp6HtnAfJeGDVATbm9ANRjN25Bs37M)

---

## Technology Stack

- **Backend:** ASP.NET MVC, C#, Entity Framework Core  
- **Frontend:** Razor Pages, Bootstrap  
- **Database:** PostgreSQL  
- **Containerization:** Docker  
- **IDE:** Microsoft Visual Studio

---

## Features

- Create, edit, and delete notes  
- View a list of notes and details for each note  
- Server-side data validation  
- Implements standard MVC patterns and server-side logic

---

## Project Structure

- **Controllers/** — handles application requests and business logic  
- **Models/** — data models and database mappings  
- **Views/** — Razor templates for UI rendering  
- **wwwroot/** — static files (CSS, JS, Bootstrap libraries)  

---

## Usage

### 1. Clone the repository

```bash
git clone https://github.com/XOFFF/notes-manager.git
cd notes-manager
```

### 2. Database Setup

This project uses **Entity Framework Core migrations** to create database tables.

#### Using Docker

1. Make sure PostgreSQL is running in Docker. Example `docker-compose.yml`:

```yaml
version: '3.8'

services:
  db:
    image: postgres:15
    environment:
      POSTGRES_USER: postgres
      POSTGRES_PASSWORD: your_password
      POSTGRES_DB: NotesManager
    ports:
      - "5432:5432"
    volumes:
      - db-data:/var/lib/postgresql/data

volumes:
  db-data:
```

2. Start the PostgreSQL container:

```bash
docker-compose up -d
```

3. Apply EF Core migrations to create tables:

```bash
dotnet ef database update
```

### 3. Running the Project

1. Open the project in **Microsoft Visual Studio**.  
2. Start the application using **IIS Express** or **Docker**.  
3. Open your browser and go to `http://localhost:{port}`.

---

## Notes

Controller actions like:

```csharp
return RedirectToAction("Index", new { id = model.Id });
```

- This is **not considered a Web API**.  
- It’s standard **MVC action navigation**.  
- If later you add `[ApiController]` methods returning JSON, that would be **ASP.NET Web API**.
