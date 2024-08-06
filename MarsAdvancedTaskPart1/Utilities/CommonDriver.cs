using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvancedTaskPart1.Pages;
using NUnit.Framework.Internal;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using MarsAdvancedTaskPart1.Pages.Components.Profile;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

namespace MarsAdvancedTaskPart1.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;
        public static ExtentReports extent;
        public static ExtentTest test;
        public static LoginPage loginPageObj;
        public static ProfileOverviewComponent profileOverviewObj;


        [OneTimeSetUp]
        public void ExtentReportSetup()
        {
            try
            {               
                var htmlReporter = new ExtentHtmlReporter("C:\\GitProjects\\MarsAdvancedTaskPart1\\MarsAdvancedTaskPart1\\Reports\\");
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        [SetUp]
        public void BrowserSetup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            loginPageObj = new LoginPage();
            loginPageObj.LoginActions();
            CleanUp();
            var testName = TestContext.CurrentContext.Test.Name;
            test = extent.CreateTest(testName);
        }
        public void CleanUp()
        {
            profileOverviewObj = new ProfileOverviewComponent();
            profileOverviewObj.ClearLangData();
        }
        [TearDown]
        public void CloseTestrun()
        {
            driver.Quit();
        }
        [OneTimeTearDown]
        public void TeardownReport()
        {
            extent.Flush();
        }

    }
}
