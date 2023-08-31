 # Documentacion API ID-HEALTH (E-commers) 🧑🏻‍💻
## Descripcion 📃:
_Prueba tecnica para desarrollador backend donde se realiza una API RESTFul con las tecnologias C# y .netCore 6._

## Inicializar API 🤯:
Esta API REST esta basada en C# y .NetCore6.

 * Al clonar o descargar el proyecto:
    * Restaure los paquetes NuGet

 * Configure la base de datos:
    * Si desea utilizar la que se encuentra expuesta en "Databases/MongoRepository.cs" o la puede cambiar por la de su preferencia

 * Para iniciar el servidor:
    * Reconstruya el proyecto y ejecute.

## Estructura de carpetas 📂:
_Una estructura de carpetas simple y entendible para un entorno backend en una API REST_
```
    |_Archivos principales
    |__Controller
        |__Archivos de controladores
    |__Database
        |__Collection
            |__Archivos de funcionalidad para las colecciones de la DB
        |__Archivo de configuracion DB
    |__Models
        |__Intefaces
            |__Archivos de interfaces que se usaran a lo largo del servidor
        |__Archivos de modelos DB
```
## Configuracion de rutas 📡:
Todas las rutas estan definidas segun el schema a utilizar despues del |/api[collection]|.

* URL desarrollo: 
   ```http://localhost:7112/api```

* Rutas actuales:
    * Usuarios: ```URL desarrollo/usuarios```
    * Tiendas: ```URL desarrollo/tiendas```
    * Categorias: ```URL desarrollo/categorias```
    * Productos: ```URL desarrollo/productos```
    * Ventas: ```URL desarrollo/ventas```
      
## Documentacion de la API (Postman):
  * https://documenter.getpostman.com/view/14362863/2s9Y5crzPa
  * Por defecto cuando carga la api al momento de ejecutar le abrira una documentacion de Swagger
  * Documentacion MER planeacion de modelo relacionan: ``` https://drive.google.com/file/d/10op_rkPpzp-lvkKBPDrDW9AUiXOTWR5f/view?usp=sharing ```
## Recomendaciones 👀:
* Revisar siempre las respuestas del servidor
* Revisar las dependencias del appsetings.json
---
Nicolas Duarte 🎉
```

 ███▄    █  ██ ▄█▀
 ██ ▀█   █  ██▄█▒ 
▓██  ▀█ ██▒▓███▄░ 
▓██▒  ▐▌██▒▓██ █▄ 
▒██░   ▓██░▒██▒ █▄
░ ▒░   ▒ ▒ ▒ ▒▒ ▓▒
░ ░░   ░ ▒░░ ░▒ ▒░
   ░   ░ ░ ░ ░░ ░ 
         ░ ░  ░   
                  
```
