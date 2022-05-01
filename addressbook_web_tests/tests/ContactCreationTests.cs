using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {              

        [Test]
        public void ContactCreationTest()
        {

            ContactData contact = new ContactData("new_new");
            contact.Middlename = "dddddd";
            contact.Lastname = "ffffffff";

            List<ContactData> oldContact = app.Contacts.GetContactList();
            app.Contacts.CreateContact(contact);
            List<ContactData> newContact = app.Contacts.GetContactList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
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
