using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemoval : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.RemoveContact(1);
        }
    }
}
