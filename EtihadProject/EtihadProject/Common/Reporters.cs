using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EtihadProject.Common
{
    public static class Reporters
    {
        //private static readonly Logger TheLogger = LogManager.GetCurrentClassLogger();
        private static ExtentReports ReportManager { get; set; }
        //private static string ApplicationDebuggingFolder => "c://temp/SHTests";
        private static string CurrentDir = Environment.CurrentDirectory;
        private static string ApplicationDebuggingFolder => CurrentDir.Substring(0, CurrentDir.LastIndexOf("bin")) + "Results\\";
        private static readonly string LibDir = CurrentDir.Substring(0, CurrentDir.LastIndexOf("bin")) + "Common\\";
        private static readonly string htmlConfig = LibDir + "html-config.xml";
        private static string HtmlReportFullPath { get; set; }
        public static string LatestResultsReportFolder { get; set; }
        private static TestContext MyTestContext { get; set; }
        private static ExtentTest CurrentTestCase { get; set; }

        public static void StartReporter()
        {
            //TheLogger.Trace("Starting a one time setup for the entire" +
            //" .SHTests." +
            //"Going to initialize the reporter next...");
            CreateReportDirectory();
            var htmlReporter = new ExtentHtmlReporter(HtmlReportFullPath);
            htmlReporter.LoadConfig(htmlConfig);
            ReportManager = new ExtentReports();
            ReportManager.AttachReporter(htmlReporter);
        }

        private static void CreateReportDirectory()
        {
            var filePath = Path.GetFullPath(ApplicationDebuggingFolder);
            LatestResultsReportFolder = Path.Combine(filePath, DateTime.Now.ToString("MMdd_HHmm"));
            Directory.CreateDirectory(LatestResultsReportFolder);
            HtmlReportFullPath = $"{LatestResultsReportFolder}\\TestResults.html";
            //TheLogger.Trace("Full path of HTML report=>" + HtmlReportFullPath);
        }

        public static void AddTestCaseMetadataToHtmlReport(TestContext testContext)
        {
            MyTestContext = testContext;
            CurrentTestCase = ReportManager.CreateTest(MyTestContext.TestName);
        }

        public static void LogPassingTestStepToBugLogger(string message)
        {
            //TheLogger.Info(message);
            CurrentTestCase.Log(Status.Pass, message);
        }

        public static void LogFailingTestStepToBugLogger(string message)
        {
            //TheLogger.Info(message);
            CurrentTestCase.Log(Status.Fail, message);
        }

        public static void LogTestStepForBugLogger(Status status, string message)
        {
            //TheLogger.Info(message);
            CurrentTestCase.Log(status, message);
        }

        public static void ReportTestOutcome(string screenshotPath)
        {
            var status = MyTestContext.CurrentTestOutcome;

            switch (status)
            {
                case UnitTestOutcome.Failed:
                    //TheLogger.Error($"Test Failed=>{MyTestContext.FullyQualifiedTestClassName}");
                    CurrentTestCase.AddScreenCaptureFromPath(screenshotPath);
                    CurrentTestCase.Fail("Fail");
                    break;
                case UnitTestOutcome.Inconclusive:
                    CurrentTestCase.AddScreenCaptureFromPath(screenshotPath);
                    CurrentTestCase.Warning("Inconclusive");
                    break;
                case UnitTestOutcome.Unknown:
                    CurrentTestCase.Skip("Test skipped");
                    break;
                default:
                    CurrentTestCase.Pass("Pass");
                    break;
            }

            ReportManager.Flush();
        }
    }
}
