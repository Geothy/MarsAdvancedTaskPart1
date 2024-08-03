using MarsAdvancedTaskPart1.Model;
using MarsAdvancedTaskPart1.Pages;
using MarsAdvancedTaskPart1.Utilities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1.Tests
{
    [TestFixture]
    public class LanguageTest:CommonDriver
    {
        ProfilePage profilePageObj;
        LanguagePage languagePageObj;
        private static IWebElement popupMsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private static IWebElement cancelButton => driver.FindElement(By.XPath("//input[@value='Cancel']"));
        string popupMsgInv = "Please enter language and level";
        string popUpMsgSame = "This language is already exist in your language list.";
        string popUpMsgDup = "Duplicated data";
        string popMsgUndefined = "undefined";
        public LanguageTest()
        { 
            profilePageObj=new ProfilePage();
            languagePageObj=new LanguagePage();        
        }
        [Test,Order(1), Description("This test adds a new entry in language feature")]
        public void TestAddLanguage()
        {
            profilePageObj.NavigateToLanguagePanel();
            string addLangFile = "AddLangData.json";
            List<LanguageModel> AddLangData = JsonUtil.ReadJsonData<LanguageModel>(addLangFile);
            foreach (var item in AddLangData)
            {
                    string language = item.AddLanguage;
                    string langLevel = item.ChooseLanguageLevel;
                    languagePageObj.AddLanguage(language, langLevel);
                    WaitUtils.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 1000);
                    Thread.Sleep(1000);
                    string popupMsgBox = popupMsg.Text;
                    Console.WriteLine(popupMsgBox);
                    string popupMsgadd = language + " has been added to your languages";
                    Assert.That(popupMsgBox, Is.EqualTo(popupMsgadd).Or.EqualTo(popupMsgInv).Or.EqualTo(popUpMsgSame).Or.EqualTo(popUpMsgDup));
                    Thread.Sleep(1000);
                    if ((popupMsgBox == popupMsgInv) || (popupMsgBox == popUpMsgSame) || (popupMsgBox == popUpMsgDup))
                    {
                        cancelButton.Click();
                    }
            }                       
        }
        [Test, Order(2), Description("This test adds a new entry in language feature")]
        public void TestEditLanguage()
        {
            TestAddLanguage();
            string editLangFile = "EditLangData.json";
            List<LanguageModel> EditLangData = JsonUtil.ReadJsonData<LanguageModel>(editLangFile);
            foreach (var item in EditLangData)
            {
                string elanguage = item.AddLanguage;
                string elangLevel = item.ChooseLanguageLevel;
                string edtLang=languagePageObj.EditLanguage(elanguage, elangLevel);
                WaitUtils.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 1000);
                Thread.Sleep(1000);
                string popupMsgBox = popupMsg.Text;
                Console.WriteLine(popupMsgBox);
                string popupMsgedit = edtLang + " has been updated to your languages";
                Assert.That(popupMsgBox, Is.EqualTo(popupMsgedit).Or.EqualTo(popupMsgInv).Or.EqualTo(popUpMsgSame).Or.EqualTo(popUpMsgDup));
                Thread.Sleep(1000);
                if ((popupMsgBox == popupMsgInv) || (popupMsgBox == popUpMsgSame) || (popupMsgBox == popUpMsgDup))
                {
                    cancelButton.Click();
                }
            }
        }
    }
}
