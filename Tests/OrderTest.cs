using NUnit.Framework;
using TestingDME.Pages;
using TestingDME.Utilities;

namespace TestingDME.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class OrderTest : TestBase
    {
        [Test]
        public void VerifyOrderCreationFlow()
        {
            var driver = DriverManager.GetDriver();
            var login = new LoginPage(driver);
            var order = new OrderPage(driver);

            login.Login(ConfigReader.Username, ConfigReader.Password);

            string orderCode = order.CreateFullOrder();
            TestContext.WriteLine($"Order Created: {orderCode}");

            Assert.IsNotEmpty(orderCode, "Order code was not captured!");
        }
    }
}