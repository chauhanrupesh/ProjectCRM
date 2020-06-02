using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Sample;
using AventStack.ExtentReports;
using System;
using EtihadProject.Common;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using System.Security;
using Microsoft.Dynamics365.UIAutomation.Browser;

namespace EtihadProject
{
    [TestClass]
    public class LoginCRM
    {
        #region Init & Cleanup
        //Extent Report
        public TestContext TestContext { get; set; }
        public int Val { get; private set; }
        private ScreenshotTaker ScreenshotTaker { get; set; }
        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly SecureString _mfaSecretKey = System.Configuration.ConfigurationManager.AppSettings["MfaSecretKey"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["OnlineCrmUrl"].ToString());

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
        public void LoginCRMApp()
        {
            var client = new WebClient(TestSettings.Options);
            using (var _xrmApp = new XrmApp(client))
                try
                {
                    _xrmApp.OnlineLogin.Login(_xrmUri, _username, _password, _mfaSecretKey);
                    Reporters.LogPassingTestStepToBugLogger("Sub Area Opened successfully");
                }
                catch (Exception)
                {
                    Reporters.LogFailingTestStepToBugLogger("Sub Area not opened");
                    Assert.Fail("Sub Area not opened");
                }
                
                
        }
    }
}