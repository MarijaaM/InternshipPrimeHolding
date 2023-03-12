# InternshipPrimeHolding

## Used technologies
- Backend - ASP.NET 6
- Frontend - Angular
- Database - SQLite (Entity framework for database access)
  
## Startup guide

### Backend


- Run project: Server

Server app will be started on https://localhost:7124/  

You can use *Swagger* for testing Server app (https://localhost:7124/swagger). 

### Frontend
Run command promt in folder *\ClientApp*.

Run next commands:
- *npm install* 
- *ng serve* 

In the browser open http://localhost:4200/ to see the application run.

## Software Architecture

### Backend

The server-side application is developed by using three-layer architecture. It implies: controller layer, service layer and data layer. 

Project *DataAccess* contains operations for database access (Repository pattern). 

Project *Model* contains classes that represent the data in the application. 

*Server* is main project and it contains controllers, services, interfaces, etc. 

### Frontend

The client-side application contains components, models and services. 

Components are UI building blocks.

Services are used for communication with server-side application.

## Additional functionalities

### Additional entities

*Project* is added as new entity. It contains: name, description, client name and list of tasks. It represents totality which is composed of tasks in practice.

Every task must be in one project. 

In the user interface, you can add tasks only as tasks of a specific project.

Every task has implemented state tracking. Available states are: ToDo, InProgress, InQA and Done. 

### Statistics

The application contains a *Statistics* section where it shows the comparison number of tasks of every state in last 12 months.

It is good to know how the dynamics of solving the tasks went.

