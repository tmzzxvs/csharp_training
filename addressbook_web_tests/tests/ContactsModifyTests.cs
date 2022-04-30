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
            ContactData NewContactData = new ContactData("updated_3");
            NewContactData.Middlename = "dddddd";
            NewContactData.Lastname = "ffffffff";

            if (app.Contacts.ThereIsAcontact(1) == false)
                {
                    app.Contacts.CreateContact(new ContactData("AaaaaA"));
                }
            app.Contacts.ModifyContact(1, NewContactData);
        }

        

    }
}
