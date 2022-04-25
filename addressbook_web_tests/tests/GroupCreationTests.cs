﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests

{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
         [Test]
        public void GroupCreationTest()
            {
                GroupData group = new GroupData("Group_99999");
                group.Footer = "test_3";
                group.Header = "test_33";
                app.Groups.Create(group);
            }
        [Test]
        public void EmptyGroupCreationTest()
            {
                GroupData group = new GroupData("");
                group.Footer = "";
                group.Header = "";
                app.Groups.Create(group);
            }



    }
}
