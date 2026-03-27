using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace TestingDME.Utilities
{
    public static class WaitFactory
    {
        private static ThreadLocal<WebDriverWait> _wait = new ThreadLocal<WebDriverWait>();

        public static WebDriverWait GetWait()
        {
            if (_wait.Value == null)
            {
                _wait.Value = new WebDriverWait(DriverManager.GetDriver(), TimeSpan.FromSeconds(30));
                _wait.Value.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            }
            return _wait.Value;
        }

        public static void Unload() => _wait.Value = null;
    }
}