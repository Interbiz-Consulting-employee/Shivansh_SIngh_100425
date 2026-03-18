using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace ReqnrollBDDProject.Drivers
{
    public static class DriverManager
    {
        private static readonly ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        public static IWebDriver Driver => driver.Value ?? throw new InvalidOperationException("WebDriver not initialized.");

        public static IWebDriver CreateDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--incognito");

            driver.Value = new ChromeDriver(chromeOptions);
            driver.Value.Manage().Window.Maximize();
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
            
            return driver.Value;
        }

        public static void QuitDriver()
        {
            if (driver.Value == null) 
             return;

            try { driver.Value.Quit(); 
                  driver.Value.Dispose(); 
                } 
            catch 
                { 
                }
            driver.Value = null;
        }
    }
}