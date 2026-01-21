# Backend Simulator (.NET)

This project is a **console-based backend simulator** built in C# using **Clean Architecture principles**.

The purpose of this project is to model how a real-world .NET backend is structured and developed, without relying on HTTP, UI frameworks, or databases in the early stages.

This codebase is intended to serve as a **foundation** for future ASP.NET Core, Blazor, and .NET MAUI applications.

---

## Goals

	- Apply Clean Architecture in a real project
	- Practice dependency inversion and dependency injection
	- Separate domain logic from infrastructure concerns
	- Build testable, maintainable backend code
	- Gradually evolve this project into a web and mobile backend

---

## Architecture Overview

This solution is organized into four projects:

1. BackendSimulator.Console       - Application entry point
2. BackendSimulator.Application   - Use cases and interfaces
3. BackendSimulator.Domain        - Core domain entities
4. BackendSimulator.Infrastructure - Infrastructure implementations

---

## Dependency Flow

	- Console -> Application -> Domain
	- Infrastructure -> Application -> Domain
	- Domain has **no dependencies**

---

## Current State

	- Clean solution and project structure
	- Dependency Injection configured
	- Logging configured using Microsoft.Extensions.Logging
	- Initial domain entity created
	- In-memory repository implementation

_No business logic or features have been implemented yet._

## Roadmap

Planned next steps:

	- Application services (use cases)
	- Console-based interaction layer
	- Domain validation rules
	- Unit and integration tests
	- Replace in-memory storage with a database
	- Expose backend via ASP.NET Core Web API
	- Deploy to Azure

---

## Tech Stack

	- .NET 10
	- C# 14
	- Microsoft.Extensions.DependencyInjection 10.0.2
	- Microsoft.Extensions.Logging 10.0.2

---

## Notes

This project is being built incrementally with a focus on correctness, architecture, and testability over speed or UI features.