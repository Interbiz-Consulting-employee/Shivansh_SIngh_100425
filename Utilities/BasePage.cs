using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace TestingDME.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        protected IWebElement WaitForElement(By locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        protected IWebElement WaitForClickable(By locator)
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public void SafeClick(By locator)
        {
            try
            {
                var element = WaitForClickable(locator);
                ScrollToElement(element);
                element.Click();
            }
            catch (Exception)
            {
                var element = WaitForElement(locator);
                JsClick(element);
            }
        }

        public void Type(By locator, string text)
        {
            var element = WaitForElement(locator);
            element.Clear();
            element.SendKeys(text);
        }

        public void ClearAndType(By locator, string text)
        {
            var element = WaitForElement(locator);
            element.Click();
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Backspace);
            element.SendKeys(text);
        }

        public void ScrollToElement(By locator)
        {
            var element = WaitForElement(locator);
            ScrollToElement(element);
        }

        public void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView({block:'center'});", element);
        }

        public void JsClick(IWebElement element)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].click();", element);
        }

        public bool IsElementVisible(By locator, int timeout = 5)
        {
            try
            {
                var shortWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return shortWait.Until(ExpectedConditions.ElementIsVisible(locator)).Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}