using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (!app.Groups.IsGroupExists())
            {
                GroupData group = new GroupData("a");
                group.Header = "b";
                group.Footer = "c";
                app.Groups.Create(group);
            }

            List<GroupData> oldGroups = GroupData.GetAllGroups();
            GroupData toBeRemoved = oldGroups[0];
            app.Groups.RemoveGroup(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, GroupData.GetAllGroups().Count);

            List<GroupData> newGroups = GroupData.GetAllGroups(); ;
            
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
