💧 Smart Water Billing System

A robust, enterprise-grade backend system built with .NET 10 following **Clean Architecture and CQRS pattern principles. The system handles complex water consumption billing, asynchronous processing, multi-channel invoice delivery, and secure identity management.

---

 🚀 Key Architectural Features

*   4-Layer Clean Architecture: Strict separation of concerns divided into `Domain`, `Application`, `Infrastructure`, and `API` layers.
*   CQRS Pattern: Implemented using MediatR for decoupled, maintainable, and high-performance Command and Query isolation.
*   Centralized Error Handling (RFC 7807): Custom `Result<T>` pattern coupled with a global problem mapping controller that automatically translates errors to standard Problem Details (e.g., `401 Unauthorized`, `400 BadRequest`).
  Domain Validation Pipeline: Requests are captured and validated seamlessly via FluentValidation wired into MediatR pipeline behaviors.

---

⚡ Core Business & Infrastructure Modules

1. High-Performance Billing Engine
*   Features an advanced dynamic engine to compute consumption based on multi-layered slab billing logic for multi-unit properties.
*   Utilizes high-concurrency, thread-safe sequence retrieval via raw database commands to guarantee gapless invoice numbering under heavy transaction spikes.

 2. Enterprise Security & Identity
*   Secured via ASP.NET Core Identity isolated into an autonomous DB Context.
*   Enforces strict identity constraints, unique system-wide emails (`RequireUniqueEmail`), and standard Bearer Token authentication.

 3. Background Processing & Automation
*   Powered by Hangfire to manage scalable background jobs, offloading heavy calculation routines and scheduled workflows seamlessly from the API main thread.

 4. Dynamic Reporting & Notification Routing
*   Integrates QuestPDF for generating high-fidelity, customized invoice PDFs on the fly.
*   Seamlessly integrated with the official Meta Cloud API (WhatsApp) to route generated invoice document links directly to subscribers.

---

 🛠️ Tech Stack & Tools

*   Backend Framework: .NET 10 (ASP.NET Core Web API)
*   Data Access & DB: Entity Framework Core (EF Core), MS SQL Server
*   Design Patterns: Repository & Unit of Work, Specification Pattern
*   Mapping & Validation: Mapster, FluentValidation
*   Third-Party Libraries: MediatR, Hangfire, QuestPDF, MailKit
*   Integrations: Meta Cloud API (WhatsApp Business API)
