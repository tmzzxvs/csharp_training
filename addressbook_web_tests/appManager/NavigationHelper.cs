using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
                {
                    this.baseURL = baseURL;
                }
        public void OpenHomePage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }
        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/group.php"
                           && IsElementPresent(By.Name("new")))
            {
                return;
            };
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void ReturnToGroupsPage()
        {
            if (driver.Url == baseURL + "/group.php"
                           && IsElementPresent(By.Name("new")))
            {
                return;
            };
            driver.FindElement(By.LinkText("group page")).Click();
        }
        public void ClickHomeButton()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
