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
            GroupData group = GroupData.GetAll()[0];
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
