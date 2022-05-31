using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            if (GroupData.ThereIsGroupInBase())
            {
                app.Groups.Create(new GroupData(GenerateRandomString(20)));
            }            
            if (ContactData.ThereIsContactInBase())
            {
                app.Contacts.CreateContact(new ContactData(GenerateRandomString(20)));
            }


            GroupData group = GroupData.GetAll().FirstOrDefault(gr => ContactData.GetAll().Except(gr.GetContacts()).Count() > 0);
            if (group == null)
            {
                app.Contacts.CreateContact(new ContactData(GenerateRandomString(20)));
                group = GroupData.GetAll()[0];                
            }

            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();                    
            


            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
