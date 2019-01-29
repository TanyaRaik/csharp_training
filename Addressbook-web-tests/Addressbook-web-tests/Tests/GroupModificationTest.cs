using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("new");
            newData.Header = "new";
            newData.Footer = "new";

            app.Groups.Modify(1, newData);
        }
    }
}
