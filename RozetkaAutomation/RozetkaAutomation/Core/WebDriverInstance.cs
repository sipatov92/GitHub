using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAutomation.Core
{
    class WebDriverInstance
    {
        private WebDriverInstance() { }

        private static IWebDriver instance;

        public static IWebDriver getInstance()
        {
            if (instance == null)
            {
                instance = new ChromeDriver();
            }
            return instance;
         }
    }
}
