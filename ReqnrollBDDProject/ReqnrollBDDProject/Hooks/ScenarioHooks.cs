
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;
using ReqnrollBDDProject.Drivers;

namespace ReqnrollBDDProject.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver driver;

        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer; // for dependency injection of WebDriver into step definitions
            _scenarioContext = scenarioContext; // for storing scenario-specific data, if needed {unique in Reqnroll}
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = DriverManager.CreateDriver("chrome");
            _objectContainer.RegisterInstanceAs(driver);
            _scenarioContext["WebDriver"] = driver;

        }
       
        [AfterScenario]
        public void AfterScenario()
        {
            DriverManager.QuitDriver();
        
        }

    }
}