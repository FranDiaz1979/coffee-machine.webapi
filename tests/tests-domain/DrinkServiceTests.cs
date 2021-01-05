namespace DomainTests
{
    using NUnit;
    using NUnit.Framework;
    using System;
    using services;
    using models;

    //List prices

    //|Drink|Price|
    //|---|---|
    //|Tea|0.4|
    //|Coffee|0.5|
    //|Chocolate|0.6|

    //Validations
    //* If the drink type is not* tea*, * coffee* or * chocolate*, it shows the following message:
    //```
    //The drink type should be tea, coffee or chocolate.
    //```
    //* If the amount of money does not reach the price of the drink, a message as the following is displayed:
    //```
    //The tea costs 0.4.
    //```
    //* If the number of sugars is not between 0 and 2, it shows a message like this:
    //```
    //The number of sugars should be between 0 and 2.
    //```
    //* If the arguments are right, the displayed message is:
    //```
    //You have ordered a coffee
    //```
    //* If the number of sugars is greater than 0, it includes the stick to the drink and it shows a message similar tot this:
    //```
    //You have ordered a coffee with 2 sugars (stick included).
    //```
    //* If it adds extra hot option, the displayed message will be:
    //```
    //You have ordered a coffee extra hot with 2 sugars (stick included)
    //```

    [TestFixture]
    public class DrinkServiceTests
    {

        //|#|Name|Type|Required|Description|Values|Default|
        //|---|---|---|---|---|---|---|
        //|1|drinkType|string|true|Type of drink|tea, coffee, chocolate|
        //|2|money|float|true|Amount of money given by the user in unit of currency||
        //|3|sugars|int|false|Number of sugars|0, 1, 2|0|
        //|4|extraHot|int|false|Flag indicating if the user wants extra hot drink|0, 1|0|

        //[TestCase("inventado")]
        //public void DrinkServicePedir(string drinkType, float money, int sugars, int extraHot)
        //{
        //    // Arrange
        //    var drinkService = new DrinkService();
        //    string resultado;

        //    //Act
        //    resultado = drinkService.Pedir( drinkType,  money,  sugars,  extraHot);


        //    // Assert
        //    Assert.AreEqual(resultado,"");
        //}

        [Test]
        public void DrinkServicePedir_BebidaSinDatos()
        {
            // Arrange
            var drinkService = new DrinkService();
            string resultado;
            var drink = new Drink();
            //{
            //DrinkType = "bebida inventada",
            //Money = 0.8F,
            //Sugars = 1,
            //ExtraHot = 1,
            //};

            // Act
            resultado = drinkService.Pedir(drink);

            // Assert
            Assert.AreEqual("The drink type should be tea, coffee or chocolate.", resultado);
        }

        [Test]
        public void DrinkServicePedir_BebidaInventada()
        {
            // Arrange
            var drinkService = new DrinkService();
            string resultado;
            var drink = new Drink
            {
                DrinkType = "bebida inventada",
                Money = 0.8F,
                Sugars = 1,
                ExtraHot = 1,
            };

            // Act
            resultado = drinkService.Pedir(drink);

            // Assert
            Assert.AreEqual("The drink type should be tea, coffee or chocolate.", resultado);
        }
    }
}
