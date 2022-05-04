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

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(0);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }                                   
                     
    }
}