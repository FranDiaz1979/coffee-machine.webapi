# Coffee Machine

Coffee Machine is an awesome application that from a few input parameters (drink type, amount of money, number of sugars, extra hot check) is capable to order a drink and show a cool message of the desired drink.

## How it works

There is an web front developed with Angular and a backend Api developed in PHP:

- The Angular front sends user's request to de api and shows the api response
- The backend api, validates and handles the front requests

Api Arguments

|#|Name|Type|Required|Description|Values|Default|
|---|---|---|---|---|---|---|
|1|drinkType|string|true|Type of drink|tea, coffee, chocolate|
|2|money|float|true|Amount of money given by the user in unit of currency||
|3|sugars|int|false|Number of sugars|0, 1, 2|0|
|4|extraHot|int|false|Flag indicating if the user wants extra hot drink|0, 1|0|

List prices

|Drink|Price|
|---|---|
|Tea|0.4|
|Coffee|0.5|
|Chocolate|0.6|

Validations
* If the drink type is not *tea*, *coffee* or *chocolate*, it shows the following message:
```
The drink type should be tea, coffee or chocolate.
```
* If the amount of money does not reach the price of the drink, a message as the following is displayed:
```
The tea costs 0.4.
```
* If the number of sugars is not between 0 and 2, it shows a message like this:
```
The number of sugars should be between 0 and 2.
```
* If the arguments are right, the displayed message is:
```
You have ordered a coffee
```
* If the number of sugars is greater than 0, it includes the stick to the drink and it shows a message similar tot this:
```
You have ordered a coffee with 2 sugars (stick included).
```
* If it adds extra hot option, the displayed message will be:
```
You have ordered a coffee extra hot with 2 sugars (stick included)    
```

## Current status

Both front and back were implemented by a developer who is no longer in the company.


#### Api legacy

His legacy in the api backend is the controller class `CoffeeMachineOrderController` 
which handle all the api logic:
* It reads input parameters
* It validates input parameters
* It shows output message
* It stores orders in the database

He also implemented an integration test covering all possibilities (`CoffeeMachineOrderControllerTest`)

#### Front legacy

His legacy in the web-front is an angular application where the component `AppComponent` handles all user interactions

## What you have to do?

As you can see, both api and front are a bit messy and we need to adapt it to our coding standards
so that we can create a Merge Request and merge it into master

We would like to have a reusable, maintainable and testable code, so we want yo to refactor
the api controller `CoffeeMachineOrderController` and the front component `AppComponent` following these principles:

* Clean code
* SOLID principles
* Decoupling
* Design patterns
* Error handling
* Unit testing
* TDD
* Hexagonal architecture

You don't have to implement them all, but make the code better to be more comfortable with it.

## Project set up

Install and run the application.
```
docker/composer install
docker/npm install
docker/up
```

Api Url: http://localhost:9080/

Front Url: http://localhost:4200/

#### Run tests
```
docker/api-test
docker/ng test
```
