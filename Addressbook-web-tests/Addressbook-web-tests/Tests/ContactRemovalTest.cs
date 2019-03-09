using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemoval : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contacts.IsContactExists())
            {

                ContactData contact = new ContactData();
                contact.FirstName = "FirstName";
                contact.MiddleName = "MiddleName";
                contact.LastName = "LastName";
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

                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = ContactData.GetAllContacts();
            ContactData toBeRemoved = oldContacts[0];
            app.Contacts.RemoveContact(toBeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, ContactData.GetAllContacts().Count);

            List<ContactData> newContacts = ContactData.GetAllContacts();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
