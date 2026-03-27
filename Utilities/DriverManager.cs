using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace TestingDME.Utilities
{
    public class DriverManager
    {
        private static ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();

        public static IWebDriver GetDriver() => _driver.Value
            ?? throw new NullReferenceException("Driver not initialized.");

        public static void InitDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--incognito");
            options.AddArgument("--start-maximized");
            options.AddArgument("--ignore-certificate-errors");
            options.AcceptInsecureCertificates = true;
            options.AddArgument("--disable-blink-features=AutomationControlled");

            _driver.Value = new ChromeDriver(options);
        }

        public static void QuitDriver()
        {
            _driver.Value?.Quit();
            _driver.Value?.Dispose();
            _driver.Value = null;
        }
    }
}