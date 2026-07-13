# Coding Standards & Conventions

## Project Overview

Modern .NET 10 RAG application following Clean Architecture.

Tech stack:
- ASP.NET Core 10
- PostgreSQL + pgvector
- Entity Framework Core
- Angular (future)
- Ollama / Model-agnostic AI providers
- Docker (development)

Primary goals:
- Maintainability
- Testability
- Clear separation of concerns
- Feature-oriented organization
- AI provider independence

---

# Architecture

Follow Clean Architecture.

Projects:

- Domain
- Application
- Infrastructure
- Api

Dependencies:

Api
    ↓
Application
    ↓
Domain

Infrastructure depends on:
- Domain
- Application

Domain never depends on anything.

---

# General Principles

Prefer:

- SOLID
- DRY
- KISS
- Composition over inheritance
- Constructor injection
- Async throughout

Avoid:

- Static helper classes unless truly stateless
- Service locator
- Business logic in controllers
- Anemic architecture
- Large classes

---

# Naming

Classes:
- PascalCase

Methods:
- PascalCase

Properties:
- PascalCase

Interfaces:
- Prefix with I

Private fields:
- _camelCase

Parameters:
- camelCase

Local variables:
- camelCase

Constants:
- PascalCase

Avoid abbreviations unless universally understood.

---

# Folder Organization

Group by feature rather than type whenever practical.

Example:

Application

Features/
    Documents/
        Commands/
        Queries/
        DTOs/
        Validators/

Shared/
    Interfaces/
    Exceptions/

Infrastructure

Persistence/
    Configurations/
    Repositories/

AI/
    Embeddings/
    Chat/

Services/

---

# DTOs

DTOs belong with the feature that owns them.

Shared DTOs should live under:

Application/Shared/DTOs

Do not create one giant DTO folder.

---

# Repositories

Repositories belong in Infrastructure.

Interfaces belong in Application.

Repositories should:

- only access data
- never contain business logic
- never call AI services

---

# Entity Configuration

Use IEntityTypeConfiguration<T>.

Each entity gets its own configuration class.

Never configure entities directly inside DbContext.

---

# DbContext

Keep DbContext minimal.

Only:

- DbSets
- ApplyConfigurationsFromAssembly

No business logic.

---

# Dependency Injection

Register services through extension methods.

Example:

InfrastructureServiceCollectionExtensions

Avoid registering services inside Program.cs except for calling extension methods.

---

# API

Controllers should:

- Validate input
- Call Application layer
- Return appropriate responses

Controllers should not:

- Access DbContext
- Contain business logic
- Call Infrastructure directly

---

# Services

Business logic belongs in Application services.

Infrastructure services only interact with external systems:

Examples:

- Ollama
- OpenAI
- PostgreSQL
- File Storage

---

# AI Design

Remain model-agnostic.

Never tie the application to a specific provider.

Expose abstractions such as:

- IEmbeddingGenerator
- IChatCompletionService

Infrastructure provides implementations.

---

# Async

Use async/await everywhere.

Never block with:

.Result

.Wait()

---

# Exceptions

Throw domain/application exceptions when appropriate.

Do not swallow exceptions.

Use global exception handling.

---

# Logging

Use ILogger<T>.

Do not log sensitive information.

Prefer structured logging.

---

# Configuration

Use strongly typed Options.

Never hardcode:

- URLs
- API Keys
- Model names
- Database settings

---

# Entity Design

Entities should encapsulate behavior.

Avoid public setters unless necessary.

Use constructors where appropriate.

Prefer immutable value objects.

---

# Nullable Reference Types

Keep nullable reference types enabled.

Avoid null-forgiving operator (!) unless absolutely necessary.

---

# Comments

Prefer self-documenting code.

Comment only:

- non-obvious decisions
- important algorithms
- workarounds

Do not narrate obvious code.

---

# Code Style

Prefer:

Early returns.

Small methods.

Small classes.

Clear names.

Readable code over clever code.

---

# Dependency Rule

Business logic must never depend on:

- EF Core
- PostgreSQL
- Ollama
- OpenAI
- ASP.NET

Only abstractions.

---

# Current Project Decisions

Embedding provider:
- Ollama (default)
- Must remain replaceable

Vector database:
- PostgreSQL + pgvector

Embedding dimensions:
- Determined by the selected embedding model (never hardcode)

Persistence:
- Entity Framework Core

Architecture:
- Clean Architecture

Organization:
- Feature-first

Entity mapping:
- Separate IEntityTypeConfiguration classes

Dependency Injection:
- Extension methods

Repositories:
- Infrastructure

Repository interfaces:
- Application

DTOs:
- Feature-local unless shared

Controllers:
- Thin

Business logic:
- Application

Infrastructure:
- External integrations only