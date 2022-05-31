using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {   
        [Test]
        public void GroupRemovaltest()
        {
            if (!app.Groups.ThereIsAGroup(1))
            {                
                app.Groups.Create(new GroupData("group_2222"));
            }

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData ToBeRemoved = oldGroups[0];
            app.Groups.Remove(ToBeRemoved);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }                                   
                     
    }
}