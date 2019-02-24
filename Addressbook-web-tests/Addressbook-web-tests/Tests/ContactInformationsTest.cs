using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationsTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
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
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //verifiration
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void TestContactDetailsInformation()
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
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            string fromPage = app.Contacts.GetContactInformationFromDetails(0);
            Assert.AreEqual(fromPage, fromForm.Info);
        }
    }
}
