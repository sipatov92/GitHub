using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RozetkaAutomation.Core
{
    [Binding]
    class BaseTestCase
    {

        private IWebDriver driver { get { return WebDriverInstance.getInstance(); } }
        [BeforeScenario]
        public void Init()
        {
            this.driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://rozetka.com.ua/");
            ScreenShot.DoScreenShotBeforeAction(TestContext.CurrentContext.Test.Name);
        }

        [AfterScenario]
        public static void TearDown()
        {
            ScreenShot.DoScreenShotAfterAction();
            //driver.Close();
        }
    }

}

