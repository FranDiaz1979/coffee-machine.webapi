namespace Tests
{
    using NUnit.Framework;
    using Repositories;
    using System.Linq;

    [TestFixture]
    internal class WebApiContextTests
    {
        [Test]
        public void ProbarContexto()
        {
            using var context = new WebApiContext();
            var result = context.Orders.First();
            Assert.IsNotNull(result);
        }
    }
}