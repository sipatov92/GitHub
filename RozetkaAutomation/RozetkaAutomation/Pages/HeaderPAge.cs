using OpenQA.Selenium;
using RozetkaAutomation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RozetkaAutomation.Pages
{
    [Binding]
    class HeaderPage : BasePage
    {
        public BaseControl SearchField
        {
            get
            {
                //return this.GetControl("XPath", "//input[@class='rz-header-search-input-text passive']");
                return this.GetControl("SearchField");
            }
        }

        public BaseControl ButtonSearch
        {
            get
            {
                //return this.GetControl("XPath", "//button[@name='rz-search-button']");
                return this.GetControl("ButtonSearch");
            }
        }
    }
}
