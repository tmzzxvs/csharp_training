using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactsModifyTests : ContactTestBase
    {
        [Test]

        public void ContactModidyTest()
        {
            ContactData NewContactData = new ContactData("updated_01");
            NewContactData.MiddleName = "345345";
            NewContactData.LastName = "456457";

            if (!app.Contacts.ThereIsAcontact(1))
                {
                    app.Contacts.CreateContact(new ContactData("AaaaaA"));
                }
            
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[0];
            app.Contacts.ModifyContact(oldData, NewContactData);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            List<ContactData> newContacts = ContactData.GetAll();
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
