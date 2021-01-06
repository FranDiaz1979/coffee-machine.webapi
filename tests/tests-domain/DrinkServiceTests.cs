// TODO: Hacer mocks de capa servicio

namespace DomainTests
{
    using Models;
    using NUnit.Framework;
    using Services;
    using System.Linq;

    [TestFixture]
    public class DrinkServiceTests
    {
        [Test]
        public void DrinkServicePedir_BebidaSinDatos()
        {
            // Arrange
            var drinkService = new DrinkService();
            string resultado;
            var drink = new Drink();

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

        [TestCase("TEA", 0.39F, 1, 1)]
        [TestCase("COFFEE", 0.49F, 1, 1)]
        [TestCase("CHOCOLATE", 0.59F, 1, 1)]
        public void DrinkServicePedir_DineroInsuficiente(string drinkType, float money, int sugars, int extraHot)
        {
            // Arrange
            var drinkService = new DrinkService();
            string resultado;
            var drink = new Drink
            {
                DrinkType = drinkType,
                Money = money,
                Sugars = sugars,
                ExtraHot = extraHot,
            };

            // Act
            resultado = drinkService.Pedir(drink);

            // Assert
            Assert.AreEqual(
                string.Format(
                    "The {0} costs {1}.",
                    drinkService.DrinkPrices.Single(x => x.Name.ToLower() == drink.DrinkType.ToLower()).Name,
                    drinkService.DrinkPrices.Single(x => x.Name.ToLower() == drink.DrinkType.ToLower()).Price.ToString("N", new System.Globalization.CultureInfo("en-US"))),
                resultado);
        }

        [TestCase("COFFEE", 1F, -1, 1)]
        [TestCase("TEA", 1F, 4, 1)]
        [TestCase("CHOCOLATE", 1F, 2000, 1)]
        public void DrinkServicePedir_CantidadAzucarillosMal(string drinkType, float money, int sugars, int extraHot)
        {
            // Arrange
            var drinkService = new DrinkService();
            string resultado;
            var drink = new Drink
            {
                DrinkType = drinkType,
                Money = money,
                Sugars = sugars,
                ExtraHot = extraHot,
            };

            // Act
            resultado = drinkService.Pedir(drink);

            // Assert
            Assert.AreEqual("The number of sugars should be between 0 and 2.", resultado);
        }

        [TestCase("COFFEE", 1F, 0, 0)]
        [TestCase("TEA", 1F, 0, 0)]
        [TestCase("CHOCOLATE", 1F, 0, 0)]
        public void DrinkServicePedir_BebidaFriaSinAzucar(string drinkType, float money, int sugars, int extraHot)
        {
            // Arrange
            var drinkService = new DrinkService();
            string resultado;
            var drink = new Drink
            {
                DrinkType = drinkType,
                Money = money,
                Sugars = sugars,
                ExtraHot = extraHot,
            };

            // Act
            resultado = drinkService.Pedir(drink);

            // Assert
            Assert.AreEqual(string.Format("You have ordered a {0}", drink.DrinkType.ToLower()), resultado);
        }

        [TestCase("COFFEE", 1F, 1, 0)]
        [TestCase("TEA", 1F, 1, 0)]
        [TestCase("CHOCOLATE", 1F, 1, 0)]
        [TestCase("COFFEE", 1F, 2, 0)]
        [TestCase("TEA", 1F, 2, 0)]
        [TestCase("CHOCOLATE", 1F, 2, 0)]
        public void DrinkServicePedir_BebidaFriaConAzucar(string drinkType, float money, int sugars, int extraHot)
        {
            // Arrange
            var drinkService = new DrinkService();
            string resultado;
            var drink = new Drink
            {
                DrinkType = drinkType,
                Money = money,
                Sugars = sugars,
                ExtraHot = extraHot,
            };

            // Act
            resultado = drinkService.Pedir(drink);

            // Assert
            Assert.AreEqual(string.Format("You have ordered a {0} with {1} sugars(stick included).", drink.DrinkType.ToLower(), drink.Sugars), resultado);
        }

        [TestCase("COFFEE", 1F, 0, 1)]
        [TestCase("TEA", 1F, 0, 1)]
        [TestCase("CHOCOLATE", 1F, 0, 1)]
        public void DrinkServicePedir_BebidaCalienteSinAzucar(string drinkType, float money, int sugars, int extraHot)
        {
            // Arrange
            var drinkService = new DrinkService();
            string resultado;
            var drink = new Drink
            {
                DrinkType = drinkType,
                Money = money,
                Sugars = sugars,
                ExtraHot = extraHot,
            };

            // Act
            resultado = drinkService.Pedir(drink);

            // Assert
            Assert.AreEqual(string.Format("You have ordered a {0} extra hot", drink.DrinkType.ToLower()), resultado);
        }

        [TestCase("COFFEE", 1F, 1, 1)]
        [TestCase("TEA", 1F, 1, 1)]
        [TestCase("CHOCOLATE", 1F, 1, 1)]
        [TestCase("COFFEE", 1F, 2, 1)]
        [TestCase("TEA", 1F, 2, 1)]
        [TestCase("CHOCOLATE", 1F, 2, 1)]
        public void DrinkServicePedir_BebidaCalienteConAzucar(string drinkType, float money, int sugars, int extraHot)
        {
            // Arrange
            var drinkService = new DrinkService();
            string resultado;
            var drink = new Drink
            {
                DrinkType = drinkType,
                Money = money,
                Sugars = sugars,
                ExtraHot = extraHot,
            };

            // Act
            resultado = drinkService.Pedir(drink);

            // Assert
            Assert.AreEqual(string.Format("You have ordered a {0} extra hot with {1} sugars(stick included).", drink.DrinkType.ToLower(), drink.Sugars), resultado);
        }
    }
}