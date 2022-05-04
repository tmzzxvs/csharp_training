using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

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
            ReturnToHomePage();
            return this;
        }
        public ContactHelper RemoveContact(int v)
        {
            SelectContact(v);
            RemoveContactClick();
            CloseAlertMessage();
            manager.Navi.ClickHomeButton();
            return this;
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        public ContactHelper ModifyContact(int v, ContactData NewContactData)
        {
            SelectModifyContact(v);
            FillContactForm(NewContactData);
            UpdateContact();
            manager.Navi.ClickHomeButton();
            return this;
        }
        public bool ThereIsAcontact(int v)
        {
            return IsElementPresent(By.XPath("//tr[@name='entry'][" + v + "]//img[@title='Edit']"));
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper RemoveContactClick()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//tr[@name='entry'][" + (index+1) + "]/ td/input")).Click();
            return this;
        }
        public ContactHelper CloseAlertMessage()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public ContactHelper SelectModifyContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@title='Edit'])[" + (index+1) + "]")).Click();
            return this;
        }
        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.XPath("//input[@value='Update'][2]")).Click();
            contactCache = null;
            return this;
        }

        private List<ContactData> contactCache = null;
        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    contactCache.Add(new ContactData(element.FindElement(By.XPath("./td[3]")).Text)
                    {
                        Lastname = element.FindElement(By.XPath("./ td[2]")).Text
                    });
                }
            }            
            return new List<ContactData>(contactCache);
        }

    }
}
