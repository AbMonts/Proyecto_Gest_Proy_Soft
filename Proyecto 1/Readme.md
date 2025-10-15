# Notify

**Notify** es una aplicación de escritorio desarrollada en **C# con .NET**, pensada para centralizar notificaciones dentro de una organización. Permite a los usuarios recibir información filtrada según sus preferencias mediante un sistema de secciones configurables.

## Características principales

- Gestión de usuarios y administradores
- Creación y envío de notificaciones
- Filtro de notificaciones por **remitente**, **prioridad** o **tema**
- Organización de usuarios en grupos
- Configuración de secciones personalizadas por usuario

## Arquitectura del sistema

El sistema está diseñado en una arquitectura en capas:
- **Presentación:** interfaz gráfica desarrollada con Windows Forms/WPF.
- **Lógica de negocio:** maneja reglas, permisos y filtrado de notificaciones.
- **Acceso a datos:** gestiona la conexión y operaciones sobre la base de datos relacional.

## Requisitos

- .NET Framework 4.7.2 o superior / .NET 6.0 (según versión del proyecto)
- Visual Studio 2022 o superior
- MySQL

## Instalación

1. Clona este repositorio:
git clone https://github.com/Nope79/notifaicuatrow

2. Abre la solución en Visual Studio.
3. Configura la cadena de conexión a la base de datos en BackEnd/Conexion.css
4. Compila y ejecuta el proyecto.

## Uso

1. Inicia sesión como usuario o administrador.
2. Como **usuario**, puedes:
- Revisar tus notificaciones
- Configurar secciones personalizadas
- Entrar a un grupo con un código de grupo
3. Como **administrador**, puedes:
- Crear y enviar notificaciones
- Administrar usuarios, grupos y secciones

## Licencia

me vale verga w haz lo que quieras pero no me demandes.

## Autor

Desarrollado por [Nope79].