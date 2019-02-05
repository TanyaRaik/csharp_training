﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
         [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("a");
            group.Header = "b";
            group.Footer = "c";
            app.Groups.Create(group);
            app.Logout.Logout();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            app.Groups.Create(group);
            app.Logout.Logout();
        }
    }
}