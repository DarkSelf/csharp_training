using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class ContactRemovalFromGroupTests : AuthTestBase
    {
        [Test]

        public void ContactRemoveFromGroupTest()
        {
            app.Contacts.CreateContactIfContactListEmpty();
            app.Groups.CreateGroupIfGroupListEmpty();
            GroupData group = GroupData.GetAll()[0];
            ContactData newContact = ContactData.GetAll()[0];
            app.Contacts.AddContactToGroupIfGroupEmpty(newContact, group);

            List<ContactData> oldList = group.GetContacts();
            ContactData contact = group.GetContacts().First();


            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();

            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
