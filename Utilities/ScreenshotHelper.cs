using OpenQA.Selenium;
using System;
using System.IO;

namespace TestingDME.Utilities
{
    public class ScreenshotHelper
    {
        public static string Capture(string name)
        {
            var ss = ((ITakesScreenshot)DriverManager.GetDriver()).GetScreenshot();
            string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string path = Path.Combine(projectPath, "TestReports", "Screenshots");

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            string fileName = $"{name}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            ss.SaveAsFile(Path.Combine(path, fileName));
            return Path.Combine("Screenshots", fileName);
        }
    }
}