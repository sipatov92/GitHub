using NUnit.Framework;
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
    class ResultsSteps
    {
        ResultsPage resultsPage = new ResultsPage();
        [Then(@"Item with link (.*) is displayed on the page")]
        public void ThenItemWithLinkIsDisplayedOnThePage(string p0)
        {
            bool actual = resultsPage.ResultsItem(p0).Exists();
            Assert.AreEqual(true, actual, string.Format("Item {0} exists on page, expected {1}, but actual {2}", p0, true, actual));
            //rozetkaPage.SearchField.SetValue(name);
        }
    }
}
