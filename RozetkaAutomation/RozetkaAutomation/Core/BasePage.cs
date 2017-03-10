using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RozetkaAutomation.Core
{
    [Binding]
    class BasePage : Page
    {
        public IWebDriver driver = WebDriverInstance.getInstance();

        //public BaseControl GetControl(String selectorType, String selector)
        //{
        //    this.InitPage();
        //    IWebElement element = driver.FindElement(By.XPath(selector));
        //    BaseControl baseControl = new BaseControl(element);
        //    return baseControl;
        //}

        public BaseControl GetControl(String controlName)
        {
            return new BaseControl(this, controlName);
        }

        public BaseControl GetControl(String controlName, IDictionary<string, string> parameters)
        {
            return new BaseControl(this, controlName, parameters);
        }

        protected void InitPage()
        {
            
        }
    }

   
}

