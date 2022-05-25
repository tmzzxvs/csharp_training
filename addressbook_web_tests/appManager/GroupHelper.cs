using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) 
            : base(manager)
            {
            }
        public GroupHelper Create(GroupData group)
        {
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.Navi.ReturnToGroupsPage();
            return this;
        }
        public GroupHelper Modify(int v, GroupData newData)
        {
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            manager.Navi.ReturnToGroupsPage();
            return this;
        }

        public int GetGroupCount()
        {
           return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public GroupHelper Remove(GroupData group)
        {
            SelectGroup(group.Id);
            RemoveGroup();
            manager.Navi.ReturnToGroupsPage();
            return this;
        }
        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }        
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }     
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index+1) + "]/input")).Click();
            return this;
        }
        public GroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public bool ThereIsAGroup(int v)
        {
            return IsElementPresent(By.XPath("//div[@id='content']/form/span[" + v + "]/input"));
        }

        private List<GroupData> groupCache = null;
        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navi.ReturnToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text) {
                    Id = element.FindElement(By.TagName("input")).GetAttribute("value")

                    });                   
                    
                }
            }
            return new List<GroupData>(groupCache);
        }

    }
}
