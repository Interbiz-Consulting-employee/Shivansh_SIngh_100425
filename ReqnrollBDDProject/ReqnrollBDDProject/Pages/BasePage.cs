using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace ReqnrollBDDProject.Pages
{
    public class BasePage
    {
        
        protected readonly IWebDriver driver;     // readonly prevents accidental driver reassignment
        protected readonly WebDriverWait wait;     // explicit wait instance per page object (safe for parallel execution)


        public BasePage(IWebDriver driver)  //in parallel tests, each scenario/thread has its own WebDriver instance (from ThreadLocal or Hooks)
        {
            this.driver = driver; 
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        protected IWebElement WaitForElementVisible(By locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected IWebElement WaitForElementClickable(By locator)
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        protected void ClickElement(By locator)
        {
            WaitForElementClickable(locator).Click();
        }

        protected void EnterText(By locator, string text)
        {
            var element = WaitForElementVisible(locator);
            element.Clear();
            element.SendKeys(text);
        }

        protected string GetText(By locator)
        {
            return WaitForElementVisible(locator).Text;
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        protected void WaitForPageLoad()
        {
            wait.Until(driver =>
                ((IJavaScriptExecutor)driver)
                .ExecuteScript("return document.readyState")
                .Equals("complete"));
        }
    }
}