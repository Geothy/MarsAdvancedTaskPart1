using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.AssertHelpers;
using MarsAdvancedTaskPart1.Model;
using MarsAdvancedTaskPart1.Pages;
using MarsAdvancedTaskPart1.Pages.Components.Profile;
using MarsAdvancedTaskPart1.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1.Steps
{
    public class LanguageSteps:CommonDriver
    {
        ProfileLanguageOverview profLangOverviewObj;
        ProfileOverviewComponent profOverviewComponent;
        
        public LanguageSteps()
        {
           profOverviewComponent = new ProfileOverviewComponent();
           profLangOverviewObj = new ProfileLanguageOverview();
        }
        public void AddLanguageSteps()
        {
            string addLangFile = "AddLangData.json";
            List<LanguageModel> AddLangData = JsonUtil.ReadJsonData<LanguageModel>(addLangFile);
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            foreach (var item in AddLangData)
            {
                string language = item.AddLanguage;
                string langLevel = item.ChooseLanguageLevel;
                profLangOverviewObj.AddLanguage(language, langLevel);
                LanguageAssertHelper.AddLanguageAssert(language);
            }
            test.Log(Status.Pass, "Adding Education Test Passed");
        }
        public void EditLanguageSteps()
        {
            AddLanguageSteps();
            string editLangFile = "EditLangData.json";
            List<LanguageModel> EditLangData = JsonUtil.ReadJsonData<LanguageModel>(editLangFile);
            foreach (var item in EditLangData)
            {
                string elanguage = item.AddLanguage;
                string elangLevel = item.ChooseLanguageLevel;
                profLangOverviewObj.EditLanguage(elanguage, elangLevel);
                LanguageAssertHelper.EditLanguageAssert(elanguage);
            }
            test.Log(Status.Pass, "Editing Education Test Passed");
        }
        public void DeleteLanguageSteps()
        {
            string deleteLangFile = "DeleteLangData.json";
            List<LanguageModel> DeleteLangData = JsonUtil.ReadJsonData<LanguageModel>(deleteLangFile);
            foreach (var item in DeleteLangData)
            {
                string dlanguage = item.AddLanguage;
                string dlangLevel = item.ChooseLanguageLevel;
                profLangOverviewObj.AddLanguage(dlanguage,dlangLevel);
                profLangOverviewObj.DeleteLanguage(dlanguage, dlangLevel);
                LanguageAssertHelper.DeleteLanguageAssert(dlanguage);
            }
            test.Log(Status.Pass, "Deleting Education Test Passed");

        }
    }
}
