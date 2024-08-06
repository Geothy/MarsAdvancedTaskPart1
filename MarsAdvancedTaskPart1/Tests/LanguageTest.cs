using MarsAdvancedTaskPart1.Model;
using MarsAdvancedTaskPart1.Pages;
using MarsAdvancedTaskPart1.Pages.Components.Profile;
using MarsAdvancedTaskPart1.Steps;
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
        ProfileOverviewComponent profileOverviewComponent;
        ProfileLanguageOverview profileLanguageOverviewObj;
     //  LanguagePage languagePageObj;
        LanguageSteps languageStepsObj;
       
        public LanguageTest()
        { 
            profileOverviewComponent=new ProfileOverviewComponent();
            languageStepsObj=new LanguageSteps();
            profileLanguageOverviewObj=new ProfileLanguageOverview();
        }
        [Test,Order(1), Description("This test adds a new entry in language feature")]
        public void TestAddLanguage()
        {
            profileOverviewComponent.NavigateToLanguageTab();
            languageStepsObj.AddLanguageSteps();     
        }
        [Test, Order(2), Description("This test updates the language")]
        public void TestEditLanguage()
        {
            profileOverviewComponent.NavigateToLanguageTab();
            languageStepsObj.EditLanguageSteps();
        }
        [Test, Order(3), Description("This test deletes the language feature")]
        public void TestDeleteLanguage()
        {
            profileOverviewComponent.NavigateToLanguageTab();
            languageStepsObj.DeleteLanguageSteps();
        }












        /* [Test, Order(2), Description("This test adds a new entry in language feature")]
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
         }*/
    }
}
