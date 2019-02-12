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
 
        [Test]
        public void CreateContactTest()
        {
            ContactData contact = new ContactData("a");
            contact.MiddleName = "MiddleName";
            contact.LastName = "b";
            contact.Nickname = "Nickname";
            contact.Title = "Title";
            contact.Company = "Company";
            contact.Address = "Address";
            contact.Home = "Home";
            contact.Mobile = "111";
            contact.Work = "Work";
            contact.Fax = "222";
            contact.Email1 = "b@gmail.com";
            contact.Email2 = "b1@gmail.com";
            contact.Email3 = "b2@gmail.com";
            contact.Homepage = "Homepage";
            contact.SAddress = "b";
            contact.SHome = "b";
            contact.SNotice = "b";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }

        [Test]
        public void EmptyCreateContactTest()
        {
            ContactData contact = new ContactData("");
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
            contact.SAddress = "";
            contact.SHome = "";
            contact.SNotice = "";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
