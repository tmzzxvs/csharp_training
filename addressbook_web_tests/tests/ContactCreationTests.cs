using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

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

            app.Contacts.CreateContact(contact);
        }
        [Test]
        public void EmptyContactCreationTest()
        {

            ContactData contact = new ContactData("");
            contact.Middlename = "";
            contact.Lastname = "";

            app.Contacts.CreateContact(contact);
        }

    }
}
