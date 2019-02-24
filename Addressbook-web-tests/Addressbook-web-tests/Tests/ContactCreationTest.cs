using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateContactInAddressBook : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> groups = new List<ContactData>();
            for (int i = 0; i < 3; i++)
            {
                groups.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(10))
                {
                    
                    MiddleName = GenerateRandomString(20),
                    Nickname = GenerateRandomString(20),
                    Title = GenerateRandomString(20),
                    Company = GenerateRandomString(20),
                    Address = GenerateRandomString(20),
                    Home = GenerateRandomString(20),
                    Mobile = GenerateRandomString(20),
                    Work = GenerateRandomString(20),
                    Fax = GenerateRandomString(20),
                    Email1 = GenerateRandomString(20),
                    Email2 = GenerateRandomString(20),
                    Email3 = GenerateRandomString(20),
                    Homepage = GenerateRandomString(20),
                });
            }
            return groups;

        }
 
        [Test, TestCaseSource("RandomContactDataProvider")]
        public void CreateContactTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count+1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }

        [Test]
        public void EmptyCreateContactTest()
        {
            ContactData contact = new ContactData();
            contact.FirstName = "";
            contact.MiddleName = "";
            contact.LastName = "";
            contact.Nickname = "";
            contact.Title = "";
            contact.Company = "";
            contact.Address = "";
            contact.Home = "";
            contact.Mobile = "";
            contact.Work = "";
            contact.Fax = "";
            contact.Email1 = "";
            contact.Email2 = "";
            contact.Email3 = "";
            contact.Homepage = "";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
