# DepoFlow.Auth — Documento de Arquitectura

---

## 1. 🧭 Visión general

**DepoFlow.Auth** es un microservicio encargado de la gestión de identidad y acceso dentro del ecosistema DepoFlow.

Se encarga de:

- Autenticación de usuarios (JWT)
- Autorización basada en roles y permisos (RBAC)
- Gestión de usuarios
- Ciclo de vida de tokens (JWT + Refresh Tokens)

---

## 2. 🧱 Estilo de arquitectura

El servicio sigue:

- Clean Architecture
- CQRS (Separación de comandos y consultas)
- MediatR para el manejo de casos de uso
- Enfoque ligero de Domain-Driven Design (DDD)

---

## 3. 🏗️ Arquitectura del servicio

El servicio sigue una arquitectura basada en capas (Clean Architecture), separando responsabilidades para mejorar mantenibilidad, escalabilidad y testabilidad.

El sistema se organiza en las siguientes capas:

- API (Presentación)
- Application (Casos de uso)
- Domain (Reglas de negocio)
- Infrastructure (Persistencia y servicios externos)