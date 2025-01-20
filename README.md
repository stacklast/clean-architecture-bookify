# Bookify

This project applies the Pragmatic Clean Architecture through a Booking Application .Net 8

## Domain Layer

- Domain Model
  - Entities
  - Value Objects
- Domain Events
- Domain Services
- Interfaces
- Exceptions
- Enums

---

## Application Layer

- Use Cases = CQRS + MediatR
  - Single Responsability Pattern
  - Interface Segregation Pinciple
  - Decorator Pattern
  - Loose Coupling
- Cross-cutting concerns
  - Logging
  - Validation
- Exceptions
- DI Configuration

---

## Infrastructure Layer

- EF Core
  - DbContext
  - Entity Configurations
  - Repositories
- Optimistic Concurrency
- Publishing Domain Events

### Authentication

- External Identity Provider
- Keycloak
  - JWT Bearer auth
- .NET Integration

#### Authorization

- Roles authorization
- Permissions auhtorization
- Resource-based authorization

---

## Presentation Layer

- Web API, .NET 8
- Controllers
- Middleware
- DI Setup
- Docker Compose

---

## Advanced Topics

- Structured logging
- Distributed caching
- Health Checks
- API Versioning
- Background Jobs
  - Outbox Pattern
- Minimal APIs

## Testing xUnit

What Should we test?

- Unit Testing for Application Core
  - Domain
  - Application
- Integration Test
- Functional Test
- Architecture Test
