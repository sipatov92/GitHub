using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RozetkaAutomation.Core;

namespace RozetkaAutomation.Pages
{
    class HeaderPageF : BasePage
    {

        [FindsBy(How = How.XPath, Using = "//input[@class='rz-header-search-input-text passive']")]
        public IWebElement searchField;
        [FindsBy(How = How.XPath, Using = "//button[@name='rz-search-button']")]
        public IWebElement buttonSearch;

        public static HeaderPageF InitPage()
        {
            HeaderPageF page = new HeaderPageF();
            PageFactory.InitElements(page.driver, page);
            return page;
        }


    }
}
