using System;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Microsoft.Dynamics365.UIAutomation.Api.UCI
{
    public class ADFSLogin
    {
        public void ADFSLoginAction(LoginRedirectEventArgs args)

        {
            //Login Page details go here.  You will need to find out the id of the password field on the form as well as the submit button. 
            //You will also need to add a reference to the Selenium Webdriver to use the base driver. 
            //Example
            var drivers = args.Driver;

            drivers.FindElement(By.Name("loginfmt")).SendKeys(args.Username.ToUnsecureString());
            drivers.ClickWhenAvailable(By.Id("idSIButton9"), new TimeSpan(0, 0, 2));
            drivers.FindElement(By.Name("username")).SendKeys("EYCRMCMTestUser10");
            drivers.FindElement(By.Name("password")).SendKeys(args.Password.ToUnsecureString());
            drivers.ClickWhenAvailable(By.Id("okta-signin-submit"), new TimeSpan(0, 0, 2));
            drivers.FindElement(By.Name("answer")).SendKeys("sachin");
            drivers.ClickWhenAvailable(By.XPath("//input[@value='Verify']"), new TimeSpan(0, 0, 2));


            //driver.FindElement(By.Id("passwordInput")).SendKeys(args.Password.ToUnsecureString());
            //driver.ClickWhenAvailable(By.Id("submitButton"), TimeSpan.FromSeconds(2));

            //Insert any additional code as required for the SSO scenario

            //Wait for CRM Page to load
            drivers.WaitUntilVisible(By.XPath(Elements.Xpath[Reference.Login.CrmMainPage])
                            , new TimeSpan(0, 0, 60),
            f => { throw new Exception("Login page failed."); });

        }
    }
}
