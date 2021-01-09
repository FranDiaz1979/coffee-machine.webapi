// TODO: Make mocks of the repositories

namespace Tests
{
    using Models;
    using NUnit.Framework;
    using Services;
    using System.Linq;

    [TestFixture]
    public class DrinkServiceTests
    {
        [Test]
        public void DrinkService_Order_DrinkWithoutData()
        {
            // Arrange
            var drinkService = new DrinkService();
            var drink = new Drink();

            // Act
            string result = drinkService.OrderAsync(drink).Result;

            // Assert
            Assert.AreEqual("The drink type should be tea, coffee or chocolate.", result);
        }

        [Test]
        public void DrinkService_Order_InventedDrink()
        {
            // Arrange
            var drinkService = new DrinkService();
            var drink = new Drink
            {
                DrinkType = "invented drink",
                Money = 0.8F,
                Sugars = 1,
                ExtraHot = 1,
            };

            // Act
            string result = drinkService.OrderAsync(drink).Result;

            // Assert
            Assert.AreEqual("The drink type should be tea, coffee or chocolate.", result);
        }

        [TestCase("TEA", 0.39F, 1, 1)]
        [TestCase("COFFEE", 0.49F, 1, 1)]
        [TestCase("CHOCOLATE", 0.59F, 1, 1)]
        public void DrinkService_Order_MoneyNotEnought(string drinkType, float money, int sugars, int extraHot)
        {
            // Arrange
            var drinkService = new DrinkService();
            var drink = new Drink
            {
                DrinkType = drinkType,
                Money = money,
                Sugars = sugars,
                ExtraHot = extraHot,
            };

            // Act
            string result = drinkService.OrderAsync(drink).Result;

            // Assert
            Assert.AreEqual(
                string.Format(
                    "The {0} costs {1}.",
                    drinkService.DrinkPrices.Single(x => x.Name.ToLower() == drink.DrinkType.ToLower()).Name,
                    drinkService.DrinkPrices.Single(x => x.Name.ToLower() == drink.DrinkType.ToLower()).Price.ToString("N", new System.Globalization.CultureInfo("en-US"))),
                result);
        }

        [TestCase("COFFEE", 1F, -1, 1)]
        [TestCase("TEA", 1F, 4, 1)]
        [TestCase("CHOCOLATE", 1F, 2000, 1)]
        public void DrinkService_Order_BadNumberSugars(string drinkType, float money, int sugars, int extraHot)
        {
            // Arrange
            var drinkService = new DrinkService();
            var drink = new Drink
            {
                DrinkType = drinkType,
                Money = money,
                Sugars = sugars,
                ExtraHot = extraHot,
            };

            // Act
            string result = drinkService.OrderAsync(drink).Result;

            // Assert
            Assert.AreEqual("The number of sugars should be between 0 and 2.", result);
        }

        [TestCase("COFFEE", 1F, 0, 0)]
        [TestCase("TEA", 1F, 0, 0)]
        [TestCase("CHOCOLATE", 1F, 0, 0)]
        public void DrinkService_Order_DrinkColdWhithoutSugar(string drinkType, float money, int sugars, int extraHot)
        {
            // Arrange
            var drinkService = new DrinkService();
            var drink = new Drink
            {
                DrinkType = drinkType,
                Money = money,
                Sugars = sugars,
                ExtraHot = extraHot,
            };

            // Act
            string result = drinkService.OrderAsync(drink).Result;

            // Assert
            Assert.AreEqual(string.Format("You have ordered a {0}", drink.DrinkType.ToLower()), result);
        }

        [TestCase("COFFEE", 1F, 1, 0)]
        [TestCase("TEA", 1F, 1, 0)]
        [TestCase("CHOCOLATE", 1F, 1, 0)]
        [TestCase("COFFEE", 1F, 2, 0)]
        [TestCase("TEA", 1F, 2, 0)]
        [TestCase("CHOCOLATE", 1F, 2, 0)]
        public void DrinkService_Order_DrinkColdWithSugar(string drinkType, float money, int sugars, int extraHot)
        {
            // Arrange
            var drinkService = new DrinkService();
            var drink = new Drink
            {
                DrinkType = drinkType,
                Money = money,
                Sugars = sugars,
                ExtraHot = extraHot,
            };

            // Act
            string result = drinkService.OrderAsync(drink).Result;

            // Assert
            Assert.AreEqual(string.Format("You have ordered a {0} with {1} sugars(stick included).", drink.DrinkType.ToLower(), drink.Sugars), result);
        }

        [TestCase("COFFEE", 1F, 0, 1)]
        [TestCase("TEA", 1F, 0, 1)]
        [TestCase("CHOCOLATE", 1F, 0, 1)]
        public void DrinkService_Order_DrinkHotWithoutSugar(string drinkType, float money, int sugars, int extraHot)
        {
            // Arrange
            var drinkService = new DrinkService();
            var drink = new Drink
            {
                DrinkType = drinkType,
                Money = money,
                Sugars = sugars,
                ExtraHot = extraHot,
            };

            // Act
            string result = drinkService.OrderAsync(drink).Result;

            // Assert
            Assert.AreEqual(string.Format("You have ordered a {0} extra hot", drink.DrinkType.ToLower()), result);
        }

        [TestCase("COFFEE", 1F, 1, 1)]
        [TestCase("TEA", 1F, 1, 1)]
        [TestCase("CHOCOLATE", 1F, 1, 1)]
        [TestCase("COFFEE", 1F, 2, 1)]
        [TestCase("TEA", 1F, 2, 1)]
        [TestCase("CHOCOLATE", 1F, 2, 1)]
        public void DrinkService_Order_DrinkHotWithSugar(string drinkType, float money, int sugars, int extraHot)
        {
            // Arrange
            var drinkService = new DrinkService();
            var drink = new Drink
            {
                DrinkType = drinkType,
                Money = money,
                Sugars = sugars,
                ExtraHot = extraHot,
            };

            // Act
            string result = drinkService.OrderAsync(drink).Result;

            // Assert
            Assert.AreEqual(string.Format("You have ordered a {0} extra hot with {1} sugars(stick included).", drink.DrinkType.ToLower(), drink.Sugars), result);
        }

        [Test]
        public void DrinkService_ReadAll()
        {
            var drinkService = new DrinkService();
            var result = drinkService.ReadAll();
            Assert.IsNotNull(result.FirstOrDefault());
        }
    }
}