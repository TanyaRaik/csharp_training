using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            if (app.Groups.IsGroupExists())
            {
                if (app.Groups.IsGroupExists())
                {
                    return;
                }
                {
                    GroupData group = new GroupData("a");
                    group.Header = "b";
                    group.Footer = "c";
                    app.Groups.Create(group);
                }
                GroupData newData = new GroupData("new");
                newData.Header = null;
                newData.Footer = null;

                List<GroupData> newGroups = app.Groups.GetGroupList();

                app.Groups.Modify(0, newData);

                List<GroupData> oldGroups = app.Groups.GetGroupList();
                Assert.AreEqual(oldGroups.Count, newGroups.Count);
            }
        }
    }
}
