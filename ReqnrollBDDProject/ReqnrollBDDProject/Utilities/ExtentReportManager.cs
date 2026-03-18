using System;
using System.IO;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace ReqnrollBDDProject.Utilities
{
    internal static class ExtentReportManager
    {
        private static ExtentReports _extent;
        private static ExtentHtmlReporter _htmlReporter;

        private static readonly ThreadLocal<ExtentTest> _currentTest = new ThreadLocal<ExtentTest>();
        public static void InitReport(string reportFileName = "BDDTestReport")
        {
            var reportDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Reports");

            if (!Directory.Exists(reportDirectory))
            {
                Directory.CreateDirectory(reportDirectory);
            }

            var reportPath = Path.Combine(reportDirectory,$"{reportFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.html");

            _htmlReporter = new ExtentHtmlReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(_htmlReporter);
        }


        public static ExtentTest CreateTest(string testName, string description = null)
        {
            var test = _extent.CreateTest(testName, description);
            _currentTest.Value = test;
            return test;
        }
        public static void AddScreenCapture(string path, string title = null)
        {
            if (File.Exists(path))
                _currentTest.Value?.AddScreenCaptureFromPath(path, title);
        }

        public static ExtentTest GetCurrentTest() => _currentTest.Value;
        public static void Flush() => _extent?.Flush();

        public static void LogInfo(string message) => _currentTest.Value?.Info(message);
        public static void LogPass(string message) => _currentTest.Value?.Pass(message);
        public static void LogFail(string message) => _currentTest.Value?.Fail(message);

     
 
    }
}