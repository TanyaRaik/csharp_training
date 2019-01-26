using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateContactInAddressBook : TestBase
    {
 
        [Test]
        public void CreateContactTest()
        {
            OpenMainPage();
            Login(new AccountData("admin", "secret"));
            OpenContactForm();
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
            FillContactForm(contact);
            SubmitContactCreation();
            Logout();
        }
    }
}
