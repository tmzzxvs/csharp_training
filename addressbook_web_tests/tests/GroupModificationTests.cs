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
            GroupData newData = new GroupData("updated_1");
            newData.Footer = "ttt";
            newData.Header = "qqq";

            if (!app.Groups.ThereIsAGroup(1))
            {
                app.Groups.Create(new GroupData("group_2222"));
            }



            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];
            app.Groups.Modify(oldData, newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Id = newData.Id;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

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
