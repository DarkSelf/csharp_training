using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]

        public void GroupModificationTest()
        {
            GroupData newData = new GroupData();
            newData.Name = "Uio";
            newData.Header = null;
            newData.Footer = null;

            app.Groups.CreateGroupIsGroupListEmpty();
            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData toBeModified = oldGroups[0];

            app.Groups.Modify(toBeModified, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            toBeModified.Name = newData.Name;
            Assert.AreEqual(oldGroups, newGroups);


        }
    }
}
