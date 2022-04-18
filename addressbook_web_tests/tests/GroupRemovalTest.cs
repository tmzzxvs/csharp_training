using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {   
        [Test]
        public void GroupRemovaltest()
        {
            app.navi.OpenHomePage();
            app.auth.Login(new AccountData("admin", "secret"));
            app.navi.GoToGroupsPage();
            app.groups.SelectGroup(1);
            app.groups.RemoveGroup();
            app.groups.ReturnToGroupsPage();
            app.navi.ExitFromAddressbook();
        }
                                    
                     
    }
}