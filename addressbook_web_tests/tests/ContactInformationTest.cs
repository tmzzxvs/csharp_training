using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]

        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //Verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]

        public void TestContactInformationProperties()
        {
            ContactData fromProperties = app.Contacts.GetContactInformationFromProperties(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //Verification

            //Assert.AreEqual(fromProperties, fromForm);
            //Эта проверка не будет работать т.к. мы получаем все данные контакта из GetContactInformationFromProperties
            //всё в одну переменную.

            Assert.AreEqual(fromProperties.AllData, fromForm.AllData);
        }
    }
}
