﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }
        public ContactHelper CreateContact(ContactData contact)
        {
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.navi.ReturnToHomePage();
            return this;
        }
        

        

        public ContactHelper SubmitContactCreation()
            {
                driver.FindElement(By.Name("submit")).Click();
                return this;
            }

            public ContactHelper FillContactForm(ContactData contact)
            {
                driver.FindElement(By.Name("firstname")).Clear();
                driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
                driver.FindElement(By.Name("middlename")).Clear();
                driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
                driver.FindElement(By.Name("lastname")).Clear();
                driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
                return this;
            }

            public ContactHelper InitNewContactCreation()
            {
                driver.FindElement(By.LinkText("add new")).Click();
                return this;
            }
        
    }
}
