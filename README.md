# ToDoList
Proyecto API de prueba de un ToDoList en .Net 8 con EF y SQL server

Este proyecto trata de una pequeña API que permite el registro de usuarios, tanto administradores como standard, y la creación, consulta, edición y eliminado de tareas o de tareas por hacer.
Dicha solución consta de 3 capas bien limitadas, la API principal encargada de los controladores y endpoints a mostrar junto con su seguridad y permisos; la capa de servicios que aplica la regla de negocios y validaciones básicas; y por ultimo la capa de Repositorios donde esta toda la lógica de base de datos con Entity Framework y las migraciones.

Adicional a estas capas se crearon librerías compartidas, que son mas que todo clases utilizadas por las otras 3 capas y que es mejor tenerlas en un solo lugar para cuando se deba modificar algo en todas las capas se actualice. Hay Enums como los Roles (se explica mas adelante) o los resultados de las operaciones. También se almacenan las entidades de base de datos, permitiendo que la capa de Repositorio pueda variar de contexto o conexión siempre y cuando se respeten las entidades bases. Y también los modelos de regla de negocios, permitiendo su uso compartido en caso de crear mas servicios o capas adicionales.

Los roles se almacenaron en un Enum como una data fija dentro del sistema ya que esto permitía el que se pudiera solicitar de cualquier parte sin cambiar sus valores y como el sistema en si requiere a nivel funcional mínimo 2 roles y máximo puede que 2 o mas, entonces no se vio necesario el hecho de crear una tabla roles que al fin y al cabo no iba a variar lo suficiente ni almacenar datos útiles o continuamente solicitados.

Para este sistema se comenzó a trabajar con la base de datos, siempre busco abordar la creación de nuevos sistemas por las Base de Datos ya que esta es el pilar de toda la lógica que se va a desarrollar. Si se desarrolla una base de datos simple, normalizada y estable entonces tendrás menos cambios de clases y de métodos en el desarrollo del backend. Luego de hacer el diseño de la base de Datos se empieza a crear el backend como tal de la forma mas simple y directa posible.

Se crea los proyectos necesarios: API, Servicios y Repositorios. Luego se parte desde repositorios para crear las entidades de cada tabla de la Base de Datos antes diseñada para luego configurar las migraciones y la creación mediante Code-First de la Base de Datos. Luego de desarrolla la capa de servicios pero como un puente directo entre el repositorio y el controlador para luego terminar en el controlador creando los endpoints básicos de un CRUD y su conexiones con las otras capas. Luego de esto se empieza a refinar las clases de cada capa y los métodos necesarios para cada una de ellas, así ya con las bases construidas es mas fácil ver los métodos que hacen falta para dar forma al Sistema.

Luego se aborda el tema de la autenticación y autorización del sistema, aplicando restricciones para los roles y ya entrando en mas profundidad sobre lo que puede o no hacer cada usuario.
Luego se realizan las pruebas básicas de funcionamiento de los endpoints y gracias a esta se empiezan a aplicar las validaciones correspondientes tanto en la capa de servicios como en la API.

El sistema puede correr tanto en Contenedores como en IIS o un web service de Core. Como mis conocimientos de contenedores es muy básico deje que Visual Studio creara el archivo de configuración para así con solo realizar la configuración inicial te permita crear el contenedor en tu computadora local y montar la imagen en este.

Adicional a esto se debe contar con el runtime de net 8 y con Sql Server instalados en el equipo. De igual forma se debe ingresar en el archivo appsetting.json la cadena de conexión con la Base de Datos (La actual es una cadena con windows authentication pero si lo desea puede ingresar una con SQL authentication).

Luego de esto solo debe ejecutar en la consola de dot net o en la de administrador de paquetes el comando de migración de Update-Database para ejecutar todas las migraciones almacenadas. Estas crearan la Base de Datos y adicional creara un usuario Administrador con correo admin@gmail.com y contraseña ¨123456¨. Esto es necesarios ya que el sistema necesita al inicio al menos un usuario administrador que permita crear tareas u otros usuarios.

Ya con esto se puede correr la API (Con cualquiera de los métodos antes mencionados) y lo primero que se debe hacer es ejecutar el método de Login con el usuario antes registrado para poder obtener tu Token de sesión y poder comenzar a llamar al resto de endpoints.

En este se podrá crear tareas, consultarlas, editar su nombre, completarlas, eliminarlas, crear otros usuarios, CRUD tanto de tus tareas como la de los otros usuarios (Solo Rol Administrador).

A nivel de contraseñas el sistema no las encripta debido a que esta api esta pensada en recibir ya las contraseñas encríptadas o hash para mayor seguridad.

Ya luego de todo esto solo queda usar la API y sus endpoints para crear tus tareas pendientes e irlas completando sin olvidarte de ninguna.

También es un buen proyecto base para cualquier otro que se desee hacer ya que cuenta con todas las configuraciones necesarias en términos generales.

Debido a lo simple del sistema se aplico esta estructura ya que era muy pequeño como para aplicar microservicios o reglas de negocio como CQRS.
