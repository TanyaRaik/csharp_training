using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {

        [Test]
        public void ContactModificationTest()
        {
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

            app.Contacts.Modify(newData);
        }
    }
}