# AppAgendaContactosApi

AppAgendaContactosApi es una API RESTful para gestionar una agenda de contactos. Esta API permite crear, leer, actualizar y eliminar contactos.

## Características

- Gestión completa de contactos (CRUD).
- Implementado con .NET 8.0 y Entity Framework Core.
- Base de datos SQL Server.

## Instalación

1. Clona este repositorio.
2. Abre la solución en Visual Studio.
3. Asegúrate de tener instalado .NET 8.0 y SQL Server.
4. Actualiza la cadena de conexión en `appsettings.json` con tus propios detalles de SQL Server.
5. Ejecuta las migraciones para crear la base de datos con `Update-Database` en la consola del administrador de paquetes.
6. Ejecuta la aplicación.

## Uso

Puedes usar herramientas como [Postman](https://www.postman.com/) o [curl](https://curl.se/) para hacer solicitudes a la API.

### Endpoints

- `GET /api/contactos`: Obtiene todos los contactos.
- `GET /api/contactos/{id}`: Obtiene un contacto por su ID.
- `POST /api/contactos`: Crea un nuevo contacto.
- `PUT /api/contactos/{id}`: Actualiza un contacto existente.
- `DELETE /api/contactos/{id}`: Elimina un contacto.

## Pruebas

Este proyecto incluye pruebas unitarias. Puedes ejecutarlas en Visual Studio seleccionando "Prueba" -> "Ejecutar todas las pruebas".

## Contribución

Las contribuciones son bienvenidas. Por favor, abre un issue para discutir lo que te gustaría cambiar.

## Licencia

[MIT](https://choosealicense.com/licenses/mit/)
