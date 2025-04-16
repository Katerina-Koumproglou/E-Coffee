# Online Website for a Coffee Shop

This is my first full-stack e-commerce website built with **Vue.js (JavaScript, CSS, HTML)** on the frontend, **ASP .NET Core (C#)** on the backend and a **PostgreSQL** database for a group university project.
It has a couple of different features such as it lets users browse the available products, register/login with their account as well as manage their own cart.
Try it for yourselves here :) [E-Coffee](http://ecoffee.dns.army/)

---

## Features

### Authentication & Authorization
- JWT-based login and signup
- Role-based access: `user` and `admin`
- Login token persisted in localStorage
- Auth-protected frontend routes
- Backend route protection via `[Authorize]` attributes

### E-commerce Functionality
- Product listing (public)
- Product detail pages
- Add new users via signup
- View all users (only accessible by admin)
- Mobile responsive design for the majority of the project (best viewed on desktop)

### Frontend (Vue.js)
- Product listing UI
- User registration & login
- Token-based authentication (JWT)
- Axios integration for API calls
- Responsive design

### Backend (ASP.NET Core)
- RESTful API with C#
- PostgreSQL database integration using Entity Framework Core
- User authentication (JWT)
- Swagger documentation
- Organized service-based architecture (Dependency Injection)

---

## Technologies Used

| Frontend        | Backend             | Database             |
|-----------------|---------------------|----------------------|
| Vue 3 + Vite    | ASP.NET Core 7.0    | PostgreSQL           |
| Axios           | Entity Framework    | pgAdmin (not needed) |
| Vue Router      | JWT Auth            |                      |
|                 | Swagger (API docs)  |                      |
