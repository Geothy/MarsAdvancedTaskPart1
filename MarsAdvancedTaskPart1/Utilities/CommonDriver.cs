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

namespace MarsAdvancedTaskPart1.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;
        public static LoginPage loginPageObj;
        public static ProfilePage profilePageObj;

        [SetUp]
        public void BrowserSetup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            loginPageObj = new LoginPage();
            loginPageObj.LoginActions();
            CleanUp();
        }
        public void CleanUp()
        {
            profilePageObj = new ProfilePage();
            profilePageObj.NavigateToLanguagePanel();
            profilePageObj.ClearLangData();
          //  profilePageObj.NavigateToSkillsPanel();
          //  profilePageObj.ClearSkillData();
        }
        [TearDown]
        public void CloseTestrun()
        {
            driver.Quit();
        }

    }
}
