using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("poi");
            newData.Lastname = null;

            app.Contacts.CreateContactIfContactListEmpty();
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(newData);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].Firstname = newData.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
