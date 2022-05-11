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
            
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];
            app.Contacts.ModifyContact(0, NewContactData);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0] = NewContactData;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(NewContactData, contact);
                }
            }
        }



    }
}
