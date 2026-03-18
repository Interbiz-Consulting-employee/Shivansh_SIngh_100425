using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace ReqnrollBDDProject.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver => ReqnrollBDDProject.Drivers.DriverManager.Driver;
        protected WebDriverWait Wait { get; }

        public BasePage(int waitTimeInSeconds = 30)
        {
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTimeInSeconds));
        }

        protected IWebElement WaitForElementVisible(By locator) =>
            Wait.Until(ExpectedConditions.ElementIsVisible(locator));

        protected IWebElement WaitForElementClickable(By locator) =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator));

        protected void ClickElement(By locator)
        {
            try
            {
                WaitForElementClickable(locator).Click();
            }
            catch
            {
                ((IJavaScriptExecutor)Driver)
                    .ExecuteScript("arguments[0].click();", WaitForElementVisible(locator));
            }
        }

        protected void EnterText(By locator, string text)
        {
            var element = WaitForElementVisible(locator);
            element.Clear();
            element.SendKeys(text);
        }

        protected string GetText(By locator) => WaitForElementVisible(locator).Text;

        public void NavigateToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
            WaitForPageLoad();
        }

        protected void WaitForPageLoad()
        {
            Wait.Until(d =>
                ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        protected bool IsElementPresent(By locator) => Driver.FindElements(locator).Count > 0;
    }
}