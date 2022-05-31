using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class RemoveContactFromGroupTests : AuthTestBase
    {
        [Test]

        public void TestRemoveFromGroup()
        {
            if (GroupData.ThereIsGroupInBase())
            {
                app.Groups.Create(new GroupData(GenerateRandomString(20)));
            }
            if (ContactData.ThereIsContactInBase())
            {
                app.Contacts.CreateContact(new ContactData(GenerateRandomString(20)));
            }



            GroupData group = GroupData.GetAll().FirstOrDefault(gr => gr.GetContacts().Count() > 0);
            if (group == null)
            {
                group = GroupData.GetAll()[0];
                app.Contacts.AddContactToGroup(ContactData.GetAll().First(), group);
            }
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Intersect(oldList).First();




            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();

            ContactData toBeRemoved = oldList[0];
            newList.Sort();
            oldList.Sort();
            Assert.AreNotEqual(oldList, newList);                        
            Assert.True(newList.FirstOrDefault(c => c.Id == toBeRemoved.Id) is null ? true : false);           

        }
    }
}
