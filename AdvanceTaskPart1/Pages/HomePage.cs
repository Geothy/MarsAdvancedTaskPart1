using AdvanceTaskPart1.Pages.Components.ProfilePage;
using AdvanceTaskPart1.Utils;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskPart1.Pages
{
    public class HomePage:CommonDriver
    {
        private static IWebElement checkUser;
        private static IWebElement profileTab;
      
        public void clickProfileTab()
        {
            renderProfileTabComponent();
            profileTab.Click();

        }
        public void renderProfileTabComponent()
        {
            try
            {
                profileTab = driver.FindElement(By.LinkText("Profile"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
      
        public void renderUserComponent()
        {
            try
            {
                checkUser = driver.FindElement(By.XPath("//span[contains(@class,'item ui')]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        public String getUserName()
        {
            try
            {
                renderUserComponent();
                Thread.Sleep(2000);
                Console.WriteLine(checkUser.Text);
               return checkUser.Text;                
            }
            catch (Exception ex)
            {
                driver.Navigate().Refresh();
                return ex.Message;
            }            
        }

    }
}
