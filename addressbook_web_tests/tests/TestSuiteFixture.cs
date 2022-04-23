using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        [SetUp]
        public void InitApplicationManager()
        {
            ApplicationManager app = ApplicationManager.GetInstance();
            app.Navi.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }


    }
}
