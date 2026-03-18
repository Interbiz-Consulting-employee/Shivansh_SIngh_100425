using OpenQA.Selenium;
using System;
using System.IO;

namespace ReqnrollBDDProject.Utilities
{
    internal static class ScreenshotHelper
    {
        public static string SaveScreenshot(IWebDriver driver, string testName)
        {
            if (driver == null) throw new ArgumentNullException(nameof(driver));

            var folder = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
            if (!Directory.Exists(folder))
            { Directory.CreateDirectory(folder); 
            }

            var fileName = $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            var fullPath = Path.Combine(folder, fileName);

            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Png);

            return fullPath;
        }
    }
}