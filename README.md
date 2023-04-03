#  LibraryTravelProject - Prueba Técnica de ingreso a Browser Travel

# Objetivo

Microservicio para ver los libros y detalles por libro

En esta versión, se implementa microservicio con API expuesta para ver los libros y detalles por libro de acuerdo a un MER

La respuesta permite visualizar todos los Libros y detalles de cada libro (ISBN, Titulo, NombreAutor, ApellidoAutor, Editorial, sinopsis, n_paginas)

# Proceso de instalación

1. Clonacion proyecto GitHub
2. Creacion de Base de Datos: 
   * Crear BD: BrowserTravel en SQL Server Management Studio
   * Pararse en la BD creada y ejecutar el script de creacion de Tablas ubicado en: LibraryTravelProject/Base de datos/Tablas.sql
   * Poblar con datos Fake las tablas creadas anteriormente, el script se ubica: LibraryTravelProject/Base de datos/Insercion datos Fake Tablas.sql
   

# Implementación realizada
1. Base de datos con tablas pobladas de acuerdo al MER
2. Microservicio en .Net Core 6 con capa se servicio (API), capa de aplicacion (CQRS), capa de dominio (interfaces y servicio), capa de infraestructura (finder -
persistencia a la base de datos SQL), capa transversal (Entidades y utilitario)

Estructura del Microservicio:
   * Arquitecrura Hexagonal 
   * Manejo DDD (Domain Driven Design) 
   * Inyección de dependencias (Principio SOLID)
   * MediatR para ejecución de query (CQRS)
   * Manejo de Entity FrameworkCore 
   * Logs para excepcion de errores con SeriLog
   * Logs de aplicación con Microsoft.Extensions.Logging
   * Implementación de pruebas unitarias con XUnit

   
En la capa API existe una clase BasicAuthenticationHandler.cs que se encarga de controlar la seguridad del endpoint por medio autenticacion basica
Username: user
Password: password
Para probar la API desde Postman se debe en Autorizacion escoger Basic Auth y establecer las credenciales anteriores

Ejemplo endpoint: https://localhost:7155/api/LibraryTravel

En appsettings del microservicio establecer ruta de conexion a la base de datos local para la prueba
