using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]

        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("updated");
            newData.Footer = "ttt";
            newData.Header = "qqq";

            if (!app.Groups.ThereIsAGroup(1))
            {
                app.Groups.Create(new GroupData("group_2222"));
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Modify(0, newData);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
