using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager manager)
            {
                this.driver = manager.Driver;
                this.manager = manager;
            }
        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }


        }
    }
    
}