using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactsModifyTests : AuthTestBase
    {
        [Test]

        public void ContactModidyTest()
        {
            ContactData NewContactData = new ContactData("updated_01");
            NewContactData.Middlename = "345345";
            NewContactData.Lastname = "456457";

            if (!app.Contacts.ThereIsAcontact(1))
                {
                    app.Contacts.CreateContact(new ContactData("AaaaaA"));
                }
            List<ContactData> oldContact = app.Contacts.GetContactList();
            app.Contacts.ModifyContact(0, NewContactData);
            List<ContactData> newContact = app.Contacts.GetContactList();
            oldContact[0].Firstname = NewContactData.Firstname;
            oldContact[0].Lastname = NewContactData.Lastname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }

        

    }
}
