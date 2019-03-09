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
            if (!app.Groups.IsGroupExists())
            {
                GroupData group = new GroupData("a");
                group.Header = "b";
                group.Footer = "c";
                app.Groups.Create(group);
            }
                GroupData newData = new GroupData("new");
                newData.Header = null;
                newData.Footer = null;

            List<GroupData> oldGroups = GroupData.GetAllGroups();
            GroupData oldData = oldGroups[0];

                app.Groups.Modify(oldData, newData);
                Assert.AreEqual(oldGroups.Count, GroupData.GetAllGroups().Count);

                List<GroupData> newGroups = GroupData.GetAllGroups();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
