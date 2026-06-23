# DepoFlow.Auth

## Descripción

`DepoFlow.Auth` es un microservicio de autenticación y autorización dentro del ecosistema DepoFlow. Está construido con .NET 9 y sigue una arquitectura limpia (Clean Architecture) con capas separadas de API, Application, Domain e Infrastructure.

## Estado actual

- API:
- Infraestructura: configuración de Entity Framework Core con SQL Server y mapeo de entidades.
- Dominio: modelo para usuarios, roles, permisos, refresh tokens y relaciones RBAC.
- Application: capa de abstracciones lista para casos de uso, con dependencia de `MediatR.Contracts`.

> Nota: aún no hay controladores ni middleware de autenticación/autorizarión completos implementados en el API.

## Estructura del repositorio

- `src/DepoFlow.Auth.Api/`
  - Proyecto Web API principal.
  - `Program.cs` expone el endpoint de prueba.
  - Referencia los proyectos `Application`, `Domain` e `Infrastructure`.

- `src/DepoFlow.Auth.Application/`
  - Capa de aplicación con abstracciones para casos de uso.
  - Dependencia en `MediatR.Contracts`.

- `src/DepoFlow.Auth.Domain/`
  - Entidades de dominio y agregados.
  - Abstracciones para entidades, eventos de dominio y unidad de trabajo.

- `src/DepoFlow.Auth.Infrastructure/`
  - `ApplicationDbContext` con EF Core.
  - Configuraciones de entidad para `User`, `Role`, `Permission`, `RefreshTokens`, `UserRole`, `RolePermissions`, `Modules`.
  - Registración de servicios `AddInfrastructure`.

## Modelo de dominio principal

- `User`: usuario del sistema con `UserName`, `FirstName`, `LastName`, `Email`, `PasswordHash` y estado activo.
- `Role`: rol de acceso con nombre, descripción y estado.
- `AccessPermissions`: permisos de acceso asociados a módulos y acciones.
- `RefreshTokens`: token de renovación con expiración y posible revocación.
- `UserRole`: relación muchos-a-muchos entre usuarios y roles.
- `RolePermissions`: relación muchos-a-muchos entre rolra de módulos para agrupar permisoses y permisos.
- `Modules`: estructu.

## Dependencias clave

Centralizadas en `Directory.Packages.props`:

- `Microsoft.AspNetCore.OpenApi` 9.0.15
- `Microsoft.EntityFrameworkCore` 9.0.16
- `Microsoft.EntityFrameworkCore.SqlServer` 9.0.16
- `Microsoft.EntityFrameworkCore.Design` 9.0.16
- `Microsoft.EntityFrameworkCore.Tools` 9.0.16
- `Newtonsoft.Json` 13.0.4
- `MediatR.Contracts` 2.0.1

## Requisitos

- .NET 9 SDK
- SQL Server (o cadena de conexión compatible con SQL Server)

## Ejecución local

1. Restaurar paquetes y compilar:

```bash
dotnet restore DepoFlow.Auth.sln
dotnet build DepoFlow.Auth.sln
```

2. Configurar la cadena de conexión en `src/DepoFlow.Auth.Api/appsettings.json` o en variables de entorno:

```json
{
  "ConnectionStrings": {
    "DBDepoFlow": "Server=localhost;Database=DepoFlowAuth;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

3. Ejecutar la API:

```bash
dotnet run --project src/DepoFlow.Auth.Api/DepoFlow.Auth.Api.csproj
```

## Documentación adicional

- `docs/architecture.md`: descripción arquitectónica del servicio.
- `docs/requirements.md`: requerimientos funcionales y no funcionales.

