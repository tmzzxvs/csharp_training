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
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (app.Groups.ThereIsAGroup(1) == false)
            {
                app.Groups.Create(new GroupData("group_2222"));
            }
            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

        }
                                    
                     
    }
}