using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {              

        [Test]
        public void ContactCreationTest()
        {

            ContactData contact = new ContactData("new_new");
            contact.Middlename = "dddddd";
            contact.Lastname = "ffffffff";

            app.contacts.CreateContact(contact);


        }          
        
    }
}
