using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            List<GroupData> createdGroups = GroupData.GetAllGroups();

            if (createdGroups.Count < 1)
            {
                GroupData groups = new GroupData("a");
                app.Groups.Create(groups);
                createdGroups = GroupData.GetAllGroups();
            }

            GroupData group = GroupData.GetAllGroups()[0];

            List<ContactData> oldList = group.GetContacts();

            if (oldList.Count < 1)
            {
                ContactData contactName = new ContactData("FirstName", "LastName");
                app.Contacts.Create(contactName);
            }

            ContactData contact = ContactData.GetAllContacts().Except(group.GetContacts()).First(); 

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();

            oldList.Add(contact);

            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}