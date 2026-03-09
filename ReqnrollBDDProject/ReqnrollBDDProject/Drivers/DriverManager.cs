using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;


namespace ReqnrollBDDProject.Drivers
{
    public static class DriverManager
    {
        private static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>(); 
        
        // {Kaustub sir} Each thread has its own instance of IWebDriver 
        // Prevents Accidental Modification //Maintains Control Over WebDriver Lifecycle 
        // Supports Stable Parallel Execution & Ensures Thread Safety in Parallel Execution


        public static IWebDriver GetDriver() => driver.Value;

        public static void SetDriver(IWebDriver webDriver) => driver.Value = webDriver;

        public static IWebDriver CreateDriver(string browser = "chrome")
        {
            IWebDriver localDriver;
            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();      // ChromeOptions in Selenium is a class used to customize how the Chrome browser starts and behaves during automation. { Rishabh Sir : Do in Incognito }                    
                    chromeOptions.AddArgument("--incognito");
                    localDriver = new ChromeDriver(chromeOptions);
                    break;

                case "edge":
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("--inprivate");
                    localDriver = new EdgeDriver(edgeOptions);
                    break;

                default:
                    throw new ArgumentException("Browser not supported: " + browser);
            }

            localDriver.Manage().Window.Maximize();
            localDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            SetDriver(localDriver);
            return localDriver;
        }

        public static void QuitDriver()
        {
            if (driver.Value != null)
            {
                driver.Value.Quit();
                driver.Value.Dispose(); // release resources 
              
            }
        }
    }
}