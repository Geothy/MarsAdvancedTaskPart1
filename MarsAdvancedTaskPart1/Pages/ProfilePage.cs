using MarsAdvancedTaskPart1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MarsAdvancedTaskPart1.Pages
{
    public class ProfilePage:CommonDriver
    {
        private static IWebElement languageTab => driver.FindElement(By.XPath("//a[text()='Languages']"));
        private static IWebElement skillsTab => driver.FindElement(By.XPath("//a[text()='Skills']"));
    
        public void NavigateToLanguagePanel()
        {

            try
            {
                WaitUtils.WaitToBeVisible(driver, "XPath", "//a[text()='Languages']",10);                
                languageTab.Click();
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Assert.Fail("Panel not clickable");
            }

        }
        public void ClearLangData()
        {
            try
            {
               WaitUtils.PresenceOfElement(driver, "xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i", 10);

                WaitUtils.WaitToBeClickable(driver, "xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i", 10);
                var delEButton = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
                foreach (var button in delEButton)
                {
                   button.Click();
                }
            }
            catch (StaleElementReferenceException e)
            {
                driver.Navigate().Refresh();
                WaitUtils.PresenceOfElement(driver, "xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i", 10);
                var delButton = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
                foreach (var button1 in delButton)
                {
                    Thread.Sleep(100);
                    button1.Click();
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Nothing to delete");
            }

        }
        public void NavigateToSkillsPanel()
        {
            try
            {
                WaitUtils.WaitToBeVisible(driver, "XPath", "//a[text()='Skills']",10);               
                skillsTab.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Panel not clickable");
            }
        }
      
        public void ClearSkillData()
        {
            try
            {
                var delButton = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                foreach (var button in delButton)
                {
                    Thread.Sleep(100);
                    button.Click();
                }
                Thread.Sleep(100);
            }

            catch (StaleElementReferenceException e)
            {
                var delButton = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                foreach (var button1 in delButton)
                {
                    Thread.Sleep(100);
                    button1.Click();
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Nothing to delete");
            }
        }

    }
}
