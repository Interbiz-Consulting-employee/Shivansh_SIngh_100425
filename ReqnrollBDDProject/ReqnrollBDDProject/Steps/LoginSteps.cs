using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollBDDProject.Pages;
using ReqnrollBDDProject.Utilities;

namespace ReqnrollBDDProject.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly LoginPage _loginPage;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = new LoginPage(); // Uses thread-safe DriverManager.Driver internally
        }

        [Given(@"I open the Reqnroll login page")]
        public void GivenIOpenTheReqnrollLoginPage()
        {
            _loginPage.NavigateToUrl("https://test.rovicare.com");
        }

        [When(@"I login with ""(.*)"" and ""(.*)""")]
        public void WhenILoginWithCredentials(string username, string password)
        {
            _loginPage.Login(username, password);
        }

        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSeeTheResult(string expectedResult)
        {
            string actualResult = _loginPage.GetLoginResult();
            Assert.That(actualResult, Is.EqualTo(expectedResult.ToLower()),
                $"Expected '{expectedResult}', but got '{actualResult}'");

            ExtentReportManager.GetCurrentTest()?.Info($"Expected result: {expectedResult}");

            ExtentReportManager.GetCurrentTest()?.Info($"Actual result: {actualResult}");
        }
    }
}