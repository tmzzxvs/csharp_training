using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(10))
                {
                    MiddleName = GenerateRandomString(20),
                    LastName = GenerateRandomString(20)
                });
            }
            return contacts;
        }
        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string Line in lines)
            {
                string[] parts = Line.Split(',');
                contacts.Add(new ContactData(parts[0])
                {
                    LastName = parts[1],
                    MiddleName = parts[2]
                });
            }
            return contacts;
        }
        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contacts.xml"));
        }
        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

        public static IEnumerable<ContactData> ContactDataFromXlsxFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"contacts.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                contacts.Add(new ContactData()
                {
                    FirstName = range.Cells[i, 1].Value,
                    MiddleName = range.Cells[i, 1].Value,
                    LastName = range.Cells[i, 1].Value
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return contacts;
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContact = ContactData.GetAll();
            app.Contacts.CreateContact(contact);
            Assert.AreEqual(oldContact.Count + 1, app.Contacts.GetContactCount());
            List<ContactData> newContact = ContactData.GetAll();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }





        [Test]
        public void ContactCreationTestBadName()
        {
            ContactData contact = new ContactData("d'fdf");
            contact.MiddleName = "hh'hh";
            contact.LastName = "jj'jj";

            List<ContactData> oldContact = app.Contacts.GetContactList();
            app.Contacts.CreateContact(contact);
            Assert.AreEqual(oldContact.Count + 1, app.Contacts.GetContactCount());
            List<ContactData> newContact = app.Contacts.GetContactList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);

        }

    }
}
