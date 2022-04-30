using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {   
        [Test]
        public void GroupRemovaltest()
        {
            app.Navi.GoToGroupsPage();
            if (app.Groups.ThereIsAGroup(1) == false)
            {
                app.Groups.Create(new GroupData("group_2222"));
            }
            app.Groups.Remove(1);
        }
                                    
                     
    }
}