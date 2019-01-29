using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateContactInAddressBook : TestBase
    {
 
        [Test]
        public void CreateContactTest()
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
            app.Logout.Logout();
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

            app.Contacts.Create(contact);
            app.Logout.Logout();
        }
    }
}
