using MarsAdvancedTaskPart1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1.Pages
{
    public class LanguagePage : CommonDriver
    {
        private static IWebElement addNewLangButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private static IWebElement languageTextbox => driver.FindElement(By.XPath("//input[@type='text'][@placeholder='Add Language']"));
        private static IWebElement selectLangLevelOption => driver.FindElement(By.Name("level"));
        private static IWebElement addLangButton => driver.FindElement(By.XPath("//input[@value=\"Add\"]"));
        private static IWebElement popupmsg => driver.FindElement(By.CssSelector("div[class='ns-box-inner']"));
        private static IWebElement editNewLangButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i"));
        private static IWebElement editLangTextbox => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private static IWebElement editselectLangLevelOption => driver.FindElement(By.Name("level"));
        private static IWebElement updateLangButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement editLangAdded => driver.FindElement(By.XPath("//td[text()='Manglish']"));
        private static IWebElement deleteLangButton => driver.FindElement(By.CssSelector("i[class='remove icon']"));
        private static IWebElement deleteLangAdded => driver.FindElement(By.CssSelector("div[class='ns-box-inner']"));


        public void AddLanguage(string language, string level)
        {
            addNewLangButton.Click();
            languageTextbox.SendKeys(language);
            selectLangLevelOption.Click();
            selectLangLevelOption.SendKeys(level);
            addLangButton.Click();
            Thread.Sleep(3000);
        }
        public string EditLanguage(string language, string level)
        {
            Thread.Sleep(1000);
            editNewLangButton.Click();            
            editLangTextbox.Clear();
            editLangTextbox.SendKeys(language);
            editselectLangLevelOption.Click();
            editselectLangLevelOption.SendKeys(level);
            Thread.Sleep(1000);
            updateLangButton.Click();
            return language;
        }
        public void RemoveLanguage()
        {
            deleteLangButton.Click();
        }
    }
}
