using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contacts.ThereIsAcontact(1))
            {
                app.Contacts.CreateContact(new ContactData("AaaaaA"));
            }
            List<ContactData> oldContact = app.Contacts.GetContactList();
            app.Contacts.RemoveContact(0);
            List<ContactData> newContact = app.Contacts.GetContactList();
            oldContact.RemoveAt(0);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }

        

    }
}
