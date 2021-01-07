El problema dice de cambiar el back y el front, pero al cliente solo le interesa el back y es lo que he hecho.
La parte del front queda igual.


El back lo he hecho con el siguiente stack técnico:
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
	Docker
	Linux Server
	Como herramientas para buscar code smells he usado CodeMaid, SonarQube y StileCop

Falta:
	En los unit test faltan mocks
	
Como probarlo:
	El proyecto se puede probar con la intefaz de swagger:
	https://localhost:44384/swagger/index.html

	Tambien se puede como una api normal:
	https://localhost:44384/Drink
	