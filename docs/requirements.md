# DepoFlow.Auth — Especificación de Requerimientos

---

## 1. 🎯 Propósito del sistema

El microservicio **DepoFlow.Auth** es responsable de la autenticación y autorización dentro del ecosistema DepoFlow.

Su objetivo es centralizar la gestión de identidad, control de acceso y seguridad mediante JWT, roles y permisos.

---

## 2. 🧩 Alcance del sistema

### ✅ Incluye

- Autenticación de usuarios (login/logout)
- Emisión de JWT
- Refresh tokens
- Gestión de usuarios
- Gestión de roles
- Gestión de permisos
- Asignación de roles a usuarios
- Asignación de permisos a roles
- Validación de autorización basada en RBAC

---

### ❌ No incluye

- Ventas del sistema
- Inventario
- Clientes del negocio
- Reportes de negocio
- Operaciones de caja o pagos

---

## 3. 👥 Actores del sistema

| Actor | Descripción |
|------|-------------|
| Administrador | Gestiona usuarios, roles y permisos |
| Usuario del sistema | Accede a recursos según permisos |
| Otros microservicios | Validan tokens y permisos |

---

## 4. ⚙️ Requerimientos funcionales

---

### 🔐 Autenticación

- RF01: El sistema debe permitir autenticación mediante email y contraseña.
- RF02: El sistema debe generar un JWT válido al iniciar sesión correctamente.
- RF03: El sistema debe permitir renovar sesión mediante refresh token.
- RF04: El sistema debe permitir cerrar sesión invalidando el refresh token.

---

### 👤 Gestión de usuarios

- RF05: El sistema debe permitir crear usuarios.
- RF06: El sistema debe permitir consultar usuarios.
- RF07: El sistema debe permitir actualizar usuarios.
- RF08: El sistema debe permitir desactivar usuarios.
- RF09: El sistema debe permitir asignar roles a usuarios.

---

### 🧑‍💼 Gestión de roles

- RF10: El sistema debe permitir crear roles.
- RF11: El sistema debe permitir editar roles.
- RF12: El sistema debe permitir eliminar roles.
- RF13: El sistema debe permitir asignar permisos a roles.
- RF14: El sistema debe listar roles disponibles.

---

### 🔑 Gestión de permisos

- RF15: El sistema debe permitir crear permisos.
- RF16: El sistema debe permitir listar permisos.
- RF17: El sistema debe permitir asociar permisos a roles.

---

### 🔒 Autorización

- RF18: El sistema debe validar permisos antes de autorizar el acceso a recursos.
- RF19: El sistema debe exponer permisos del usuario autenticado.
- RF20: El sistema debe restringir acceso basado en roles y permisos.

---

### 🔄 Tokens

- RF21: El sistema debe emitir JWT con información básica del usuario.
- RF22: El sistema debe manejar refresh tokens de forma segura.
- RF23: El sistema debe invalidar tokens en logout o expiración.
- RF24: El sistema debe soportar expiración configurable de tokens.

---

## 5. 🚀 Requerimientos no funcionales

---

### 🔐 Seguridad

- RNF01: Las contraseñas deben almacenarse con hashing seguro (BCrypt o equivalente).
- RNF02: JWT debe tener expiración configurada.
- RNF03: El sistema debe validar autenticación en todos los endpoints protegidos.
- RNF04: Debe implementarse control de acceso basado en roles (RBAC).
- RNF05: Debe protegerse contra ataques comunes (OWASP Top 10).

---

### ⚡ Rendimiento

- RNF06: El login debe responder en menos de 300ms bajo carga normal.
- RNF07: Las consultas de permisos deben estar optimizadas.

---

### 📈 Escalabilidad

- RNF08: El sistema debe permitir escalamiento horizontal.
- RNF09: La arquitectura debe ser desacoplada y modular (Clean Architecture).

---

### 🧱 Mantenibilidad

- RNF10: El sistema debe usar Clean Architecture.
- RNF11: Debe implementarse CQRS con MediatR.
- RNF12: La lógica de negocio debe estar separada de infraestructura.

---

### 📊 Auditoría

- RNF13: El sistema debe registrar eventos críticos (login, creación de usuarios, cambios de roles).
- RNF14: Debe existir trazabilidad de acciones administrativas.

---

### 🔄 Disponibilidad

- RNF15: El sistema debe manejar fallos de base de datos con reintentos.
- RNF16: El sistema debe ser tolerante a fallos de red entre servicios.

---

## 6. 📜 Reglas de negocio

---

- BR01: Un usuario puede tener múltiples roles.
- BR02: Un rol puede tener múltiples permisos.
- BR03: Los permisos son la fuente final de autorización.
- BR04: Un usuario inactivo no puede autenticarse.
- BR05: Los tokens expirados no son válidos.
- BR06: Los permisos no deben estar hardcodeados.
- BR07: Toda autorización debe validarse en backend.
- BR08: El acceso a recursos depende de permisos, no solo roles.

---

## 7. 🧭 Suposiciones

- El sistema será usado por una aplicación tipo POS/administrativa.
- Habrá múltiples usuarios concurrentes.
- Otros microservicios dependerán del Auth Service.
- Se utilizará JWT como mecanismo principal de autenticación.

---

## 8. 📌 Criterios de éxito

El sistema será considerado exitoso si:

- Un usuario puede autenticarse correctamente.
- Se generan JWT válidos y seguros.
- Se controla acceso mediante roles/permisos.
- Los endpoints están protegidos.
- El sistema puede integrarse con otros microservicios.

---

## 9. 🧠 Decisiones arquitectónicas

- Se utilizará Clean Architecture
- Se implementará CQRS con MediatR
- Se usará JWT para autenticación
- Se aplicará RBAC (Roles + Permissions)
- La base de datos será relacional (PostgreSQL recomendado)
- El servicio será independiente y escalable