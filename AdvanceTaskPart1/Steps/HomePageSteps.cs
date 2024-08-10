using AdvanceTaskPart1.Pages;
using AdvanceTaskPart1.Pages.Components.ProfilePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskPart1.Steps
{
    public class HomePageSteps
    {
        HomePage homePageObj;
       // ProfileMenuTab profileMenuTabObj;

        public HomePageSteps() 
        { 
            homePageObj = new HomePage();
          
        }
        public void clickOnProfileTab()
        {
            homePageObj.clickProfileTab();
        }     


        public void VerifyLogin()
        {
            homePageObj.getUserName();
        }
    }
}
