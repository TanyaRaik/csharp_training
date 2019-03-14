using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class DeletingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void DeleteContactFromGroupTest()
        {
            List<GroupData> createdGroups = GroupData.GetAllGroups(); 

            if (createdGroups.Count < 1)
            {
                GroupData group = new GroupData("a");
                app.Groups.Create(group);
                createdGroups = GroupData.GetAllGroups();
            }

            GroupData testGroup = createdGroups[0];

            List<ContactData> createdContacts = ContactData.GetAllContacts();

            if (createdContacts.Count < 1)
            {
                 ContactData contactName = new ContactData("FirstName", "LastName");
                 app.Contacts.Create(contactName);
            }

            if (testGroup.GetContacts().Count < 1)
            {
                app.Contacts.AddContactToGroup(ContactData.GetAllContacts().First(), testGroup);
            }

            List<ContactData> oldContacts = testGroup.GetContacts();
            ContactData contact = oldContacts[0]; 

            app.Contacts.DeleteContactFromGroup(contact, testGroup);

            List<ContactData> newContacts = testGroup.GetContacts();

            oldContacts.RemoveAt(0);

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}