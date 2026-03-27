using AventStack.ExtentReports;
using System.Threading;

namespace TestingDME.Utilities
{
    public class ExtentTestManager
    {
        private static ThreadLocal<ExtentTest> _test = new ThreadLocal<ExtentTest>();
        public static ExtentTest GetTest() => _test.Value;
        public static void SetTest(ExtentTest test) => _test.Value = test;
        public static void Unload() => _test.Value = null;
    }
}