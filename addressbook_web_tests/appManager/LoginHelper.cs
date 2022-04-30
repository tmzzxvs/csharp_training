using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager manager) 
            : base(manager)
        {
        }
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        public LoginHelper Logout()
        {
            if (IsLoggedIn())
            { 
                driver.FindElement(By.LinkText("Logout")).Click();
                return this;
            }
            return this;
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.LinkText("Logout"));
        }
        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn() 
                && driver.FindElement(By.XPath("//form[@name=\"logout\"]/b")).Text 
                == "(" + account.Username + ")";            
        }
        
    }
}
