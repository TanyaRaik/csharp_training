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
    public class GrourRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            OpenMainPage();
            Login(new AccountData("admin", "secret"));
            GoToGroupPage();
            SelectGroup(1);
            RemoveGroup();
            ReturnToGroupsPage();
        }
    }
}
