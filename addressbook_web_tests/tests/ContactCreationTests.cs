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
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(10))
                {
                    MiddleName = GenerateRandomString(20),
                    LastName = GenerateRandomString(20)
                });
            }
            return contacts;
        }
        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
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
        public void ContactCreationTestBadName()
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
