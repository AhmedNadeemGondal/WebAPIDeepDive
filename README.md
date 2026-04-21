# WebAPIDeepDive

## Purpose
This repository serves as a comprehensive foundational resource for building robust **RESTful Web APIs** using the **Controller-based architecture** in **ASP.NET Core**. It focuses on the traditional MVC pattern, demonstrating how to organize logic into dedicated controllers while maintaining clean separation of concerns.

## Core Pillars

### 1. Controller-Based Architecture
The project utilizes the standard `ControllerBase` pattern to manage API endpoints:
* **Resource Grouping:** Logic is logically partitioned within the `Controllers/` directory (e.g., `EmployeesController.cs`).
* **Inheritance:** Leveraging `ControllerBase` for built-in helper methods like `Ok()`, `NotFound()`, and `BadRequest()`.
* **Action Results:** Implementation of various return types to handle complex HTTP response scenarios.

### 2. Routing & Attribute Mapping
Explores how the routing engine maps URLs to controller actions:
* **Class-Level Routing:** Using `[Route("api/[controller]")]` for standardized URI structures.
* **HTTP Verb Attributes:** Explicitly defining actions with `[HttpGet]`, `[HttpPost]`, `[HttpPut]`, and `[HttpDelete]`.
* **Parameter Binding:** Demonstrating how the framework maps route data and query strings directly to action method parameters.

### 3. Dependency Injection (DI) in Controllers
Demonstrates constructor injection to provide services to controllers:
* **Service Lifetimes:** Managing `Transient`, `Scoped`, and `Singleton` services within the API context.
* **In-Memory Repositories:** Using DI to swap data persistence layers seamlessly.

### 4. API Documentation & Testing
* **Status Code Management:** Ensuring proper RESTful responses (e.g., `201 Created` for successful POST requests).

## Implementation Highlights
* **Traditional MVC Pipeline:** A deep dive into how controllers sit within the middleware pipeline.
* **Model Validation:** Using Data Annotations within the controller actions to filter incoming requests.

### Credits
Credit to **Frank Liu**. Check out his [video series](https://www.youtube.com/watch?v=F4dDe0SLjJM&list=PLgRlicSxjeMOXiYY7deqzO5qKdkg9wrqM&index=1&pp=iAQB) for the original walkthrough.