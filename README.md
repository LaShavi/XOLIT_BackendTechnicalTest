# Proyecto: XOLIT_BackendTechnicalTest (Sistema de Reservas de Espacios Compartidos)

## Descripción
Prueba técnica para el Backend
Este proyecto es una API desarrollada en .NET 8 para la gestión de reservas de espacios compartidos.

---

## Requisitos Previos
- Visual Studio 2022 o superior.
- .NET SDK 8.
- SQL Server 2019 o superior.
- Postman (opcional, para pruebas de los endpoints).

---

## Configuración del Proyecto

### Clonar el Repositorio
1. Clona el repositorio

### Configuración de la Base de Datos
1. Abre SQL Server Management Studio (SSMS).
2. Ejecuta los scripts para crear la base de datos, tablas y datos iniciales. Los scripts se encuentran en la carpeta:
   ```
   /Varios/Scripts/
   ```
   Ejecutar los archivos en el siguiente orden:
   - `1. ScriptCreateTable.sql`
   - `2. Insert Data.sql`

### Configuración de la Cadena de Conexión
1. En el archivo `appsettings.json` del proyecto `XOLITSharedSpacesTEST.Api`, actualiza la cadena de conexión para que apunte a tu servidor SQL Server:
   ```json
   "ConnectionStrings": {
       "dbContext": "Server=<SERVIDOR>;Database=BdXOLITSharedSpacesTEST;Trusted_Connection=True;"
   }
   ```

### Configuración del Proyecto en Visual Studio
1. Abre el archivo `.sln` del proyecto con Visual Studio.
2. Configura `SharedSpaces.Api` como el proyecto de inicio.
3. Asegúrate de que las dependencias estén restauradas automáticamente:
   ```bash
   dotnet restore
   ```
4. Ejecuta el proyecto presionando `F5` o seleccionando `Debug > Start Debugging`.

---

## Ejecución de Pruebas de los Endpoints
1. Para probar los endpoints, he agregado algunos ejemplos en la URL:
   ```
   https://www.notion.so/Request-Test-XOLIT-SAS-16a5179eb6108075b794ed8e9e8e163c?pvs=4
   ```   

2. También puedes utilizar la colección de Postman disponible en:
   ```
   /Varios/API Docs/Services Template WEB API.postman_collection.json
   ```   

3. Adjunto tambien el json del swagger
   ```
   /Varios/API Docs/swagger.json
   ```
---

## Estructura del Proyecto
El proyecto sigue la arquitectura hexagonal y está dividido en las siguientes capas principales:
- **Domain**: Contiene las entidades de dominio y la lógica empresarial.
- **Application**: Implementa los casos de uso y define los puertos de entrada/salida.
- **Infrastructure**: Contiene implementaciones concretas, como repositorios y el contexto de la base de datos.
- **API**: Exposición de la API para interactuar con los servicios.

---