# Home.Api

Home.Api es una API RESTful para la gestión de tarjetas de crédito, pagos y compras en el hogar. Incluye autenticación, validaciones, mapeo de DTOs, filtros y documentación Swagger.

## Características
- Gestión de tarjetas de crédito
- Registro y consulta de pagos
- Registro y consulta de compras
- Validaciones automáticas
- Filtros y búsquedas avanzadas
- Documentación interactiva con Swagger

## Estructura del Proyecto
- **Controllers/**: Controladores de la API
- **DTOs/**: Objetos de transferencia de datos
- **Filters/**: Filtros para búsquedas y consultas
- **MappingServices/**: Servicios de mapeo entre entidades y DTOs
- **Repositories/**: Acceso a datos y lógica de persistencia
- **Services/**: Lógica de negocio
- **Validators/**: Validaciones de entrada
- **Migrations/**: Migraciones de base de datos

## Requisitos
- .NET 8 o superior
- SQL Server (o base de datos compatible)

## Configuración
1. Clona el repositorio
2. Configura la cadena de conexión en `appsettings.json`
3. Ejecuta las migraciones de Entity Framework
4. Inicia la API

## Ejecución
```bash
dotnet run --project Home.Api/Home.Api.csproj
```

## Pruebas
```bash
dotnet test Home.Api.UnitTest/Home.Api.UnitTest.csproj
```

## Documentación
Accede a la documentación Swagger en `/swagger` una vez iniciada la API.

## Licencia
MIT