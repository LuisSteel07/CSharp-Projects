# TODO List

Este mini-proyecto trata sobre la creación de un mini administrador de Tareas, donde podremos crear nuestras tareas en un usuario que crearemos al inicio. 

Cada usuario tendrá su lista de tareas, para cada inicio del programa preguntará por usuario y contraseña para tener acceso al usuario correspondiente y realizar las operaciones CRUD con las tareas.

## Módulos empleados
En este proyecto se hace uso de el modulo **System.Data.SQLite** el cual permite la conexión con la DB de Sqlite.

## Estructura de la Tabla de la Base de Datos

### Tabla Usuario

|Campo      |Tipo   |
|-----------|-------|
|id         |Integer|
|name       |Text   |
|password   |Text   |

### Tabla Tarea

|Campo      |Tipo   |
|-----------|-------|
|id         |Integer|
|title      |Text   |
|description|Text   |
|category   |Text   |
|owner      |Integer|