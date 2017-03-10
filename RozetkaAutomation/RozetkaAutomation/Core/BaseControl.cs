using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RozetkaAutomation.Core
{
    [Binding]
    class BaseControl
    {
        public BasePage Page { get; set; }
        public string ControlName { get; set; }

        public string ControlType { get; set; }

        public string SelectorType { get; set; }
        public string Selector { get; set; }

        public IWebElement webElement
        {
            get
            {
                IWebElement element;
                switch (this.SelectorType)
                {
                    case "XPath": element = this.Page.driver.FindElement(By.XPath(this.Selector)); break;
                    case "CSS": element = this.Page.driver.FindElement(By.CssSelector(this.Selector)); break;
                    case "ID": element = this.Page.driver.FindElement(By.CssSelector(this.Selector)); break;
                    default: element = this.Page.driver.FindElement(By.XPath(this.Selector)); break;
                }
                return Page.driver.FindElement(By.XPath(this.Selector));
            }
        }

        public BaseControl(BasePage page, string controlName)
        {
            this.Page = page;
            this.ControlName = controlName;
            BaseControl initControl;
            initControl = page.InitControl(this);
            this.Selector = initControl.Selector;
            this.SelectorType = initControl.SelectorType;


        }

        public BaseControl(BasePage page, string controlName, IDictionary<string, string> parameters) : this(page, controlName)
        {
            this.Selector = this.HandleParameters(this.Selector, parameters);
        }

        public void SetValue(String value)
        {
            if (this.webElement != null)
            {
                webElement.SendKeys(value);
            }
            else
            {
                throw new Exception("Cannot set value to uninitialized control");
            }
        }

        public String GetValue()
        {
            String value;
            if (webElement != null)
            {
                value = webElement.Text;
            }
            else
            {
                throw new Exception("Cannot get value from uninitialized control");
            }
            return value;
        }
        public void Click()
        {
            if (webElement != null)
            {
                webElement.Click();
            }
            else
            {
                throw new Exception("Cannot click on uninitialized control");
            }
        }

        public bool Exists()
        {
            if (webElement != null)
            {
                return webElement.Displayed;
            }
            else
            {
                throw new Exception("Cannot click on uninitialized control");
            }
        }

        private string HandleParameters(string searchCriteria, IDictionary<string, string> parameters)
        {

            string result = searchCriteria;
            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                if (searchCriteria.ToString().Contains(parameter.Key))
                {
                    result = result.Replace(parameter.Key, parameter.Value);
                }
            }

            return result;
        }
    }
}
