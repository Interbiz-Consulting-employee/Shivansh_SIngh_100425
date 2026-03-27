using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace TestingDME.Utilities
{
    public class ExtentManager
    {
        private static readonly Lazy<ExtentReports> _extent = new Lazy<ExtentReports>(() => {
            // Generates report in ProjectRoot/TestReports
            string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string reportPath = Path.Combine(projectPath, "TestReports");

            if (!Directory.Exists(reportPath)) Directory.CreateDirectory(reportPath);

            var reporter = new ExtentHtmlReporter(Path.Combine(reportPath, "index.html"));
            var extent = new ExtentReports();
            extent.AttachReporter(reporter);
            return extent;
        });

        public static ExtentReports GetInstance() => _extent.Value;
    }
}