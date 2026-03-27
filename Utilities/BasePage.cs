using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TestingDME.Utilities;
using System;

namespace TestingDME.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        public BasePage(IWebDriver driver) => this.driver = driver;

        protected IWebElement WaitForElement(By loc) => WaitFactory.GetWait().Until(ExpectedConditions.ElementIsVisible(loc));

        // NEW ROBUST CLICK METHOD
        public void SafeClick(By locator)
        {
            try
            {
                // Wait for it to be ready
                var element = WaitFactory.GetWait().Until(ExpectedConditions.ElementToBeClickable(locator));

                // Try scrolling first
                ScrollToElement(locator);

                // Attempt standard Selenium click
                element.Click();
            }
            catch (Exception)
            {
                // FALLBACK: Use JavaScript to force the click if intercepted or off-screen
                IWebElement element = driver.FindElement(locator);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].click();", element);
            }
        }

        public void Type(By loc, string txt)
        {
            var e = WaitForElement(loc);
            e.Clear();
            e.SendKeys(txt);
        }

        public void ScrollToElement(By loc)
        {
            IWebElement element = driver.FindElement(loc);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", element);
        }
    }
}