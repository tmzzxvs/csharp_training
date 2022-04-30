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
            if (app.Contacts.ThereIsAcontact(1) == false)
            {
                app.Contacts.CreateContact(new ContactData("AaaaaA"));
            }
            app.Contacts.RemoveContact(1);
        }

        

    }
}
