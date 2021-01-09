Esta solución es un ejemplo de webapi en .NET 5 (nueva version de .NET CORE 3.1)

Consiste en una webapi que simula ser una maquina de bebidas.

Tiene el siguiente stack técnico:

	Visual Studio en windows
	.NET 5, (que es core, no framework)
	GIT
	Entity Framework Core
	Web Api tipo Rest
	Estructura de n-capas o onion, (parecida en parte a DDD o arquitectura hexagonal)
	TDD
	Unit tests con NUnit (no todos, solo DrinkServices como ejemplo)
	Buenas prácticas: Principios SOLID, CLEAN CODE y Refactoring
	MySql
	contenedores Docker
	Linux Server
	Como herramientas para buscar code smells he usado CodeMaid, SonarQube y StileCop

Explicacion de la estructura n-capas implementada:
	La estructura de carpetas y proyectos es n-capas o onion, por lo que se separan las capas en: 
		Aplicacion (webapi) -> Dominio (logica de negocio) -> Datos (infraestructura) -> Base de datos
	
	He elegido esta estructura porque me parece mejor que DDD, ya que tiene la parte de infraestructura de datos por separado 
	y el resto de la infraestructura en la capa aplicación o en otras capas, y es muy facil cambiar de tipo de BBDD o usar Azure/AWS, etc.
	
	Aun así a la capa de Lógica de negocio la he nombrado Dominio para resaltar el concepto que esta capa llevo años programandola como si fuesen dominios fuertes (no endémicos).
	
Como ejecutar el código:

	Si no te paso el codigo por mail, no tendrás el password de la bbdd levantada en mi servidor, 
	asi que tendras que instalar mysql o levantar un contenedor docker de mysql,
	crear una base de datos coffee-machine y ejecutar la query:	
		CREATE TABLE IF NOT EXISTS orders (
		  `id` INT(10) unsigned NOT NULL AUTO_INCREMENT,
		  `drink_type` VARCHAR(20) NOT NULL,
		  `sugars` TINYINT(2) NOT NULL,
		  `stick` TINYINT(1) NOT NULL,
		  `extra_hot` TINYINT(1) NOT NULL,
		  PRIMARY KEY (`id`)
		) ENGINE=InnoDB DEFAULT CHARSET=utf8;	
	
	Al codigo le falta el archivo data/Repositories/SecretsVaultSettings.Settings, 
	puedes poner el password directamente en el archivo .cs o en el MySqlSettings

Como probar la api:
	
	El proyecto se puede probar con la intefaz de swagger (solo funciona en windows, lo ejecuta visual studio al hacer F5):
	https://localhost:44384/swagger/index.html

	Para linux hay que ejecutar:
		dotnet build
		dotnet run --project api/webapi/
	
	En ambos casos la ruta de la api es https://localhost:5001/drink, y ha de estar el contenedor de mysql levantado
	
Falta:
	En los unit test faltan mocks, separar unit tests de tests de integracion.
	En el metodo POST se pasan los parametros como GET (y queda feo) y no se usa ningun DTO para especificar los parametros.
	Contestar con un status code cuando hay un error.
	Quitar nombres en castellano.
	Hacer servir injeccion de dependencias y quitar new's
	Si pones como precio 0,499999999999 te deja comprar.
	En la capa Dominio he llamado al "modelo" Drink y en la capa datos Order para diferenciarlas, pero he de añadirles una coletilla al nombre para que el proyecto escale sin problemas. 
	Para Linux se puede hacer un bundle con todos los contenedores.
	
	
(El problema planteado al completo esta en la carpeta documentación, y venía en un bundle con un front de 3 contenedores docker)

