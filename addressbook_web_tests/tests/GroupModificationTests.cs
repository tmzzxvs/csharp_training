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
            GroupData newData = new GroupData("sssss");
            newData.Footer = "ttt";
            newData.Header = "qqq";

            if (app.Groups.ThereIsAGroup(1) == false)
            {
                app.Groups.Create(new GroupData("group_2222"));
            }
            app.Groups.Modify(1, newData);

        }
    }
}
