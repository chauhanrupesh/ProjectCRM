using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.Dynamics365.UIAutomation.Sample.UCI;
using EtihadProject.Common;

namespace EtihadProject.Contacts
{
    [TestClass]
    public class UnitTest
    {
        #region Init & Cleanup
        //Extent Report
        public TestContext TestContext { get; set; }
        public int Val { get; private set; }
        private ScreenshotTaker ScreenshotTaker { get; set; }
        //private readonly Uri _xrmUri = new Uri(Utils.ResolveAppUrl(AppName.CC).ToString());
        //string[] Multiple_BusinessUnit;
        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            Reporters.AddTestCaseMetadataToHtmlReport(TestContext);
        }
        [TestCleanup]
        public void TearDownForEverySingleTestMethod()
        {
            try
            {
                if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed ||
                    TestContext.CurrentTestOutcome == UnitTestOutcome.Inconclusive)
                {
                    Reporters.ReportTestOutcome(ScreenshotTaker.ScreenshotFilePath);
                }
                else
                {
                    Reporters.ReportTestOutcome("");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            int abc = 56, def = 23;
            int val = abc + def;
            try
            {
                Console.WriteLine(val);
                Reporters.LogPassingTestStepToBugLogger("Pass");
            }
            catch (Exception)
            {
                Reporters.LogFailingTestStepToBugLogger("Fail");
            }
        }

    }
}
