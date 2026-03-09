using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using ReqnrollBDDProject.Pages;
using SeleniumExtras.WaitHelpers;

namespace ReqnrollBDDProject.Steps
{
    [Binding]
    //[Parallelizable(ParallelScope.Fixtures)]
    //[LevelOfParallelism(2)] Not possible to set at class level, must be at assembly level
    public class LoginSteps
    {
        private readonly IWebDriver driver;
        private readonly LoginPage loginPage;
        private readonly WebDriverWait wait;
        private readonly ScenarioContext _scenarioContext;

        public LoginSteps(IWebDriver driver, ScenarioContext scenarioContext) // WebDriver is injected via constructor by Reqnroll's dependency injection , unique per scenario/thread
        {
            this.driver = driver;
            this._scenarioContext = scenarioContext; 
            loginPage = new LoginPage(driver); 
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        [Given(@"I open the Reqnroll login page")]
        public void GivenIOpenTheReqnrollLoginPage()
        {
            loginPage.NavigateToUrl("https://test.rovicare.com");
        }

        [When(@"I login with ""(.*)"" and ""(.*)""")]
        public void WhenILoginWithCredentials(string username, string password)
        {
            loginPage.Login(username, password);
        }

        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSeeTheResult(string result)
        {
            if (result.ToLower() == "success")
            {
                IWebElement dashboard = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span//img[@class]")));
                Assert.That(dashboard.Displayed, Is.True, "Login failed: Dashboard not visible.");
            }
            else if (result.ToLower() == "failure")
            {
                Assert.That(loginPage.IsLoginErrorDisplayed(), Is.True, "Expected login failure, but no error found.");
            }
            else
            {
                Assert.Fail($"Invalid result string: {result}");
            }
        }
    }
}