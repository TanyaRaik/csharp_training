﻿using System;
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
    public class GroupCreationTests : TestBase
    {
         [Test]
        public void GroupCreationTest()
        {
            OpenMainPage();
            Login(new AccountData("admin", "secret"));
            GoToGroupPage();
            InitGroupCreation();
            GroupData group = new GroupData("a");
            group.Header = "b";
            group.Footer = "c";
            FillGroupForm(group);
            SubmitGroupCreation();
            Logout();
        }
    }
}
