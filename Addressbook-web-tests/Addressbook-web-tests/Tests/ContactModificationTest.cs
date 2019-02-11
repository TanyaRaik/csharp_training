using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            if (app.Contacts.IsContactExists())
            {
                return;
            }
            {
                ContactData contact = new ContactData("a");
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
                contact.SAddress = "b";
                contact.SHome = "b";
                contact.SNotice = "b";

                app.Contacts.Create(contact);
            }
            ContactData newData = new ContactData("new");
            newData.MiddleName = "new";
            newData.LastName = "new";
            newData.Nickname = "new";
            newData.Title = "new";
            newData.Company = "new";
            newData.Address = "new";
            newData.Home = "new";
            newData.Mobile = "999";
            newData.Work = "new";
            newData.Fax = "999";
            newData.Email1 = "newb@gmail.com";
            newData.Email2 = "newb1@gmail.com";
            newData.Email3 = "newb2@gmail.com";
            newData.Homepage = "new";
            newData.SAddress = "new";
            newData.SHome = "new";
            newData.SNotice = "new";
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(newData);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);
        }
    }
}