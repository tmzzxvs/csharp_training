using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests

{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
         [Test]
        public void GroupCreationTest()
        {
            app.navi.OpenHomePage();
            app.auth.Login(new AccountData("admin", "secret"));
            app.navi.GoToGroupsPage();
            app.groups.InitNewGroupCreation();
            GroupData group = new GroupData("Group_12");
            group.Footer = "test_3";
            group.Header = "test_33";
            app.groups.FillGroupForm(group);
            app.groups.SubmitGroupCreation();
            app.groups.ReturnToGroupsPage();
            app.navi.ExitFromAddressbook();
        }

        
                      
                                     
    }
}
