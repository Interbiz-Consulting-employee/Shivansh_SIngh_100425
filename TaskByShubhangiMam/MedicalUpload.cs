using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Threading;

class Program
{
    public static void Main()
    {
        IWebDriver driver = new EdgeDriver();

        try
        {
            driver.Navigate().GoToUrl("https://test.rovicare.com");
            driver.Manage().Window.Maximize();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement username = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("signInName")));
            username.SendKeys("hospital@rovicare.com");

            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("RoviPass@321");

            IWebElement submit = driver.FindElement(By.Id("next"));
            submit.Click();
            Thread.Sleep(5000);
            IWebElement sideMenu = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@class,'side-menu-column')]//a[@title='Patient List']/i")));
            sideMenu.Click();
            Thread.Sleep(5000);


            IWebElement medical_Record = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@title = 'Medical Record']/i")));
            medical_Record.Click();
            Thread.Sleep(5000);
            IWebElement addFile = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='newChooseFile']/following-sibling::a")));
            //addFile.Click();
            Thread.Sleep(3000);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('newChooseFile').style.display='block';");
            IWebElement fileInput = driver.FindElement(By.Id("newChooseFile"));

            
            string filePath = @"C:\Users\ibz\Documents\testfile.docx";
            fileInput.SendKeys(filePath);
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@id='newChooseFile']/following-sibling::a[.//text()[normalize-space()='Save']]")).Click();

            Thread.Sleep(5000);

            medical_Record = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@title = 'Medical Record']/i")));
            medical_Record.Click();
          
            Thread.Sleep(5000);
            IWebElement fileUploaded = driver.FindElement(By.XPath("//*[@id='tblattachmed']//div[@title='testfile.docx']/a"));
            if (fileUploaded.Text == "Testfile")
            {
                Console.WriteLine("Successfull");
            }
        }
        finally
        {
            driver.Quit();
        }
    }
}
