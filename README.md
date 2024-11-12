# TPI Tecnologías de Desarrollo de Software IDE 2024 - Sistema Academia

## Introduccion

Este proyecto es un sistema de gestión de actividades de una academia, desarrollado para administrar roles y operaciones de administradores, estudiantes y, próximamente, profesores. La plataforma permite a los administradores gestionar el contenido académico, como las especialidades, planes de estudios y comisiones. Cada plan de estudios cuenta con varias materias, y los administradores pueden crear "cursados" asignando una comisión y asignatura, además de vincular a los docentes con cada cursado. Los estudiantes, por su parte, pueden consultar e inscribirse en los “cursados” disponibles según su plan de estudios.

## Requisitos

El sistema fue desarrollado con NET 8 y Visual Studio 2022. La versión de SQL Server es 19.3.

## Configuracion

Para ejecutar la version pre-realse es necesario abrir la solucion Api-Academia.sln y luego ejecutar el proyecto de vista (Windows Forms o Blazor).

## Arquitectura del sistema

La solución cuenta con cinco proyectos:

- ApplicationCore (Class Library)
- API (ASP.NET)
- ClientService (Class Library)
- UI.Desktop (Windows Form)
- UI.Web (Blazor)

El flujo de comunicaciones consta de comunicación de los proyectos de vista (UI.Desktop,UI.Web) con el proyecto ClientService, encargado de realizar las peticiones a API.

API se comunica con ApplicationCore que se encarga de realizar las operaciones en persistencia.

## Modelos y entidades

Diagrama de base de datos generado con la herramienta Database Diagram de SQL SERVER.

[diagrama base de datos](assets/20241112_100057_Imagen1.png)

## API y endpoints

## Licencia
