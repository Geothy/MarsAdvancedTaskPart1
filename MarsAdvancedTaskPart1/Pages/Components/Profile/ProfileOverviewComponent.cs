using MarsAdvancedTaskPart1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1.Pages.Components.Profile
{
    public class ProfileOverviewComponent:CommonDriver
    {


        private static IWebElement languageTab;
        private static IWebElement skillsTab;
        private static IWebElement educationTab;
        private static IWebElement certificationTab;
        private IReadOnlyList<IWebElement> delLanguages;

        public void renderComponents()
        {
            try
            {
                languageTab = driver.FindElement(By.XPath("//a[text()='Languages']"));
                skillsTab = driver.FindElement(By.XPath("//a[text()='Skills']"));
                educationTab = driver.FindElement(By.XPath("//a[text()='Education']"));
                certificationTab = driver.FindElement(By.XPath("//a[text()='Certifications']"));
                delLanguages = driver.FindElements(By.CssSelector("i[class='remove icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void NavigateToLanguageTab()
        {
            renderComponents();
            languageTab.Click();
            Thread.Sleep(1000);
        }
        public void ClearLangData()
        {
            try
            {
                renderComponents();
                languageTab.Click();
                foreach (var button in delLanguages)
                {
                    WaitUtils.WaitToBeClickable(driver, "cssselector", "i[class='remove icon']", 20);
                    button.Click();
                }
            }
            catch (StaleElementReferenceException e)
            {
                renderComponents();
                foreach (var button1 in delLanguages)
                {
                    Thread.Sleep(100);
                    WaitUtils.WaitToBeClickable(driver, "cssselector", "i[class='remove icon']", 20);
                    button1.Click();
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Nothing to delete");
            }

        }
        public void NavigateToSkillsTab()
        {
            renderComponents();
            skillsTab.Click();
            Thread.Sleep(1000);
        }
        public void NavigateToEducationTab()
        {
            renderComponents();
            educationTab.Click();
        }
        public void NavigateToCertificationTab()
        {
            renderComponents();
            certificationTab.Click();            
        }
    }
}
