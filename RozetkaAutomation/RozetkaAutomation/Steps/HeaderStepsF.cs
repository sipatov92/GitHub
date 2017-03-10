using RozetkaAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RozetkaAutomation.Steps
{
    [Binding]
    class HeaderStepsF
    {
        HeaderPageF page = HeaderPageF.InitPage();

        [Given(@"I have entered (.*) into the search field")]
        public void GivenIHaveEnteredIntoTheSearchField(string p0)
        {
            page.searchField.SendKeys(p0);
        }

        [When(@"I press Search Button")]
        public void PressSearchButton()
        {
            page.buttonSearch.Click();
        }


    }
}
