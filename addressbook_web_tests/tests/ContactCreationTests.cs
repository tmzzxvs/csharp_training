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

            ContactData contact = new ContactData("fn_new_new");
            contact.MiddleName = "dddddd";
            contact.LastName = "ln_ffffffff";

            List<ContactData> oldContact = app.Contacts.GetContactList();
            app.Contacts.CreateContact(contact);
            Assert.AreEqual(oldContact.Count + 1, app.Contacts.GetContactCount());
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
            contact.MiddleName = "";
            contact.LastName = "";

            List<ContactData> oldContact = app.Contacts.GetContactList();
            app.Contacts.CreateContact(contact);
            Assert.AreEqual(oldContact.Count + 1, app.Contacts.GetContactCount());
            List<ContactData> newContact = app.Contacts.GetContactList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);

        }
        [Test]
        public void BadNameContactTest()
        {

            ContactData contact = new ContactData("d'fdf");
            contact.MiddleName = "hh'hh";
            contact.LastName = "jj'jj";

            List<ContactData> oldContact = app.Contacts.GetContactList();
            app.Contacts.CreateContact(contact);
            Assert.AreEqual(oldContact.Count + 1, app.Contacts.GetContactCount());
            List<ContactData> newContact = app.Contacts.GetContactList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);

        }

    }
}
