using MarsAdvancedTaskPart1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1.Pages.Components.Profile
{
    public class ProfileLanguageOverview : CommonDriver
    {
        private IWebElement addNewLangButton;
        private IWebElement languageTextbox;
        private static IWebElement selectLangLevelOption;
        private static IWebElement addLangButton;
        private static IWebElement editNewLangButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i"));


        private static IWebElement editLangTextbox => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private static IWebElement editselectLangLevelOption => driver.FindElement(By.Name("level"));
        private static IWebElement updateLangButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement editLangAdded => driver.FindElement(By.XPath("//td[text()='Manglish']"));
        private static IWebElement deleteLangButton => driver.FindElement(By.CssSelector("i[class='remove icon']"));
        private static IWebElement deleteLangAdded => driver.FindElement(By.CssSelector("div[class='ns-box-inner']"));

        public void renderLangComponents()
        {
            try
            {
                addNewLangButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
                languageTextbox = driver.FindElement(By.XPath("//input[@type='text'][@placeholder='Add Language']"));
                selectLangLevelOption = driver.FindElement(By.Name("level"));
                addLangButton = driver.FindElement(By.XPath("//input[@value=\"Add\"]"));
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void AddLanguage(string language, string level)
        {
            renderLangComponents();
            Thread.Sleep(2000);

            addNewLangButton.Click();
            Thread.Sleep(2000);
            languageTextbox.SendKeys(language);
            selectLangLevelOption.Click();
            selectLangLevelOption.SendKeys(level);
            addLangButton.Click();
            Thread.Sleep(3000);
        }
        public string EditLanguage(string language, string level)
        {
            Thread.Sleep(1000);
            // renderComponents();
            editNewLangButton.Click();
            editLangTextbox.Clear();
            editLangTextbox.SendKeys(language);
            editselectLangLevelOption.Click();
            editselectLangLevelOption.SendKeys(level);
            updateLangButton.Click();
            return language;
        }
        public void DeleteLanguage(string language, string level)
        {
            //renderComponents();
            deleteLangButton.Click();
        }
    }
}
