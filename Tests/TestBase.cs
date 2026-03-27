using NUnit.Framework;
using TestingDME.Utilities;

namespace TestingDME.Tests
{
    public class TestBase
    {
        [SetUp]
        public void Setup()
        {
            DriverManager.InitDriver();
            DriverManager.GetDriver().Navigate().GoToUrl(ConfigReader.Url);
            var test = ExtentManager.GetInstance().CreateTest(TestContext.CurrentContext.Test.Name);
            ExtentTestManager.SetTest(test);
        }

        [TearDown]
        public void Teardown()
        {
            var result = TestContext.CurrentContext.Result;
            if (result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string ssPath = ScreenshotHelper.Capture(TestContext.CurrentContext.Test.Name);
                ExtentTestManager.GetTest().Fail(result.Message).AddScreenCaptureFromPath(ssPath);
            }
            else ExtentTestManager.GetTest().Pass("Test Passed");

            DriverManager.QuitDriver();
            ExtentTestManager.Unload();
            WaitFactory.Unload();
        }

        [OneTimeTearDown]
        public void Final() => ExtentManager.GetInstance().Flush();
    }
}