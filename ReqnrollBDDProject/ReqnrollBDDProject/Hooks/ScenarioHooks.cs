using AventStack.ExtentReports;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollBDDProject.Drivers;
using ReqnrollBDDProject.Utilities;
using System;

namespace ReqnrollBDDProject.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportManager.InitReport("Reports\\BDDTestReport.html");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportManager.Flush();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var driver = DriverManager.CreateDriver();
            _scenarioContext["Driver"] = driver;

     
            ExtentTest test = ExtentReportManager.CreateTest(
                _scenarioContext.ScenarioInfo.Title,
                _scenarioContext.ScenarioInfo.Description
            );
            _scenarioContext["ExtentTest"] = test;

            ExtentReportManager.LogInfo("Browser launched");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                var test = ExtentReportManager.GetCurrentTest();

                if (_scenarioContext.TestError != null)
                {
                    ExtentReportManager.LogFail(_scenarioContext.TestError.Message);

                    if (_scenarioContext.TryGetValue("Driver", out IWebDriver driver) && driver != null)
                    {
                        var screenshotPath = ScreenshotHelper.SaveScreenshot(driver, _scenarioContext.ScenarioInfo.Title);
                        ExtentReportManager.AddScreenCapture(screenshotPath);
                    }
                }
                else
                {
                    ExtentReportManager.LogPass("Scenario passed");
                }
            }
            catch (Exception ex)
            {
                ExtentReportManager.LogInfo($"AfterScenario exception: {ex.Message}");
            }
            finally
            {
                DriverManager.QuitDriver();
            }
        }
    }
}