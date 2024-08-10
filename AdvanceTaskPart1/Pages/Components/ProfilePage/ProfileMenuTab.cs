using AdvanceTaskPart1.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskPart1.Pages.Components.ProfilePage
{
    public class ProfileMenuTab : CommonDriver
    {
        private static IWebElement languagesTab;
        private static IWebElement skillsTab;
        private static IReadOnlyList<IWebElement> delIcon;
        public void renderProfileTabComponents()
        {
            try
            {
                languagesTab = driver.FindElement(By.XPath("//a[text()='Languages']"));
                skillsTab = driver.FindElement(By.XPath("//a[text()='Skills']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderDeleteIcon()
        {

            try 
            {
                delIcon = driver.FindElements(By.CssSelector("i[class='remove icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void clickLangaugesTab()
        {
            renderProfileTabComponents();
            languagesTab.Click();
            Thread.Sleep(1000);
        }
        public void clickSkillsTab()
        {
            renderProfileTabComponents();
            skillsTab.Click();
            Thread.Sleep(1000);
        }
        public void ClearLangData()
        {
            try
            {
                clickLangaugesTab();
                renderDeleteIcon();
                foreach (var button in delIcon)
                {
                    WaitUtils.WaitToBeClickable(driver, "cssselector", "i[class='remove icon']", 20);
                    button.Click();
                }
            }
            catch (StaleElementReferenceException e)
            {
                clickLangaugesTab();
                renderDeleteIcon();
                foreach (var button1 in delIcon)
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
        public void ClearSkillData()
        {
            try
            {
                clickSkillsTab();
                renderDeleteIcon();
                foreach (var button in delIcon)
                {
                    WaitUtils.WaitToBeClickable(driver, "cssselector", "i[class='remove icon']", 20);
                    button.Click();
                }
            }
            catch (StaleElementReferenceException e)
            {
                clickSkillsTab();
                renderDeleteIcon();
                foreach (var button1 in delIcon)
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
       
    }
}
