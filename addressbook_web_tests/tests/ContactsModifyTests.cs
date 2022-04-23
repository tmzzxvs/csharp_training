using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactsModifyTests : TestBase
    {
        [Test]

        public void ContactModidyTest()
        {
            ContactData NewContactData = new ContactData("updated_3");
            NewContactData.Middlename = "dddddd";
            NewContactData.Lastname = "ffffffff";

            app.Contacts.ModifyContact(1, NewContactData);
        }

        

    }
}
