using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("poi");
            newData.LastName = null;

            app.Contacts.CreateContactIfContactListEmpty();
            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeModified = oldContacts[0];

            app.Contacts.Modify(toBeModified, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();

            toBeModified.FirstName = newData.FirstName;
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
