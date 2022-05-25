using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
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
        public ContactHelper ModifyContact(ContactData contact, ContactData NewContactData)
        {
            SelectModifyContactDBtest(contact.Id);
            FillContactForm(NewContactData);
            UpdateContact();
            manager.Navi.ClickHomeButton();
            return this;
        }
        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navi.OpenHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);

        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void SelectContact(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
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
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
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
        public ContactHelper SelectModifyContactDBtest(string contactId)
        {
            driver.FindElement(By.XPath("//a[@href='edit.php?id=" + (contactId) + "']")).Click();
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
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value"),
                        LastName = element.FindElement(By.XPath("./td[2]")).Text
                    });
                }
            }            
            return new List<ContactData>(contactCache);
        }
        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navi.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                 .FindElements(By.TagName("td"));
             string lastName = cells[1].Text;
             string firstName = cells[2].Text;
             string address = cells[3].Text;
             string allEmail = cells[4].Text;
             string allPhones = cells[5].Text;
            
            return new ContactData(firstName) 
            {
                   LastName = lastName,
                   Address = address,
                   AllPhones = allPhones,
                   AllEmails = allEmail
            };
        }
        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navi.OpenHomePage();
            SelectModifyContact(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string faxPhone = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData()
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                NickName = nickName,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                FaxPhone = faxPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
            
        }
        public int GetNumberOfSearchResults()
        {
            manager.Navi.OpenHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
        public ContactData GetContactInformationFromProperties(int index)
        {
            manager.Navi.OpenHomePage();
            ClickContactProperties(index);
            IWebElement data = driver.FindElement(By.XPath("//*[@id='content']"));
            string allData = data.Text;           
            return new ContactData()
            {
               AllData = allData
            };
        }
        private void ClickContactProperties(int index)
        {
            driver.FindElement(By.XPath("(//img[@title='Details'])[" + (index + 1) + "]")).Click();
        }        
    }
}